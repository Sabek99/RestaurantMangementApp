using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RestaurantLibrary.Models
{
    public class Restaurant
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Display(Name = "Type of food")]
        public Cuisine Cuisine { get; set; }

    }
}
