using API_CRUD_FINAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;
using System.Web.WebSockets;

namespace API_CRUD_FINAL.Controllers
{
    public class MvcFinalController : Controller
    {
        HttpClient client = new HttpClient();
        // GET: MvcFinal
        public ActionResult Index()
        {
            List<apitbl> emp_details = new List<apitbl>();
            client.BaseAddress = new Uri("https://localhost:44342/api/ApiFinal");

            var response = client.GetAsync("ApiFinal");
            response.Wait();
            var test = response.Result;

          if(test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<apitbl>>();
				display.Wait();
                emp_details = display.Result;
			}
            return View(emp_details);
        }

		//create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(apitbl e)
        {
			client.BaseAddress = new Uri("https://localhost:44342/api/ApiFinal");

			var response = client.PostAsJsonAsync("ApiFinal",e);
			response.Wait();
			var test = response.Result;

			if (test.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
            return Create();
        }

		//Detail or Retrieving selective data
        public ActionResult Details(int id)
        {
			client.BaseAddress = new Uri("https://localhost:44342/api/ApiFinal");

            apitbl empret= new apitbl();    

			var response = client.GetAsync("ApiFinal?id=" + id.ToString());
			response.Wait();
			var test = response.Result;

			if (test.IsSuccessStatusCode)
			{
				var display = test.Content.ReadAsAsync<apitbl>();
                display.Wait();
                empret = display.Result;
			}
			return View(empret);
		}

		//Edit
        public ActionResult Edit(int id)
        {
			client.BaseAddress = new Uri("https://localhost:44342/api/ApiFinal");

			apitbl empret = new apitbl();

			var response = client.GetAsync("ApiFinal?id=" + id.ToString());
			response.Wait();
			var test = response.Result;

			if (test.IsSuccessStatusCode)
			{
				var display = test.Content.ReadAsAsync<apitbl>();
				display.Wait();
				empret = display.Result;
			}
			return View(empret);
		}

		[HttpPost]
		public ActionResult Edit(apitbl estore)
		{
			client.BaseAddress = new Uri("https://localhost:44342/api/ApiFinal");

			var response = client.PutAsJsonAsync("ApiFinal", estore);
			response.Wait();
			var test = response.Result;

			if (test.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		//Delete

		[HttpGet]
		public ActionResult Delete(int id)
		{
			client.BaseAddress = new Uri("https://localhost:44342/api/ApiFinal");

			apitbl empret = new apitbl();

			var response = client.GetAsync("ApiFinal?id=" + id.ToString());
			response.Wait();
			var test = response.Result;

			if (test.IsSuccessStatusCode)
			{
				var display = test.Content.ReadAsAsync<apitbl>();
				display.Wait();
				empret = display.Result;
			}
			return View(empret);
		}

		[HttpPost, ActionName("Delete")]
		public ActionResult Deleteconfirm(int id)
		{
			client.BaseAddress = new Uri("https://localhost:44342/api/ApiFinal");

			var response = client.DeleteAsync("ApiFinal?id=" + id.ToString());
			response.Wait();

			var test = response.Result;

			if (test.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View("Delete");
		}

	}
}