using HttpClientFramework;
using Newtonsoft.Json.Linq;
using QTestDTOs;

namespace QTestAPIMethods
{
    public static class BuildAPI
    {
        public static string url { get; set; }

        public static PostObject GetAllFields(int projectId)
        {
            url = $"api/v3/projects/{projectId}/setting/builds/fields";

            return new PostObject(url, "GET");
        }

        public static PostObject GetAll(int projectId)
        {
            url = $"api/v3/projects/{projectId}/builds";

            return new PostObject(url, "GET");
        }

        public static PostObject GetById(int projectId, int buildId)
        {
            url = $"api/v3/projects/{projectId}/builds/{buildId}";

            return new PostObject(url, "GET");
        }

        public static PostObject Create(int projectId, Build build)
        {
            url = $"api/v3/projects/{projectId}/builds/";
            JObject obj = QtHttpClient.Serialize(build);

            return new PostObject(url, obj, "POST");
        }

        public static PostObject Update(int projectId,int buildId, Build build)
        {
            url = $"api/v3/projects/{projectId}/builds/{buildId}";
            JObject obj = QtHttpClient.Serialize(build);

            return new PostObject(url, obj, "POST");
        }

        public static PostObject Delete(int projectId, int buildId)
        {
            url = $"api/v3/projects/{projectId}/builds/{buildId}";

            return new PostObject(url, "DELETE");
        }
    }
}
