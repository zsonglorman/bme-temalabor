using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Interfaces;
using Newtonsoft.Json;

namespace Mocks.Factory
{
    class WebApiSubjectManager : ISubjectManager
    {
        private static readonly HttpClient Client = new HttpClient();

        private const string ApiBaseAddress = "http://localhost:58908/";

        public List<Subject> GetSubjects()
        {
            if (Client.BaseAddress == null)
            {
                Client.BaseAddress = new Uri(ApiBaseAddress);
            }

            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = Client.GetAsync("api/Subject").Result;
            var stringData = response.Content.ReadAsStringAsync().Result;
            var data = JsonConvert.DeserializeObject<List<Subject>>(stringData);

            return data;
        }

        public List<Subject> SearchSubjects(string keyword)
        {
            if (Client.BaseAddress == null)
            {
                Client.BaseAddress = new Uri(ApiBaseAddress);
            }

            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = Client.GetAsync("api/Subject/" + keyword).Result;
            var stringData = response.Content.ReadAsStringAsync().Result;
            var data = JsonConvert.DeserializeObject<List<Subject>>(stringData);

            return data;
        }

        public List<Course> GetCoursesOfSubject(int subjectId)
        {
            if (Client.BaseAddress == null)
            {
                Client.BaseAddress = new Uri(ApiBaseAddress);
            }

            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = Client.GetAsync("api/Course/" + subjectId).Result;
            var stringData = response.Content.ReadAsStringAsync().Result;
            var data = JsonConvert.DeserializeObject<List<Course>>(stringData);

            return data;
        }

        public List<Grade> GetGradesOfSemester(int semester)
        {
            if (Client.BaseAddress == null)
            {
                Client.BaseAddress = new Uri(ApiBaseAddress);
            }

            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = Client.GetAsync("api/Grade/" + semester).Result;
            var stringData = response.Content.ReadAsStringAsync().Result;
            var data = JsonConvert.DeserializeObject<List<Grade>>(stringData);

            return data;
        }
    }
}