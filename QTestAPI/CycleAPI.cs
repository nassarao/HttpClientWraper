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
    public static class CycleAPI
    {
        public static string url { get; set; }

        public static PostObject GetbyRelease(int projectId, int releaseId)
        {
            url = $"api/v3/projects/{projectId}/test-cycles?parentId={releaseId}&parentType=release";

            return new PostObject(url, "GET");
        }

        public static PostObject GetbyReleaseExpand(int projectId, int releaseId)
        {
            url = $"api/v3/projects/{projectId}/test-cycles?parentId={releaseId}&parentType=release&expand=descendants";

            return new PostObject(url, "GET");
        }
        public static PostObject Delete(int projectId, int cycleId)
        {
            url = $"api/v3/projects/{projectId}/test-cycles/{cycleId}";
            return new PostObject(url, "DELETE");
        }

        public static PostObject Create(int projectId, Cycle cycle)
        {
            url = $"api/v3/projects/{projectId}/test-cycles";
            JObject obj = QtHttpClient.Serialize(cycle);

            return new PostObject(url, obj, "POST");
        }
        public static PostObject Create(int projectId, int parentId,string type,Cycle cycle)
        {
            url = $"api/v3/projects/{projectId}/test-cycles?parentId={parentId}&parentType={type}";
            JObject obj = QtHttpClient.Serialize(cycle);

            return new PostObject(url, obj, "POST");
        }
    }
}
