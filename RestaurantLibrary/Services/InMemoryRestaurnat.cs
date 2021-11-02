using System.Collections.Generic;
using System.Linq;
using RestaurantLibrary.Models;

namespace RestaurantLibrary
{
    public class InMemoryRestaurant : IRestaurant
    {
         List<Restaurant> restaurants;

        public InMemoryRestaurant()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant() {ID = 1, Name = "kosharey", Cuisine = Cuisine.Egyptian},
                new Restaurant() {ID = 2, Name = "Burger", Cuisine = Cuisine.English},
                new Restaurant() {ID = 3, Name = "Pizza", Cuisine = Cuisine.Italian},

            };
        }
        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants;
        }

        public Restaurant Get(int id)
        {
            return restaurants.FirstOrDefault(r => r.ID == id);
        }

        public void Add(Restaurant restaurant)
        {
            restaurants.Add(restaurant);
            restaurant.ID = restaurants.Max(r => r.ID) + 1;
        }

        public void Update(Restaurant restaurant)
        {
            var existing = Get(restaurant.ID);
            if (existing != null)
            {
                
                existing.Name = restaurant.Name;
                existing.Cuisine = restaurant.Cuisine;
            }
           
        }

        public void Delete(int id)
        {
            var model = Get(id);
            if (model != null)
            {
                restaurants.Remove(model);
            }
        }
    }
}