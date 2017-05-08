using Newtonsoft.Json.Linq;
using HttpClientFramework;
using QTestDTOs;
using AutomationDTOs;
using System.Collections.Generic;

namespace QTestAPI
{
    public static class TestCaseAPI
    {
        private static string url { get; set; }


        /// <summary>
        /// Gets all active Test Cases's fields
        /// </summary> GET /api/v3/projects/{projectId}/test-cases/{testCaseId}/te
        /// <param name="projectId"></param>
        /// <returns></returns>
        public static PostObject GetAllFields(int projectId)
        {
            // GET /api/v3/projects/{projectId}/settings/test-cases/fields
            url = $"api/v3/projects/{projectId}/settings/test-cases/fields";

            return new PostObject(url, "GET");
        }


        /// <summary>
        ///Gets a specific TestCase by it id
        /// </summary>
        /// <returns></returns>
        public static PostObject GetById(int projectId, int testCaseId)
        {
            // GET /api/v3/projects/{projectId}/test-cases/{testCaseId}
            url = $"api/v3/projects/{projectId}/test-cases/{testCaseId}";

            return new PostObject(url, "GET");
        }

        /// <summary>
        /// Gets all test cases in a Project
        /// </summary>
        /// <returns>All test Cases in a Project</returns>
        public static PostObject GetAll(int projectId, int size = 1000)
        {
            // GET /api/v3/projects/{projectId}/test-cases
            url = $"/api/v3/projects/{projectId}/test-cases?size={size} ";

            return new PostObject(url, "GET");
        }
        public static PostObject GetAllByModule(int projectId, int parentId, int size = 1000)
        {
            url = $"/api/v3/projects/{projectId}/test-cases?{parentId}?size={size} ";
            return new PostObject(url, "GET");
        }


        /// <summary>
        /// Creates a TestCase with the all the properties of the passed TestCase
        /// </summary>
        /// <param name="name">Needed to give the TestCase a Name</param>
        /// <param name="properties"></param>
        /// <param name="parentId">Parent id found by URL of the modules in test design section of UI. </param>
        /// <returns></returns>
        public static PostObject Create(int projectId, TestCase testCase, string parentId = null)
        {
            url = $"api/v3/projects/{projectId}/test-cases/";
            if (testCase.parent_id == null)
                testCase.parent_id = parentId.ToString();

            JObject obj = QtHttpClient.Serialize(testCase);

            return new PostObject(url, obj, "POST");
        }

        /// <summary>
        /// Updates a Manual Test Case
        /// </summary>
        /// <param name="testCaseDto"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public static PostObject Update(int projectId, int testCaseId, TestCase updatedTestCase)
        {

            url = $"api/v3/projects/{projectId}/test-cases/{testCaseId}";
            //updatedTestCase.parent_id = parentId.ToString();

            JObject obj = QtHttpClient.Serialize(updatedTestCase);

            return new PostObject(url, /*obj,*/ "PUT");
        }


        /// <summary>
        /// Gets TestCase information of a specific version.
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="testCaseId"></param>
        /// <param name="versionId"></param>
        /// <returns></returns>
        public static PostObject GetSpecificVersion(int projectId, int testCaseId, int versionId)
        {
            url = $"api/v3/projects/{projectId}/test-cases/{testCaseId}/versions/{versionId}";

            return new PostObject(url, "GET");
        }

        /// <summary>
        /// Gets All Versions of a test Case
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="testCaseId"></param>
        /// <returns></returns>
        public static PostObject GetAllVersions(int projectId, int testCaseId)
        {
            url = $"api/v3/projects/{projectId}/test-cases/{testCaseId}/versions";
            return new PostObject(url, "GET");
        }

        /// <summary>
        /// Approve a Test Case
        /// </summary>
        /// <param name="TestCaseId"></param>
        /// <returns></returns>
        public static PostObject Approve(int projectId, int testCaseId)
        {
            url = $"api/v3/projects/{projectId}/test-cases/{testCaseId}/approve";

            return new PostObject(url, "PUT");
        }

        /// <summary>
        /// Deletes a Test Case by its Id
        /// </summary>
        /// <param name="TestCaseId"></param>
        /// <returns></returns>
        public static PostObject Delete(int projectId, int testCaseId)
        {
            url = $"api/v3/projects/{projectId}/test-cases/{testCaseId}";

            return new PostObject(url, "DELETE");
        }

        //Grab all Module components from qTEST
        public static PostObject GrabModules(int QTestProjectID)
        {
            url = $"api/v3/projects/{QTestProjectID}/modules";

            return new PostObject(url, "GET");
        }
        public static PostObject SubmitATestLog(int projectId, int testRunId)
        {
            url = $"api/v3/projects/{projectId}/test-runs/{testRunId}test-logs";

            return new PostObject(url, "POST");
        }

        public static PostObject CreateAStepTest(int projectId, int testCaseId, TestStep teststep)
        {
            url = $"api/v3/projects/{projectId}/test-cases/{testCaseId}/test-steps";

            JObject obj = QtHttpClient.Serialize(teststep);

            return new PostObject(url, obj, "POST");
        }

        public static PostObject UpdateAtestStep(int projectId, int testCaseId, int testStepId)
        {
            url = $"api/v3/projects/{projectId}/test-cases/{testCaseId}/test-steps/{testStepId}";

            return new PostObject(url, "PUT");
        }

        public static PostObject DeleteATestStep(int projectId, int testCaseId, int testStepId)
        {
            url = $"api/v3/projects/{projectId}/test-cases/{testCaseId}/test-steps/{testStepId}";

            return new PostObject(url, "DELETE");
        }

    }
}
