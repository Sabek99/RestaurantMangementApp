using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantLibrary.Models;

namespace RestaurantLibrary.Services
{
    public class RestaurantDbContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
