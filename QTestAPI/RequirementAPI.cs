using HttpClientFramework;
using Newtonsoft.Json.Linq;
using QTestDTOs;
using System;

namespace QTestAPIMethods
{
    public static class RequirementAPI
    {
        public static string url { get; set; }

        public static PostObject GetAllFields(int projectId)
        {
            url = $"api/v3/projects/{projectId}/settings/requirements/fields";

            return new PostObject(url, "GET");
        }

        public static PostObject GetById(int projectId, int requirementId)
        {
            url = $"api/v3/projects/{projectId}/requirements/{requirementId}";

            return new PostObject(url, "GET");
        }

        public static PostObject GetAll(int projectId)
        {
            url = $"api/v3/projects/{projectId}/requirements/";

            return new PostObject(url, "GET");
        }

        public static PostObject GetTraceabilitMatrix(int projectId)
        {
            url = $"api/v3/projects/{projectId}/requirements/trace-matrix-report";

            return new PostObject(url, "GET");
        }

        public static PostObject Create(int projectId, Requirement requirement)
        {
            url = $"api/v3/projects/{projectId}/requirements";
            JObject obj = QtHttpClient.Serialize(requirement);

            return new PostObject(url,obj, "POST");
        }

        public static PostObject Update(int projectId,int requirementId, Requirement requirement)
        {
            url = $"api/v3/projects/{projectId}/requirements/requirementId";
            JObject obj = QtHttpClient.Serialize(requirement);

            return new PostObject(url, obj, "POST");
        }

        public static PostObject Delete(int projectId, int requirementId)
        {
            url = $"api/v3/projects/{projectId}/requirements/{requirementId}";

            return new PostObject(url, "DELETE");
        }

        public static PostObject CreateLinkRequirementsAndTestCases(int projectId)
        {
            url = $"api/v3/projects/{projectId}/req-tc-links";

            throw new NotImplementedException();
        }
    }
}
