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
        private string url = "https://localhost:44387/api/Movies/all";
        public MovieController(HttpClient mHttpClient)
        {
            m_httpClient = mHttpClient;
        }
        public async Task<IActionResult> Index()
        {
            var products = await m_httpClient.GetFromJsonAsync<List<MovieDto>>(url);
            return View(products);
        }
    }
}
