using HttpClientFramework;
using Newtonsoft.Json.Linq;
using QTestDTOs;

namespace QTestAPIMethods
{
    public static class ModuleAPI
    {
        public static string url { get; set; }

        public static PostObject GetByID(int projectId, int moduleId)
        {
            url = $"api/v3/projects/{projectId}/modules/{moduleId}";

            return new PostObject(url, "GET");
        }

        public static PostObject GetAll(int projectId)
        {
            url = $"api/v3/projects/{projectId}/modules";

            return new PostObject(url, "GET");
        }

        public static PostObject SearchByName(int projectId, string name)
        {
            url = $"api/v3/projects/{projectId}/modules?search={name}";

            return new PostObject(url, "GET");
        }

        public static PostObject Create(int projectId, Module module)
        {
            url = $"api/v3/projects/{projectId}/modules";
            JObject obj = QtHttpClient.Serialize(module);

            return new PostObject(url, obj, "POST");
        }

        public static PostObject Update(int projectId,int moduleId, Module module)
        {
            url = $"api/v3/projects/{projectId}/modules/{moduleId}";
            JObject obj = QtHttpClient.Serialize(module);

            return new PostObject(url, obj, "POST");
        }

        public static PostObject Delete(int projectId, int moduleId)
        {
            url = $"api/v3/projects/{projectId}/modules/{moduleId}";

            return new PostObject(url, "DELETE");
        }
    }
}
