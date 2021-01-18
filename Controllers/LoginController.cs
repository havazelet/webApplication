using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        AdminDetails admin;
        MongoClient client;
        IMongoDatabase database;
        public LoginController()
        {
            client = new MongoClient("mongodb://localhost:27017");
            database = client.GetDatabase("admin");
        }

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }

        // GET: Login/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        [Obsolete]
        public ActionResult PostDetails()
        {
            string UserName = Request.Form["UserName"];
            string Password = Request.Form["Password"];
            var collc = database.GetCollection<AdminDetails>("Admin");
            try
            {
                var results = collc.Find(x => x.UserName == UserName && x.Password == Password);
                if (results.Count() == 1)
                {
                    admin = results.First();

                    FormsAuthentication.SetAuthCookie(admin.UserName, false); // set the formauthentication cookie  
                    Session["LoginCredentials"] = admin; // Bind the _logincredentials details to "LoginCredentials" session  
                    Session["UserName"] = admin.UserName;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("SignUp", "Login");
                }
            }
            catch (Exception e)
            {
                return RedirectToAction("SignUp", "Login");
            }

        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            return RedirectToAction("Index", "Home");
        }

        // POST: Login/Create
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

        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Login/Edit/5
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

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Login/Delete/5
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
    }
}
