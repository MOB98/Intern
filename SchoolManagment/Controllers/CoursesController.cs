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
    public class CoursesController : Controller
    {

        APICalling _api = new APICalling();

        // GET: CoursesController
        public ActionResult Index()
        {
            IList<Course> courses = null;

            HttpClient client = _api.Initial();

            //HTTP GET
            var responseTask = client.GetAsync("api/Courses");
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsStringAsync().Result;


                courses = JsonConvert.DeserializeObject<IList<Course>>(readTask);
            }


            return View(courses);
        }

        // GET: CoursesController/Details/5
        public ActionResult Details(int id)
        {
            Course course = new Course();

            HttpClient client = _api.Initial();

            //HTTP GET
            var responseTask = client.GetAsync($"api/Courses/{id}");
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsStringAsync().Result;


                course = JsonConvert.DeserializeObject<Course>(readTask);
            }

            return View(course);
        }

        // GET: CoursesController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: CoursesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course course)
        {
            try
            {
                HttpClient client = _api.Initial();
                StringContent content = new StringContent(JsonConvert.SerializeObject(course), Encoding.UTF8, "application/json");

                var postTask = client.PostAsJsonAsync<Course>("api/Courses", course);
                postTask.Wait();

                var result = postTask.Result;
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
            catch
            {

                return View();
            }
        }

        // GET: CoursesController/Edit/5
        public ActionResult Edit(int id)
        {
            Course course = null;

            HttpClient client = _api.Initial();

            //HTTP GET
            var responseTask = client.GetAsync($"api/Courses/{id}");
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsStringAsync().Result;


                course = JsonConvert.DeserializeObject<Course>(readTask);
            }

            return View(course);
        }

        // POST: CoursesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Course course)
        {
            HttpClient client = _api.Initial();
            var putTask = client.PutAsJsonAsync<Course>($"api/Courses/{id}", course);
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

        // GET: CoursesController/Delete/5
        public ActionResult Delete(int id)
        {

            Course course = null;

            HttpClient client = _api.Initial();

            //HTTP GET
            var responseTask = client.GetAsync($"api/Courses/{id}");
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsStringAsync().Result;


                course = JsonConvert.DeserializeObject<Course>(readTask);
            }

            return View(course);
        }

        // POST: CoursesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Course course)
        {
            try
            {
                HttpClient client = _api.Initial();
                var deleteTask = client.DeleteAsync($"api/Courses/{id}");
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
