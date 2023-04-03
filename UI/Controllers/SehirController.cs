using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class SehirController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public SehirController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public IActionResult Index()
        {
            var client = _clientFactory.CreateClient("api");
            var response =  client.GetAsync("sehirler");

            if (response.IsCompletedSuccessfully)
            {
                //var content =  response.Content.ReadAsStringAsync();
                //var sehirler = JsonConvert.DeserializeObject<List<Sehir>>(content);

                return View();
            }

            return View();
        }
    }
}
