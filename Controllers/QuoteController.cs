using GradeHub.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace GradeHub.Controllers
{
    public class QuoteController : Controller
    {
        private readonly HttpClient _httpClient;
        public QuoteController()
        {
            _httpClient = new HttpClient();
        }

        // GET: QuoteController
        public async Task<IActionResult> Index()
        {
            Quote quote = await GetQuoteFromApi();
            return View(quote);  
        }

        // Fetch the quote from the API
        private async Task<Quote> GetQuoteFromApi()
        {
            string apiUrl = "https://zenquotes.io/api/random";
            Quote quote = new Quote();
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var quotes = JsonConvert.DeserializeObject<List<dynamic>>(result);

                if (quotes != null && quotes.Count > 0)
                {
                    quote.text = quotes[0].q;  
                    quote.author = quotes[0].a; 
                    quote.quotes = quotes[0].h; 
                }
            }

            return quote; 
        }
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
