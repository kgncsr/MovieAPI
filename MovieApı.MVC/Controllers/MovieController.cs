using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.ServiceTier.Dtos.Movie;

namespace MovieApı.MVC.Controllers
{
    public class MovieController : Controller
    {
        private readonly HttpClient m_httpClient;
        private string urllist = "https://localhost:44387/api/Movies/all";
        private string urlsave = "https://localhost:44387/api/Movies/save";
        public MovieController(HttpClient mHttpClient)
        {
            m_httpClient = mHttpClient;
        }
        public async Task<IActionResult> Index()
        {
            var products = await m_httpClient.GetFromJsonAsync<List<MovieDto>>(urllist);
            return View(products);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(MovieCreateDto movie)
        {
            HttpResponseMessage response = await m_httpClient.PostAsJsonAsync(urlsave, movie);
            if(response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
