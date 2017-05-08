using HttpClientFramework;
using Newtonsoft.Json.Linq;
using static QTestDTOs.Automation;

namespace QTestAPIMethods
{
    public static class AutomationAPI
    {

        public static class HostAPI
        {
            private static string url { get; set; }

            public static PostObject Create(Host host)
            {
                url = $"api/v3/automation/host";
                JObject obj = QtHttpClient.Serialize(host);

                return new PostObject(url, obj, "POST");
            }

            public static PostObject Update(int host_server_id, Host host)
            {
                url = $"api/v3/automation/hosts/{host_server_id}";
                JObject obj = QtHttpClient.Serialize(host);

                return new PostObject(url, obj, "POST");
            }

            /// <summary>
            /// Ping from an automation host to QTest. To check if it's reachable from your Automation Host to your qTest Server. Every 30 minutes, qTest will check if there are any pings from your Automation Host within the last 30 minutes. If so, you can see the host's status is Online in qTest. If not, it shows Offline.
            /// </summary>
            /// <returns></returns>
            public static PostObject Ping(int host_server_id, Host host)
            {
                url = $"api/v3/automation/hosts/{host_server_id}";
                dynamic obj = new JObject();
                obj.host_guid = host.host_guid;

                return new PostObject(url, obj, "POST");
            }

            public static PostObject RetrievceScheduledJobs(int host_server_id)
            {
                url = $"api/v3/automation/hosts/{host_server_id}/jobs";

                return new PostObject(url, "GET");
            }

            /// <summary>
            /// The job's status after being updated. The valid values include: CANCELLED, RUNNING, COMPLETED and FAILED
            /// </summary>
            /// <param name="projectId"></param>
            /// <param name="job_id"></param>
            /// <param name="status"></param>
            /// <returns></returns>
            public static PostObject UpdateJobStatus(int projectId, int job_id, string status)
            {
                url = $"/api/v3/projects/{projectId}/automation/jobs/{job_id}/status";
                dynamic obj = new JObject();
                obj.status = status;

                return new PostObject(url, obj, "POST");
            }

        }

        public static class AgentAPI
        {
            private static string url { get; set; }

            public static PostObject Create(int projectId, int host_server_id, Agent agent)
            {
                url = $"api/v3/projects/{projectId}/automation/hosts/{host_server_id}/agents";
                JObject obj = QtHttpClient.Serialize(agent);

                return new PostObject(url, obj, "POST");
            }

            public static PostObject Update(int projectId, int host_server_id , int agent_server_id, Agent agent)
            {
                url = $"api/v3/projects/{projectId}/automation/hosts/{host_server_id}/agents/{agent_server_id}";
                JObject obj = QtHttpClient.Serialize(agent);

                return new PostObject(url, obj, "POST");
            }

            public static PostObject Deactivate(int projectId, int host_server_id, int agent_server_id)
            {
                url = $"api/v3/projects/{projectId}/automation/hosts/{host_server_id}/agents/{agent_server_id}/deactivate";

                return new PostObject(url, "POST");
            }

           
        }
    }
}
