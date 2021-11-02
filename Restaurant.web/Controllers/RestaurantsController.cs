using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestaurantLibrary;
using RestaurantLibrary.Models;

namespace Restaurant.web.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly IRestaurant _db;

        public RestaurantsController(IRestaurant db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = _db.GetAll();

            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = _db.Get(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RestaurantLibrary.Models.Restaurant restaurant)
        {

            if (ModelState.IsValid)
            {
                _db.Add(restaurant);
                return RedirectToAction("Details", new{id = restaurant.ID});
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _db.Get(id);
            if (model == null)
            {
                return HttpNotFound();
            }
                
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RestaurantLibrary.Models.Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                _db.Update(restaurant);
                TempData["Message"] = "You have saved the restaurant";
                return RedirectToAction("Details", new { id = restaurant.ID });
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = _db.Get(id);
            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        [HttpPost] 
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection form)
        {
            _db.Delete(id);
            return RedirectToAction("Index");
        }

    }
}