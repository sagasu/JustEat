using System.Collections.Generic;
using CodingExercise.Logic.Models;

namespace CodingExercise.Logic.Tests.Data
{
    static class DataGenerator
    {
        public static RestaurantsRoot GetRestaurantsResponse()
        {
            return new RestaurantsRoot
            {
                Restaurants = new List<Restaurant>
                {
                    new Restaurant
                    {
                        Id = 48746,
                        Name = "Fat Boys Cafe",
                        Address = "306 Thornton Road",
                        Postcode = "CR0 3EU",
                        City = "London",
                        CuisineTypes = new List<CuisineType>
                        {
                            new CuisineType {
                                Id = 153,
                                Name = "Café",
                                SeoName = "cafe",
                            },
                            new CuisineType {
                                Id = 92,
                                Name = "Breakfast",
                                SeoName = "breakfast",
                            },
                        },
                        Url = "",
                        RatingStars = 4,
                        NumberOfRatings = 443
                    }
                }
            };
        }

        public static RestaurantsRoot GetEmptyResponse()
        {
            return new RestaurantsRoot
            {   
                Restaurants = new List<Restaurant>()
            };
        }
    }
}
