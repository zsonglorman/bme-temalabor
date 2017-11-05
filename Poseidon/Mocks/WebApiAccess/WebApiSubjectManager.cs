using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace Mocks.Factory
{
    public class WebApiSubjectManager : ISubjectManager
    {
        private static readonly HttpClient Client = new HttpClient();

        private const string ApiBaseAddress = "http://localhost:60656/";

        /// <summary>
        /// Get all subjects (without grades).
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Search subjects based on keyword (serach by subject name or subject code).
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Get all courses of a subject based on its subject ID.
        /// </summary>
        /// <param name="subjectId"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Get subjects with their grades of a semester (each subject has exactly one grade).
        /// </summary>
        /// <param name="semester"></param>
        /// <returns></returns>
        public List<SubjectWithGrade> GetSubjectsWithGradesOfSemester(int semester)
        {
            if (Client.BaseAddress == null)
            {
                Client.BaseAddress = new Uri(ApiBaseAddress);
            }

            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = Client.GetAsync("api/Grade/" + semester).Result;
            var stringData = response.Content.ReadAsStringAsync().Result;
            var data = JsonConvert.DeserializeObject<List<SubjectWithGrade>>(stringData);

            return data;
        }

        /// <summary>
        /// Insert a new grade for a subject.
        /// </summary>
        /// <param name="grade"></param>
        public void InsertGradeOfSubject(Grade grade)
        {
            if (Client.BaseAddress == null)
            {
                Client.BaseAddress = new Uri(ApiBaseAddress);
            }

            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = Client.PostAsync("api/Grade/", new StringContent(JsonConvert.SerializeObject(grade), Encoding.UTF8, "application/json")).Result;
            
            if (response.IsSuccessStatusCode)
            {
                // OK
            }
        }

        /// <summary>
        /// Update a grade of a subject. You may update Signature, Passed and ReceivedGrade fields.
        /// </summary>
        /// <param name="grade"></param>
        public void UpdateGradeOfSubject(Grade grade)
        {
            if (Client.BaseAddress == null)
            {
                Client.BaseAddress = new Uri(ApiBaseAddress);
            }

            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = Client.PutAsync("api/Grade/", new StringContent(JsonConvert.SerializeObject(grade), Encoding.UTF8, "application/json")).Result;

            if (response.IsSuccessStatusCode)
            {
                // OK
            }
        }

        /// <summary>
        /// Deletes a grade from a subject. Grade is deleted based on its StudentID, SubjectID and EnrollmentSemester.
        /// </summary>
        /// <param name="grade"></param>
        public void DeleteGradeOfSubject(Grade grade)
        {
            if (Client.BaseAddress == null)
            {
                Client.BaseAddress = new Uri(ApiBaseAddress);
            }

            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = Client.DeleteAsync(string.Format("api/Grade/{0}/{1}/{2}", grade.StudentID, grade.SubjectID, grade.EnrollmentSemester)).Result;

            if (response.IsSuccessStatusCode)
            {
                // OK
            }
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        public List<SubjectWithGrade> GetSubjectsWithGrades()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get all grades of a subject based on its SubjectID.
        /// </summary>
        /// <param name="subjectId"></param>
        /// <returns></returns>
        public List<Grade> GetGradesOfSubject(int subjectId)
        {
            if (Client.BaseAddress == null)
            {
                Client.BaseAddress = new Uri(ApiBaseAddress);
            }

            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = Client.GetAsync("api/Grade/?subjectId=" + subjectId).Result;
            var stringData = response.Content.ReadAsStringAsync().Result;
            var data = JsonConvert.DeserializeObject<List<Grade>>(stringData);

            return data;
        }
    }
}