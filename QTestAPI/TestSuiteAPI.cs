using HttpClientFramework;

namespace QTestAPI
{
    public static class TestSuiteAPI
    {
        public static string url { get; set; }
        public static PostObject GetAllTestSuiteFields(int projectId)
        {
            url = $"/api/v3/projects/{ projectId}/settings/test-suites/fields";
            return new PostObject(url, "GET");
        }
        public static PostObject GetTestSuiteById(int projectId, int testSuiteId)
        {
            url = $"/api/v3/projects/{projectId}/test-suites/{testSuiteId}";
            return new PostObject(url, "GET");
        }
        public static PostObject GetAllTestSuitesUnderRoot(int projectId)
        {
            url = $"/api/v3/projects/{projectId}/test-suites";
            return new PostObject(url, "GET");
        }
        public static PostObject GetTestSutiesUnderSpecificRelease(int projectId, int releaseId)
        {
            url = $"/api/v3/projects/{projectId}/test-suites?parentId={releaseId}&parentType=release";
            return new PostObject(url, "GET");
        }
        public static PostObject GetTestSutiesUnderTestCycle(int projectId, int parentCycleId)
        {
            url = $"/api/v3/projects/{projectId}/test-suites?parentId={parentCycleId}&parentType=test-cycle";
            return new PostObject(url, "GET");
        }
        public static PostObject CreateTestSuite(int projectId)
        {
            url = $"/api/v3/projects/{projectId}/test-suites";
            return new PostObject(url, "GET");
        }
        public static PostObject CreateTestSuiteUnderSpecificRelase(int projectId, int releaseId)
        {
            url = $"/api/v3/projects/{projectId}/test-suites?parentId={releaseId}&parentType=release";
            return new PostObject(url, "GET");
        }
        public static PostObject CreateTestSuiteUnderSpecificCycle(int projectId, int testCycleId)
        {
            url = $"/api/v3/projects/{projectId}/test-suites?parentId={testCycleId}&parentType=test-cycle";
            return new PostObject(url, "GET");
        }
        public static PostObject UpdateOrMoveTestSuite(int projectId, int testSuiteId)
        {
            url = $"/api/v3/projects/{projectId}/test-suites/{testSuiteId}";
            return new PostObject(url, "GET");
        }
    }
}
