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
    public class TeachersController : Controller
    {
        //GET: TeachersController
       APICalling _api = new APICalling();
        public ActionResult Index()
        {



            IList<Teacher> teachers = null;

            HttpClient client = _api.Initial();

          //  HTTP GET
            var responseTask = client.GetAsync("api/Teachers");
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsStringAsync().Result;


                teachers = JsonConvert.DeserializeObject<IList<Teacher>>(readTask);
            }
            //else //web api sent error response 
            //{
            //   // log response status here..
            //        teachers = Enumerable.Empty<Teacher>();

            //    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            //}

            return View(teachers);
        }

      //  GET: StudentsController/Details/5
        public ActionResult Details(int id)
        {
            Teacher teacher = new Teacher();

            HttpClient client = _api.Initial();

            //HTTP GET
            var responseTask = client.GetAsync($"api/Teachers/{id}");
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsStringAsync().Result;


                teacher = JsonConvert.DeserializeObject<Teacher>(readTask);
            }

            return View(teacher);
        }

        //  GET: StudentsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Teacher teacher)
        {
            try
            {
                HttpClient client = _api.Initial();
                StringContent content = new StringContent(JsonConvert.SerializeObject(teacher), Encoding.UTF8, "application/json");

                var postTask = client.PostAsJsonAsync<Teacher>("api/Teachers", teacher);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                    return View(teacher);
                }
            }
            catch
            {
                return View();
            }
        }

        //  GET: StudentsController/Edit/5
        public ActionResult Edit(int id)
        {

            Teacher teacher = null;

            HttpClient client = _api.Initial();

            //    HTTP GET
            var responseTask = client.GetAsync($"api/Teachers/{id}");
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsStringAsync().Result;


                teacher = JsonConvert.DeserializeObject<Teacher>(readTask);
            }

            return View(teacher);
        }

        // POST: StudentsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Teacher teacher)
        {
            HttpClient client = _api.Initial();
            var putTask = client.PutAsJsonAsync<Teacher>($"api/Teachers/{id}", teacher);
            putTask.Wait();

            var result = putTask.Result;
            if (result.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

                return View(teacher);
            }
        }






        //GET: StudentsController/Delete/5
        public ActionResult Delete(int id)
        {

            Teacher teacher = null;

            HttpClient client = _api.Initial();

            //  HTTP GET
            var responseTask = client.GetAsync($"api/Teachers/{id}");
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsStringAsync().Result;


                teacher = JsonConvert.DeserializeObject<Teacher>(readTask);
            }

            return View(teacher);
        }

        // POST: StudentsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Teacher teacher)
        {
            try
            {
                HttpClient client = _api.Initial();
                var deleteTask = client.DeleteAsync($"api/Teachers/{id}");
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
