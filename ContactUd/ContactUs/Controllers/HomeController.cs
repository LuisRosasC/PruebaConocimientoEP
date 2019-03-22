using ContactUs.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ContactUs.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public async Task<ActionResult> Contact()
        {
            ViewBag.IdentificationTypes = await GetIdentificationType();
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Contact(Models.ContactUs contactUs)
        {
            if (ModelState.IsValid)
                await InsertContactUs(contactUs);
            return await Contact();
        }

        private string GetBaseURL() =>
            "http://localhost:50410/api/contactUs/";

        private async Task<List<IdentificationType>> GetIdentificationType()
        {
            var identificationTypes = new List<IdentificationType>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(GetBaseURL());
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage clientReponse = await client.GetAsync("identificationType");
                if (clientReponse.IsSuccessStatusCode)
                {
                    var identificationTypesReponses = clientReponse.Content.ReadAsStringAsync().Result;
                    identificationTypes = JsonConvert.DeserializeObject<List<IdentificationType>>(identificationTypesReponses);
                }
            }
            return identificationTypes;
        }

        protected async Task InsertContactUs(Models.ContactUs contactUs)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(GetBaseURL());
                HttpResponseMessage response = await client.PostAsJsonAsync("contactUs", contactUs);
                response.EnsureSuccessStatusCode();
            }
        }
    }
}