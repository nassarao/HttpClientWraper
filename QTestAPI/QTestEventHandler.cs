using System;
using System.Linq;
using System.Net.Http;
using AutomationDTOs;
using HttpClientFramework;
using QATestingFramework;
using QTestDTOs;
using QTestAPIMethods;
using Newtonsoft.Json.Linq;

namespace QTestAPI
{
    public static class QTestEventHandler
    {
        private static AutomationDB db = new AutomationDB();

        /// <summary>
        /// Returns an Event Handler for TestResultEvents that uses the logging engine for output.
        /// See also createTestCompleteHandler.
        /// </summary>
        /// <param name="engine">An engine to log from</param>
        /// <returns>EventHandler that submits TestResultEvents to QTest</returns>
        public static EventHandler<TestResultEventArgs> loggableTestCompleted(LoggingEngine engine)
        {
            return createTestCompleteHandler(engine.Info, engine.Warn, engine.Fatal);
        }

        /// <summary>
        /// Method for creating an event handler for TestResultEvents.
        /// The method produced will posts the results of the test to QTest, outputting messages along the way.
        /// </summary>
        /// <param name="log">Method to fire for basic log/information messages</param>
        /// <param name="warning">Method to fire for warning messages</param>
        /// <param name="error">Method to fire for errors that are irrecoverable</param>
        /// <returns>EventHandler that submits TestResultEvents to QTest</returns>
        public static EventHandler<TestResultEventArgs> createTestCompleteHandler(Action<string> log, Action<string> warning, Action<string> error)
        {
            return (object sender, TestResultEventArgs e) =>
            {
                using (QtHttpClient client = new QtHttpClient("https://intelligrated.qtestnet.com/"))
                {
                    log("Attempting to connect to QTest...");
                    if (LoginAPI.InitializeClient(client))
                    {

                        log("Connection successful.");
                        try
                        {
                            TestRunDTO testRun = db.TestRuns.Find(e.context.TestRunId);
                            TestDTO test = db.Tests.Include("Application").First(x => x.TestID == testRun.TestID);
                            TestRun run = new TestRun()
                            {
                                id = e.context.QTestRunId,
                                status = testRun.Status,
                                start_date = testRun.ExecutionTimestamp,
                                end_date = testRun.EndTimestamp,
                                note = testRun.Results
                            };

                            log("Attempting to send results to QTest.");
                            PostObject request = TestRunAPI.CreateTestRun(test.Application.QTestProjectId, run);
                            HttpResponseMessage response = client.Call(request);

                          

                            if (response.IsSuccessStatusCode)
                                log("Test results successfullly submitted to QTest");
                            else
                            {
                                var data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
                                String message = data["message"].Value<String>() ?? data.ToString();

                                warning("Failed to post log to QTest");
                                warning("Response Data: " + message);
                            }

                        }
                        catch (Exception exception)
                        {
                            error(String.Format("Exception {0}", exception));
                        }
                    }
                    else
                    {
                        error("Failed to connect to QTest");
                        error("Log not posted to QTest");
                    }
                }
            };
        }

    }

}