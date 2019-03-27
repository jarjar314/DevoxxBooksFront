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
        //à changer en fonction de votre configuration 
        private const string URL = "http://localhost:5000";
        private HttpClient client = null;
       
        public async Task<IActionResult> Index(){          
            //initiez une liste de Model où Model est la classe de votre modèle
            ManageClientHttp();
            string uri = "todefinedbyyou";
            using(var result = await client.GetAsync(uri))
            {
                //utilisez une méthode de result qui permet de tout convertir en string
                //désérializer par la méthode JsonConvert.DeserializeObject la réponse précédemment récupérée
                string response = string.Empty;              
            }
              //doit être return View(listModels)
            return View();
        }

        public IActionResult Create(){
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookModel book){
            ManageClientHttp();
            //utilisez SerializeObject de JsonConvert pour convertir sérialiser en string votre objet
            string contentJson = string.Empty;
            string uri = "todefinedbyyou";
            //utilisez la méthode postAsync de votre httpclient
            HttpResponseMessage response = null;
             if (response.IsSuccessStatusCode)
                //utilisez la méthode redirectToAction pour retourner dans votre action Index
                return View();
            else 
                return View();
        }

        public async Task<IActionResult> Delete(int bookId){
            ManageClientHttp();
            string uri = "todefinedbyyou";
             //utilisez la méthode DeleteAsync de votre httpclient
            HttpResponseMessage response = null;
            return RedirectToAction("Index");
        }

        private void ManageClientHttp(){
            //en initiant le HttpClient initiez la variable BaseAddresse avec l'url de votre serveur back 
            client = new HttpClient()
            {
                BaseAddress = new System.Uri(URL)
            };
            client.DefaultRequestHeaders.Accept.Add(
            new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}