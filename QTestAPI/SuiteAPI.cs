using HttpClientFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QTestDTOs;
using Newtonsoft.Json.Linq;

namespace QTestAPI
{
    public static class SuiteAPI
    {
        public static string url { get; set; }

        public static PostObject GetSuiteByRelease(int projectId, int parentCycleId)
        {
            url = $"api/v3/projects/{projectId}/test-suites?parentId={parentCycleId}&parentType=test-cycle";

            return new PostObject(url, "GET");
        }


        public static PostObject Delete(int projectId, int suiteid)
        {
            url = $"api/v3/projects/{projectId}/test-suites/{suiteid}";
            return new PostObject(url, "DELETE");
        }
        public static PostObject Create(int projectId, Suite suite)
        {
            url = $"api/v3/projects/{projectId}/test-suites";
            JObject obj = QtHttpClient.Serialize(suite);

            return new PostObject(url, obj, "POST");
        }
        public static PostObject Create(int projectId, int parentId,string type,Suite suite)
        {
            url = $"api/v3/projects/{projectId}/test-suites?parentId={parentId}&parentType={type}";
            JObject obj = QtHttpClient.Serialize(suite);

            return new PostObject(url, obj, "POST");
        }
    }
}
