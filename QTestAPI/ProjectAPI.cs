using HttpClientFramework;
using QTestDTOs;
using Newtonsoft.Json.Linq;

namespace QTestAPI
{
    public static class ProjectAPI 
    {
        private static string url { get; set; }

        /// <summary>
        /// Creates a project with name, Description, Start_Date, End_Date and admins
        /// </summary>
        /// <returns></returns>
        public static PostObject Create(Project project)
        {
            url = "api/v3/projects";
            dynamic obj = new JObject();
            obj.name = project.name;
            obj.description = project.description;
            obj.start_date = project.start_date;
            obj.end_date = project.end_date;

            return new PostObject(url, obj, "POST");
        }
        
        /// <summary>
        /// Gets all Projects in QTest
        /// </summary>
        /// <returns></returns>
        public static PostObject GetAll()
        {
            url = "api/v3/projects";
            return new PostObject(url, "GET");
        }

        public static PostObject GetById(int projectId)
        {
            url = $"api/v3/projects/{projectId}";
            return new PostObject(url, "GET");

        }

    }
}
