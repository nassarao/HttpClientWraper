using HttpClientFramework;
using Newtonsoft.Json.Linq;
using QTestDTOs;

namespace QTestAPIMethods
{
    public static class ReleaseAPI
    {
        public static string url { get; set; }

        public static PostObject GetAll(int projectId)
        {
            url = $"api/v3/projects/{projectId}/releases";

            return new PostObject(url, "GET");
        }

        public static PostObject GetAllFields(int projectId)
        {
            url = $"api/v3/projects/{projectId}/settings/releases/fields";

            return new PostObject(url, "GET");
        }

        public static PostObject GetById(int projectId, int releaseId)
        {
            url = $"api/v3/projects/{projectId}/releases/{releaseId}";

            return new PostObject(url, "GET");
        }

        public static PostObject Create(int projectId, Release release)
        {
            url = $"api/v3/projects/{projectId}/releases";
            JObject obj = QtHttpClient.Serialize(release);

            return new PostObject(url, obj, "POST");
        }
        public static PostObject Update(int projectId, int releaseId, Release release)
        {
            url = $"api/v3/projects/{projectId}/releases/{releaseId}";
            JObject obj = QtHttpClient.Serialize(release);

            return new PostObject(url, obj, "POST");
        }

        public static PostObject Delete(int projectId, int releaseId)
        {
            url = $"api/v3/projects/{projectId}/releases/{releaseId}";
          
            return new PostObject(url,"DELETE");
        }
    }
}
