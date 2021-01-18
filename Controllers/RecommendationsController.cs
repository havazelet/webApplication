using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class RecommendationsController : Controller
    {
        // GET: Recommendations
        public ActionResult Index()
        {          
            return View();
        }

        // GET: Recommendations/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Recommendations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Recommendations/Create
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

        // GET: Recommendations/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Recommendations/Edit/5
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

        // GET: Recommendations/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Recommendations/Delete/5
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
