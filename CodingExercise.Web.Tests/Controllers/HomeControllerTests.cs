using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CodingExercise.Logic.Models;
using CodingExercise.Logic.Services;
using CodingExercise.Web.Controllers;
using CodingExercise.Web.Models;
using Moq;
using NUnit.Framework;

namespace CodingExercise.Web.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTests
    {
        [Test]
        public void SearchForRestaurant_WhenModelIsInvalid_RedirectToIndexView()
        {
            var jeServiceMock = new Mock<IJustEatService>();
            var homeController = new HomeController(jeServiceMock.Object);
            homeController.ModelState.AddModelError("any exception", new Exception("any exception"));
            
            var actionResult = (ViewResult)homeController.SearchForRestaurant(new RestaurantViewModel());
            
            Assert.AreEqual("Index", actionResult.ViewName);
        }


        [Test]
        public void SearchForRestaurant_WhenModelIsValid_RedirectToSearchForRestaurantView()
        {
            var jeServiceMock = new Mock<IJustEatService>();
            var homeController = new HomeController(jeServiceMock.Object);
            
            var actionResult = (RedirectToRouteResult)homeController.SearchForRestaurant(new RestaurantViewModel());

            Assert.AreEqual("SearchForRestaurant", actionResult.RouteValues["action"]);
        }

        [Test]
        public void SearchForRestaurant_WhenOutcodeInModelIsSet_OutcodeIsPassedInRouteValue()
        {
            var jeServiceMock = new Mock<IJustEatService>();
            var homeController = new HomeController(jeServiceMock.Object);
            const string anyOutcode = "SE18";
            var restaurantViewModel = new RestaurantViewModel() { Outcode = anyOutcode};
            
            var actionResult = (RedirectToRouteResult)homeController.SearchForRestaurant(restaurantViewModel);

            Assert.AreEqual(anyOutcode, actionResult.RouteValues["outcode"]);
        }

        [Test]
        public void SearchForRestaurant_RestaurantsAndOutcomeIsSet_ViewModelWithExpectedData()
        {
            const string anyOutcode = "SE18";
            var restaurants = new List<Restaurant> { new Restaurant()};
            var expectedViewModel = new RestaurantViewModel {Outcode = anyOutcode, Restaurants = restaurants};

            var jeServiceMock = new Mock<IJustEatService>();
            jeServiceMock.Setup(client => client.GetRestaurantsByOutcode(anyOutcode))
                .Returns(() => restaurants);
            
            var homeController = new HomeController(jeServiceMock.Object);
          
            var actionResult = (ViewResult)homeController.SearchForRestaurant(anyOutcode);

            var restaurantViewModel = (RestaurantViewModel)actionResult.Model;
            
            Assert.AreEqual(expectedViewModel.Outcode, restaurantViewModel.Outcode);
        }

        [Test]
        public void SearchForRestaurant_ValidCallIsMade_ReturnsToDefaultViewModel()
        {
            const string anyOutcode = "SE18";
            var restaurants = new List<Restaurant> { new Restaurant()};

            var jeServiceMock = new Mock<IJustEatService>();
            jeServiceMock.Setup(client => client.GetRestaurantsByOutcode(anyOutcode))
                .Returns(() => restaurants);
            
            var homeController = new HomeController(jeServiceMock.Object);
          
            var actionResult = (ViewResult)homeController.SearchForRestaurant(anyOutcode);
            
            Assert.AreEqual("", actionResult.ViewName);
        }

        [Test]
        public void DisplayRestaurants_WhenRestaurantsArePresent_RedersDisplayRestaurantsPartialView()
        {
            const string anyOutcode = "SE18";
            var restaurants = new List<Restaurant> { new Restaurant() };
            var restaurantsViewModel= new RestaurantViewModel
            {
                Outcode = anyOutcode,
                Restaurants = restaurants
            };
            
            var jeServiceMock = new Mock<IJustEatService>();

            var homeController = new HomeController(jeServiceMock.Object);

            var actionResult = (PartialViewResult)homeController.DisplayRestaurants(restaurantsViewModel);

            Assert.AreEqual("~/Views/Partials/DisplayRestaurants.cshtml", actionResult.ViewName);
        }

        [Test]
        public void DisplayRestaurants_WhenNoRestaurantsArePresent_RedersNoRestaurantsPartialView()
        {
            const string anyOutcode = "SE18";
            var restaurants = new List<Restaurant>();
            var restaurantsViewModel= new RestaurantViewModel
            {
                Outcode = anyOutcode,
                Restaurants = restaurants
            };
            
            var jeServiceMock = new Mock<IJustEatService>();

            var homeController = new HomeController(jeServiceMock.Object);

            var actionResult = (PartialViewResult)homeController.DisplayRestaurants(restaurantsViewModel);

            Assert.AreEqual("~/Views/Partials/NoRestaurants.cshtml", actionResult.ViewName);
        }

        [Test]
        public void Index_WhenCorrectCallIsMade_ReturnsDefaultView()
        {
            var jeServiceMock = new Mock<IJustEatService>();

            var homeController = new HomeController(jeServiceMock.Object);

            var actionResult = (ViewResult)homeController.Index();

            Assert.AreEqual("", actionResult.ViewName);
        }

    }
}
