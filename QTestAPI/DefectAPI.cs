using HttpClientFramework;
using Newtonsoft.Json.Linq;
using QTestDTOs;

namespace QTestAPIMethods
{
    public static class DefectAPI
    {
        public static string url { get; set; }

        public static PostObject GetAllFields(int projectId)
        {
            url = $"api/v3/projects/{projectId}/settings/defects/fields";

            return new PostObject(url, "GET");
        }
        public static PostObject GetById(int projectId, int defectId)
        {
            url = $" /api/v3/projects/{projectId}/defects/{defectId}";

            return new PostObject(url, "GET");
        }

        public static PostObject GetRecentlyUpdated(int projectId)
        {
            url = $" /api/v3/projects/{projectId}/defects/last-change";

            return new PostObject(url, "GET");
        }


        public static PostObject Create(int projectId, Defect defect)
        {
            url = $"api/v3/projects/{projectId}/defects/";
            JObject obj = QtHttpClient.Serialize(defect);

            return new PostObject(url, obj,"POST");
        }

        public static PostObject Update(int projectId, int defectId, Defect defect)
        {
            url = $"api/v3/projects/{projectId}/defects/{defectId}";
            JObject obj = QtHttpClient.Serialize(defect);

            return new PostObject(url, obj, "POST");
        }

    }
}
