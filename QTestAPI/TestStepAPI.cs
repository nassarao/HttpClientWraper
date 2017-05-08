using HttpClientFramework;
using QTestDTOs;
using Newtonsoft.Json.Linq;

namespace QTestAPI
{
    public static class TestStepAPI
    {
        private static string url { get; set; }

        public static PostObject Get(int projectId, int testCaseId, int testStepId)
        {
            // GET /api/v3/projects/{projectId}/test-cases/{testCaseId}/test-steps/{testStepId}
            url = $"/api/v3/projects/{projectId}/test-cases/{testCaseId}/test-steps/{testStepId}";

            return new PostObject(url, "GET");
        }
        public static PostObject GetAll(int projectId, int testCaseId)
        {
            // GET /api/v3/projects/{projectId}/test-cases/{testCaseId}/test-steps/
            url = $"/api/v3/projects/{projectId}/test-cases/{testCaseId}/test-steps/";

            return new PostObject(url, "GET");
        }

        public static PostObject Create(int projectId, int testCaseId, TestStep testStep)
        {
            url = $"/api/v3/projects/{projectId}/test-cases/{testCaseId}/test-steps/";
            JObject obj = QtHttpClient.Serialize(testStep);

            return new PostObject(url, obj, "POST");
        }

        public static PostObject Update(int projectId, int testCaseId, int testStepId, TestStep testStep)
        {
            url = $"/api/v3/projects/{projectId}/test-cases/{testCaseId}/test-steps/{testStepId}";
            JObject obj = QtHttpClient.Serialize(testStep);

            return new PostObject(url, obj, "POST");
        }

        public static PostObject Delete(int projectId, int testCaseId, int testStepId)
        {
            url = $"/api/v3/projects/{projectId}/test-cases/{testCaseId}/test-steps/{testStepId}";
            return new PostObject(url, "DELETE");
        }

    }
}
