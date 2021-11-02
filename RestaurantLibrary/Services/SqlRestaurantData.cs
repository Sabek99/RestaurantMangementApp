using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantLibrary.Models;

namespace RestaurantLibrary.Services
{
    public class SqlRestaurantData : IRestaurant
    {
        private readonly RestaurantDbContext _db;

        public SqlRestaurantData(RestaurantDbContext db)
        {
            _db = db;
        }
        public IEnumerable<Restaurant> GetAll()
        {
            return
                from r in _db.Restaurants
                orderby r.Name
                select r;
        }

        public Restaurant Get(int id)
        {
           return _db.Restaurants.FirstOrDefault(r => r.ID == id);
        }

        public void Add(Restaurant restaurant)
        {
            _db.Restaurants.Add(restaurant);
            _db.SaveChanges();
        }

        public void Update(Restaurant restaurant)
        {
            var entry = _db.Entry(restaurant);
            entry.State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var model = _db.Restaurants.Find(id);
            _db.Restaurants.Remove(model);
            _db.SaveChanges();
            
           
        }
    }
}
