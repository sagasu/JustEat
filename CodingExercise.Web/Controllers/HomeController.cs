using System.Linq;
using System.Web.Mvc;
using CodingExercise.Logic.Services;
using CodingExercise.Web.Models;

namespace CodingExercise.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IJustEatService _service;

        public HomeController(IJustEatService service)
        {
            _service = service;
        }

        public ActionResult Index()
        {
            return View(new RestaurantViewModel());
        }

        [HttpPost]
        public ActionResult SearchForRestaurant(RestaurantViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }
            
            return RedirectToAction("SearchForRestaurant", new { outcode = model.Outcode });
        }

        [HttpGet]
        public ActionResult SearchForRestaurant(string outcode)
        {
            var restaurants = _service.GetRestaurantsByOutcode(outcode);

            var viewModel = new RestaurantViewModel
            {
                Restaurants = restaurants,
                Outcode = outcode
            };

            return View(viewModel);
        }

        public ActionResult DisplayRestaurants(RestaurantViewModel model)
        {
            return model.Restaurants.Any() ? 
                PartialView("~/Views/Partials/DisplayRestaurants.cshtml", model) :
                PartialView("~/Views/Partials/NoRestaurants.cshtml", model.Outcode);
        }
    }
}