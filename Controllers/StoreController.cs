using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class StoreController : Controller
    {
        IceCreamParlor store;
        MongoClient client;
        IMongoDatabase database;
        Functions f = new Functions();
        public static bool fromDisplay = false;
        public static string CardsList = "cards";
        public static string SortBy = "no change";
        public static string Des = null;
        public static bool Search_nutrients = false;
        public static float Protein = float.MaxValue;
        public static float Lipid = float.MaxValue;
        public static float Energy = float.MaxValue;
        public StoreController()
        {
            client = new MongoClient("mongodb://localhost:27017");
            database = client.GetDatabase("admin");
        }

        // GET: Store
        public ActionResult Index()
        {
            return View();
        }



        // GET: IceCream
        public ActionResult Search()
        {
            IceCream ice = new IceCream();
            if (Request.Form["flavor"] == null && Request.Form["proteins"] == null && Request.Form["lipid"] == null && Request.Form["energy"] == null)
                     return View();
          
            

            List<IceCream> iceCream;
            var collc = database.GetCollection<IceCream>("Product");

            ice.Description = Request.Form["flavor"].ToString();
            if (ice.Description.Length != 0)
            {  
                iceCream = collc.Find(x => x.Description.Contains(ice.Description)).ToList<IceCream>();
                ViewBag.Error = "";
                if (iceCream.Count() == 0)
                    return View();
                return View(iceCream);
            }
            if (Request.Form["proteins"].Length == 0 && Request.Form["lipid"].Length == 0 && Request.Form["energy"].Length == 0)
            {
                iceCream = collc.Find(i => i.StoreAddress.Length > 0).ToList<IceCream>();
                iceCream = iceCream.OrderBy(i => i.Rate).ToList();
                return View(iceCream);
            }
            ice.Protein = float.Parse(Request.Form["proteins"].ToString());
            ice.Lipid = float.Parse(Request.Form["lipid"].ToString());
            ice.Energy = float.Parse(Request.Form["energy"].ToString());

            float protein = ice.Protein;
            float lipid = ice.Lipid;
            float energy = ice.Energy;
            if (Int32.Parse(protein.ToString()) > 0 && Int32.Parse(energy.ToString()) > 0 && Int32.Parse(lipid.ToString()) > 0)
            {
                iceCream = collc.Find(i => i.Protein <= protein && i.Lipid <= lipid && i.Energy <= energy).ToList<IceCream>();
                return View(iceCream);
            }
            else
            {
                return View();
            }
            
        }

        public ActionResult AddStore()
        {
            if(Session["LoginCredentials"] == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View();
        }

        public async Task < ActionResult > AddProduct()
        {
            if (Session["LoginCredentials"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var collc = database.GetCollection<IceCreamParlor>("Store");
            try
            {
                List<IceCreamParlor> iceCreamParlor = collc.Find(x => x.Id.Length > 0).ToList<IceCreamParlor>();
                return View(iceCreamParlor);
            }
            catch (Exception e)
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddStoreProduct(IceCream iceCream)
        {
            try
            {
                await f.Nutrients(iceCream.NdbNumber);
                iceCream.Protein = Functions.protein;
                iceCream.Lipid = Functions.lipid;
                iceCream.Energy = Functions.energy;
            }
            catch
            {
                iceCream.Protein = -1;
                iceCream.Lipid = -1;
                iceCream.Energy = -1;
            }
            iceCream.Description = Request.Form["flavor"];
            iceCream.NdbNumber = Request.Form["productId"];
            iceCream.StoreAddress = (Request.Form["storeAddress"]);
            iceCream.Image = Request.Form["image"];

            var collc = database.GetCollection<IceCream>("Product");
            //ADD FIND EXCITING PRODUCT
            try
            {
                await collc.InsertOneAsync(iceCream);
                return RedirectToAction("AddProduct", "Store");
            }
            catch (Exception e)
            {
                return RedirectToAction("AddProduct", "Store");
            }
        }
       
        public ActionResult AddStoreToDB()
        {
            IceCreamParlor iceCreamParlor = new IceCreamParlor();
            iceCreamParlor.Id = Request.Form["Id"];
            iceCreamParlor.Address = Request.Form["Address"];
            iceCreamParlor.PhoneNumber = Request.Form["PhoneNumber"];
            iceCreamParlor.ImagePath = Request.Form["uploadedfile"].ToString();
            

            var collc = database.GetCollection<IceCreamParlor>("Store");
            try
            {
                collc.InsertOneAsync(iceCreamParlor);
                return RedirectToAction("AddProduct", "Store");
            }
            catch (Exception e)
            {
                return RedirectToAction("Login");
            }
        }

        // GET: Store/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Store/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Store/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Store/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Store/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Store/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Store/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult ViewMap()
        {
            Console.WriteLine("*********");
            return View();
        }

    }
}
