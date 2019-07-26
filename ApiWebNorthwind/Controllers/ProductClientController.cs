using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApiWebNorthwind.Models;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace ApiWebNorthwind.Controllers
{
    public class ProductClientController : Controller
    {
        string BaseUrl = "http://localhost:5846/api/";
        public async Task<ActionResult> Index()
        {
            List<Product> prodInfo = new List<Product>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/jason"));
                /*** Call all the client 
                                         ***/
                HttpResponseMessage Res = await client.GetAsync("Product");
                if (Res.IsSuccessStatusCode)
                {
                    var ProdResponse = Res.Content.ReadAsStringAsync().Result;
                    prodInfo = JsonConvert.DeserializeObject<List<Product>>(ProdResponse);

                }
                return View(prodInfo);
                                       
            }
        }
        // GET: ProductClient
      /*  public ActionResult Index()
        {
            return View();
        }*/
    }
}