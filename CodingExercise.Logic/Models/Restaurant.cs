using System.Collections.Generic;

namespace CodingExercise.Logic.Models
{
    public class Restaurant
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Postcode { get; set; }

        public string City { get; set; }

        public List<CuisineType> CuisineTypes { get; set; }

        public string Url { get; set; }

        public double RatingStars { get; set; }

        public int NumberOfRatings { get; set; }
    }
}
