using System.Collections.Generic;
using CodingExercise.Logic.Models;

namespace CodingExercise.Logic.Services
{
    public interface IJustEatService
    {
        /// <returns>Empty list of restaurants if nothing found, otherwise found restaurants.</returns>
        IEnumerable<Restaurant> GetRestaurantsByOutcode(string outcode);
    }
}