using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DevoxxBooksFront.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DevoxxBooksFront.Controllers
{
    public class BookController : Controller
    {
        private const string URL = "http://localhost:5000";
        private HttpClient client = null;
       
        public async Task<IActionResult> Index(){
            List<BookModel> books = new List<BookModel>();
            ManageClientHttp();
            string uri = URL+ "/api/Books/GetAll/";
            using(var result = await client.GetAsync(uri))
            {
                string response = await result.Content.ReadAsStringAsync();
                books = JsonConvert.DeserializeObject<List<BookModel>>(response) ;
            }
            return View(books);
        }

        public IActionResult Create(){
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookModel book){
            ManageClientHttp();
            string contentJson = JsonConvert.SerializeObject(book);
            string uri = URL + "/api/Books/Create";
            HttpResponseMessage response = await client.PostAsync(uri, new StringContent(contentJson, Encoding.UTF8,"application/json"));
             if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");
            else 
                return View();
        }

        public async Task<IActionResult> Delete(int bookId){
            ManageClientHttp();
            string uri = URL+"/api/Books/Delete?bookId="+bookId;
            HttpResponseMessage response = await client.DeleteAsync(uri);
            return RedirectToAction("Index");
        }

        private void ManageClientHttp(){
            client = new HttpClient()
            {
                BaseAddress = new System.Uri(URL)
            };
            client.DefaultRequestHeaders.Accept.Add(
            new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}