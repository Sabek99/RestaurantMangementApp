using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantLibrary.Models;

namespace RestaurantLibrary
{
    public interface IRestaurant
    {
        IEnumerable<Restaurant> GetAll();
        Restaurant Get(int id);
        void Add(Restaurant restaurant);
        void Update(Restaurant restaurant);

        void Delete(int id);
    }
}
