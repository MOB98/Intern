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
    public class StudentsController : Controller
    {

        // GET: StudentsController
        APICalling _api = new APICalling();
        public ActionResult Index()
        {



            IList<Student> students = null;

            HttpClient client = _api.Initial();

            //HTTP GET
            var responseTask = client.GetAsync("api/Students");
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsStringAsync().Result;


                students = JsonConvert.DeserializeObject<IList<Student>>(readTask);
            }
            //else //web api sent error response 
            //{
            //    //log response status here..

            //    students = (IList<Student>)Enumerable.Empty<Student>();

            //    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            //}

            return View(students);
        }

        // GET: StudentsController/Details/5
        public ActionResult Details(int id)
        {
            Student student = new Student();

            HttpClient client = _api.Initial();

            //HTTP GET
            var responseTask = client.GetAsync($"api/Students/{id}");
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsStringAsync().Result;


                student = JsonConvert.DeserializeObject<Student>(readTask);
            }

            return View(student);
        }

        // GET: StudentsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            try
            {
                HttpClient client = _api.Initial();
              //  StringContent content = new StringContent(JsonConvert.SerializeObject(student), Encoding.UTF8, "application/json");

                var postTask = client.PostAsJsonAsync<Student>("api/Students", student);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                    return View(student);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentsController/Edit/5
        public ActionResult Edit(int id)
        {

            Student student = null;

            HttpClient client = _api.Initial();

            //HTTP GET
            var responseTask = client.GetAsync($"api/Students/{id}");
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsStringAsync().Result;


                student = JsonConvert.DeserializeObject<Student>(readTask);
            }

            return View(student);
        }

        // POST: StudentsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Student student)
        {
            HttpClient client = _api.Initial();
            var putTask = client.PutAsJsonAsync<Student>($"api/Students/{id}", student);
            putTask.Wait();

            var result = putTask.Result;
            if (result.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

                return View(student);
            }
        }






        // GET: StudentsController/Delete/5
        public ActionResult Delete(int id)
        {

            Student student = null;

            HttpClient client = _api.Initial();

            //HTTP GET
            var responseTask = client.GetAsync($"api/Students/{id}");
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsStringAsync().Result;


                student = JsonConvert.DeserializeObject<Student>(readTask);
            }

            return View(student);
        }

        // POST: StudentsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id,Student student)
        {
            try
            {
                HttpClient client = _api.Initial();
                var deleteTask = client.DeleteAsync($"api/Students/{id}");
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
