using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;
using UI.Models;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            HttpClient client= new HttpClient();
            var responseMessage = client.GetAsync("https://localhost:7210/api/Sehirr").Result;

            List<Sehir> sehir = null;
            if (responseMessage.StatusCode==System.Net.HttpStatusCode.OK)
            {
                sehir = JsonConvert.DeserializeObject<List<Sehir>>(responseMessage.Content.ReadAsStringAsync().Result);
            }
            return View(sehir);
        }

        public IActionResult Add()
        {
            return View(new Sehir());
        }

        


        [HttpPost]
        public IActionResult Add(Sehir sehir)
        {
            HttpClient httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(sehir), Encoding.UTF8,
                "application/json");
            var responseMessage = httpClient.PostAsync("https://localhost:7210/api/Sehirr", content).Result;

            //if (responseMessage.StatusCode == System.Net.HttpStatusCode.Created)
            //{
            //    return RedirectToAction("Index");
            //}
            //ModelState.AddModelError("", "Ekleme islemi başarısız");
            //return View();

            if (responseMessage.StatusCode == System.Net.HttpStatusCode.Created)
            {
                return RedirectToAction("Index");
            }
            else
            {
                var errorMessage = responseMessage.Content.ReadAsStringAsync().Result;
                ModelState.AddModelError("", $"Ekleme işlemi başarısız: {errorMessage}");
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            HttpClient httpClient = new HttpClient();
            var responseMessage = httpClient.GetAsync($"https://localhost:7210/api/Sehirr/{id}").Result;

            if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var sehir = JsonConvert.DeserializeObject<Sehir>(responseMessage.Content.ReadAsStringAsync().Result);
                return View(sehir);
            }
           return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(Sehir sehir)
        {
            HttpClient httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(sehir), Encoding.UTF8,
                "application/json");
            var responseMessage = httpClient.PutAsync($"https://localhost:7210/api/Sehirr/{sehir.Id}", content).Result;

              return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            HttpClient httpClient = new HttpClient();
            var responseMessage = httpClient.DeleteAsync($"https://localhost:7210/api/Sehirr/{id}").Result;

            
            return RedirectToAction("Index");
        }

    }
}