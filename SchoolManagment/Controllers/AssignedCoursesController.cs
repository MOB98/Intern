using DEMO.APICalingClass;
using DEMO.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DEMO.Controllers
{
    public class AssignedCoursesController : Controller
    {

        APICalling _api = new APICalling();

     

        // GET: AssignedCoursesController
        public ActionResult Index()
        {
            IList<AssignedCourse> courses = null;

            HttpClient client = _api.Initial();

            //HTTP GET
            var responseTask = client.GetAsync("api/AssignedCourses");
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsStringAsync().Result;


                courses = JsonConvert.DeserializeObject<IList<AssignedCourse>>(readTask);
            }


            return View(courses);
        }

        public ActionResult addTeacher()
        {
            IList<Teacher> teachers = null;

            HttpClient client = _api.Initial();

            //HTTP GET
            var responseTask = client.GetAsync("api/Teachers");
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsStringAsync().Result;


                teachers = JsonConvert.DeserializeObject<IList<Teacher>>(readTask);
            }

            return View(teachers);
        }
        

        // GET: AssignedCoursesController/Details/5
        public ActionResult Details(int id)
        {
            AssignedCourse course = new AssignedCourse();

            HttpClient client = _api.Initial();

            //HTTP GET
            var responseTask = client.GetAsync($"api/AssignedCourses/{id}");
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsStringAsync().Result;


                course = JsonConvert.DeserializeObject<AssignedCourse>(readTask);
            }

            return View(course);
        }

        // GET: AssignedCoursesController/Create
        public ActionResult Create()
        {
            IList<Teacher> teachers = _api.getTeachers();
            IList<Course> courses = _api.getCourses();
            ViewData["teachers"] = teachers;
            ViewData["courses"] = courses;



            return View();
        }

        // POST: AssignedCoursesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AssignedCourse assignedCourse, int id)
        {

            int teacherId = int.Parse(Request.Form["teacher"]);
            

            Teacher teacher = _api.getTeachers().ToList().Find(tr => tr.Id == teacherId);
            int courseId = int.Parse(Request.Form["course"]);
            Course course = _api.getCourses().ToList().Find(tr => tr.Id == courseId);

            assignedCourse.teacher = teacher;
            assignedCourse.course = course;

            try
            {
                HttpClient client = _api.Initial();
            //    StringContent content = new StringContent(JsonConvert.SerializeObject(assignedCourse), Encoding.UTF8, "application/json");

                var postTask = client.PostAsJsonAsync<AssignedCourse>("api/AssignedCourses", assignedCourse);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");


                    return View(assignedCourse);
                }
            }
            catch
            {

                return View();
            }
        }

            // GET: AssignedCoursesController/Edit/5
        public ActionResult Edit(int id)
        {
            AssignedCourse course = null;

            HttpClient client = _api.Initial();

            //HTTP GET
            var responseTask = client.GetAsync($"api/AssignedCourses/{id}");
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsStringAsync().Result;


                course = JsonConvert.DeserializeObject<AssignedCourse>(readTask);
            }

            return View(course);
        }

        // POST: AssignedCoursesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AssignedCourse course)
        {
            HttpClient client = _api.Initial();
            var putTask = client.PutAsJsonAsync<AssignedCourse>($"api/AssignedCourses/{id}", course);
            putTask.Wait();

            var result = putTask.Result;
            if (result.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

                return View(course);
            }
        }

        // GET: AssignedCoursesController/Delete/5
        public ActionResult Delete(int id)
        {
            AssignedCourse course = null;

            HttpClient client = _api.Initial();

            //HTTP GET
            var responseTask = client.GetAsync($"api/AssignedCourses/{id}");
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsStringAsync().Result;


                course = JsonConvert.DeserializeObject<AssignedCourse>(readTask);
            }

            return View(course);
        }

        // POST: AssignedCoursesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, AssignedCourse course)
        {
            try
            {
                HttpClient client = _api.Initial();
                var deleteTask = client.DeleteAsync($"api/AssignedCourse/{id}");
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }

            }
            catch
            {
                return View();
            }
            return RedirectToAction("Index");
        }
    }

   
}
