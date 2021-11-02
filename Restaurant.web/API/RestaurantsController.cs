using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestaurantLibrary;
using RestaurantLibrary.Models;

namespace Restaurant.web.API
{
    public class RestaurantsController : ApiController
    {
        private readonly IRestaurant _db;

        public RestaurantsController(IRestaurant db)
        {
            _db = db;
        }

        public IEnumerable<RestaurantLibrary.Models.Restaurant> Get()
        {
            var model = _db.GetAll();
            return model;
        }





    }
}
