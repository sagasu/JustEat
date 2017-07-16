using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CodingExercise.Logic.Models;

namespace CodingExercise.Web.Models
{
    public class RestaurantViewModel
    {
        public IEnumerable<Restaurant> Restaurants { get; set; }

        [Required(ErrorMessage = "Please provide an outcode")]
        public string Outcode { get; set; }
    }
}