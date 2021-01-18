using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using MongoDB.Bson;
using MongoDB.Driver;

using MongoDB.Driver.Linq;
using static WebApplication1.Models.Functions;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        AdminDetails admin;
        MongoClient client;
        IMongoDatabase database;
        Functions f = new Functions();

        public HomeController()
        {
            client = new MongoClient("mongodb://localhost:27017");
            database = client.GetDatabase("admin"); 
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Recommendations()
        {
            string error = "";
            try
            {
                 error = RouteData.Values["id"].ToString();
            }
            catch (Exception e) { }
            var collc = database.GetCollection<IceCreamParlor>("Store");     
            try
            {
                List<IceCreamParlor> iceCreamParlor = collc.Find(x => x.Id.Length > 0).ToList<IceCreamParlor>();

                if (error == "")
                    return View(iceCreamParlor);
                if (error.Equals("error"))
                {
                    ViewBag.Message = "error";
                    return View(iceCreamParlor);
                }
            }
            catch (Exception e)
            {
                return View();
            }
            ViewBag.Message = "Your recommenditons page.";

            return View();
        }

        public JsonResult getProducts(string a)
        {      

            var collc = database.GetCollection<IceCream>("Product");
            List<IceCream> iceCream = collc.Find(x => x.StoreAddress == "herzel, ramat gan").ToList<IceCream>();
            
            return Json(iceCream, JsonRequestBehavior.AllowGet);
        }
//C:\Users\chava\Desktop\projects\sofi\sofi\3\WebApplication1\WebApplication1\WebApplication1\Controllers\HomeController.cs;
        public ActionResult AddStore()
        {
            ViewBag.Message = "Your dessert page.";

            return View();
        }
   
        public ActionResult Search()
        {
            ViewBag.Message = "Your search page.";

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddRecommendation()
        {
            Recommendations recommendations = new Recommendations();
            recommendations.FirstName = Request.Form["FirstName"];
            recommendations.LastName = Request.Form["LastName"];
            recommendations.Message = Request.Form["Message"];
            recommendations.ProductId = Request.Form["productId"];
            recommendations.StoreId = (Request.Form["storeId"].ToString()).Split('-')[1];
            recommendations.Rate = Int32.Parse(Request.Form["Rate"]);
            recommendations.Email = Request.Form["Email"];
            recommendations.Image = Request.Form["Image"];
      

            var collc = database.GetCollection<Recommendations>("Recommendation");
            await f.RunAsync(recommendations.Image);
            bool isIceCream = Models.Functions.IsIceCream;
            try
            {
                if (!isIceCream)
                    throw new Exception();

                //IceCream ice= database.GetCollection<IceCream>("Product").Find(x => recommendations.ProductId==x.Id);

                await collc.InsertOneAsync(recommendations);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception e)
            {
                return RedirectToAction("Recommendations", "Home", new { @id = "error" });
            }
        }

     
        public ActionResult Error()
        {
            ViewBag.Message = "Your search page.";

            return View();
        }
    }

}