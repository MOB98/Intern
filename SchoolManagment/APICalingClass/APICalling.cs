using DEMO.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DEMO.APICalingClass
{
    public class APICalling
    {
        public HttpClient Initial()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44345/");
            return client;

        }

        public IList<Student> getStudents()
        {
            IList<Student> students = null;

            HttpClient client = Initial();

            //HTTP GET
            var responseTask = client.GetAsync("api/Students");
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsStringAsync().Result;


                students = JsonConvert.DeserializeObject<IList<Student>>(readTask);
            }


            return students;



        }


        public IList<Course> getCourses()
        {
            IList<Course> courses = null;

            HttpClient client = Initial();

            //HTTP GET
            var responseTask = client.GetAsync("api/Courses");
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsStringAsync().Result;


                courses = JsonConvert.DeserializeObject<IList<Course>>(readTask);
            }


            return courses;



        }


        public IList<Teacher> getTeachers()
        {
            IList<Teacher> teachers = null;

            HttpClient client = Initial();

            //HTTP GET
            var responseTask = client.GetAsync("api/Teachers");
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsStringAsync().Result;


                teachers = JsonConvert.DeserializeObject<IList<Teacher>>(readTask);
            }   


            return teachers;



        }

    }
}
