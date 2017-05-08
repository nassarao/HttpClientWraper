using HttpClientFramework;
using Newtonsoft.Json.Linq;
using QTestDTOs;

namespace QTestAPI
{
    public static class TestRunAPI
    {

        private static string url { get; set; }


        /// <summary>
        /// Get all active test-run fields
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public static PostObject GetAllFields(int projectId)
        {
            url = $"api/v3/projects/{projectId}/settings/test-runs/fields";

            return new PostObject(url, "GET");
        }

        /// <summary>
        /// Get all execution status values
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public static PostObject GetExecutionStatusValues(int projectId)
        {
            url = $"api/v3/projects/{projectId}/test-runs/execution-statuses";

            return new PostObject(url, "GET");
        }

        /// <summary>
        /// Get a test run by Id of test run
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="testRunId"></param>
        /// <returns></returns>
        public static PostObject GetTestRunById(int projectId, int testRunId)
        {
            url = $"api/v3/projects/{projectId}/test-runs/{testRunId}";

            return new PostObject(url, "GET");
        }

        /// <summary>
        /// Get All test runs
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="testRunId"></param>
        /// <returns></returns>
        public static PostObject GetAll(int projectId)
        {
            url = $"api/v3/projects/{projectId}/test-runs/";

            return new PostObject(url, "GET");
        }

		/// <summary>
		/// Gets the test runs of a specific test case
		/// </summary>
		/// <param name="projectId"></param>
		/// <param name="testcaseId"></param>
		/// <returns></returns>
		public static PostObject GetByTestCaseID(int projectId, int testcaseId)
		{
			string url = $"api/v3/projects/{projectId}/linked-artifacts?type=test-cases&ids={testcaseId}";

			return new PostObject(url, "GET");
		}


		/// <summary>
		/// Get all test runs by Release
		/// </summary>
		/// <param name="projectId"></param>
		/// <param name="releaseId"></param>
		/// <returns></returns>
		public static PostObject GetAllByRelease(int projectId, int releaseId)
        {
            url = $"api/v3/projects/{projectId}/test-runs?parentId={releaseId}&parentType=release";

            return new PostObject(url, "GET");
        }

        /// <summary>
        /// Get all test runs by Test-Cycle
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="cycleId"></param>
        /// <returns></returns>
        public static PostObject GetAllByCycle(int projectId, int cycleId)
        {
            url = $"api/v3/projects/{projectId}/test-runs?parentId={cycleId}&parentType=test-cycle";

            return new PostObject(url, "GET");
        }

        /// <summary>
        /// Get all test runs by test-suite
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="suiteID"></param>
        /// <returns></returns>
        public static PostObject GetAllBySuite(int projectId, int suiteID)
        {
            url = $"api/v3/projects/{projectId}/test-runs?parentId={suiteID}&parentType=test-suite";

            return new PostObject(url, "GET");
        }

        /// <summary>
        /// Get latest Test log of a test run
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="testRunId"></param>
        /// <returns></returns>
        public static PostObject GetLatestTestLogOfTestRun(int projectId, int testRunId)
        {
            url = $"api/v3/projects/{projectId}/test-runs/{testRunId}/test-logs/last-run?expand={{testcase, teststeplog.teststep}}";
            return new PostObject(url, "GET");
        }


        /// <summary>
        /// Get all test logs of a specific test run
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="testRunId"></param>
        /// <returns></returns>
        public static PostObject GetAllTestLogsOfTestRun(int projectId, int testRunId)
        {
            url = $"api/v3/projects/{projectId}/test-runs/{testRunId}/test-logs";

            return new PostObject(url, "GET");
        }

        /// <summary>
        /// Create a test run under root
        /// </summary>
        /// <returns></returns>
        public static PostObject CreateTestRun(int projectId, TestRun testRun)
        {
          
            url = $"api/v3/projects/{projectId}/test-runs/{testRun.id}/test-logs";
            int Status = 0;
            switch (testRun.status)
            {
                case "Passed":
                    Status = 601;
                    break;
                case "Running":
                    Status = 603;
                    break;
                case "In Queue":
                    Status = 605;
                    break;
                case "Failed":
                    Status = 602;
                    break;
            }
            dynamic status = new JObject();
            status.id = Status;
            dynamic obj = new JObject();
            obj.exe_start_date = testRun.start_date.ToString("s") + testRun.start_date.ToString("zzz");
            obj.exe_end_date = testRun.end_date.ToString("s") + testRun.end_date.ToString("zzz");
            obj.status = status;
            obj.note = testRun.note;

            return new PostObject(url, obj, "POST");
        }

        public static PostObject Create(int projectId, int parentId,string type, TestRun testRun)
        {
            url = $"api/v3/projects/{projectId}/test-runs?parentId={parentId}&parentType={type}";

            JObject obj = QtHttpClient.Serialize(testRun);
            return new PostObject(url, obj, "POST");
        }

        /// <summary>
        /// Create testrun under a specific release
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="testRun"></param>
        /// <returns></returns>
        public static PostObject CreateTestRunByRelease(int projectId, int releaseId, TestRun testRun)
        {
            url = $"api/v3/projects/{projectId}/test-runs?parentId={releaseId}&parentType=release";

            JObject obj = QtHttpClient.Serialize(testRun);
            return new PostObject(url, obj, "POST");
        }

        /// <summary>
        /// Create testrun under a specific test-suite
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="testRun"></param>
        /// <returns></returns>
        public static PostObject CreateTestRunBySuite(int projectId, int suiteId, TestRun testRun)
        {
            url = $"api/v3/projects/{projectId}/test-runs?parentId={suiteId}&parentType=test-suite";

            JObject obj = QtHttpClient.Serialize(testRun);

            return new PostObject(url, obj, "POST");
        }

        /// <summary>
        /// Create testrun under a specific test-cycle
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="testRun"></param>
        /// <returns></returns>
        public static PostObject CreateTestRunByCycle(int projectId, int cycleId, TestRun testRun)
        {
            url = $"api/v3/projects/{projectId}/test-runs?parentId={cycleId}&parentType=test-cycle";

            JObject obj = QtHttpClient.Serialize(testRun);
            return new PostObject(url, obj, "POST");
        }

        public static PostObject Update(int projectId, int testRunId, TestRun testRun)
        {
            url = $"api/v3/projects/{projectId}/test-runs/{testRunId}";
            JObject obj = QtHttpClient.Serialize(testRun);

            return new PostObject(url, obj, "POST");
        }

        public static PostObject Delete(int projectId, int testRunId)
        {
            url = $"api/v3/projects/{projectId}/test-runs/{testRunId}";

            return new PostObject(url, "DELETE");
        }

        public static PostObject SubmitTestLog(int projectId, int testRunId, TestLog log)
        {
            url = $"api/v3/projects/{projectId}/test-runs/{testRunId}/test-logs";
            JObject obj = QtHttpClient.Serialize(log);

            return new PostObject(url, obj, "POST");

        }

        public static PostObject SubmitAutomationTestLog(int projectId, int testRunId, TestLog log)
        {
            url = $"api/v3/projects/{projectId}/test-runs/{testRunId}/auto-test-logs";
            JObject obj = QtHttpClient.Serialize(log);

            return new PostObject(url, obj, "POST");

        }

    }
}
