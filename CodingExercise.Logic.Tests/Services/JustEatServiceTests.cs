using System.Collections.Generic;
using System.Linq;
using System.Net;
using CodingExercise.Logic.Factories.ClientFactory;
using CodingExercise.Logic.Factories.RequestFactory;
using CodingExercise.Logic.Models;
using CodingExercise.Logic.Services;
using CodingExercise.Logic.Tests.Data;
using Moq;
using NUnit.Framework;
using RestSharp;

namespace CodingExercise.Logic.Tests.Services
{
    [TestFixture]
    public class JustEatServiceTests
    {
        [Test]
        public void GetRestaurantsByOutcode_WhenStatusCodeOK_ExpectRestaurants()
        {
            const string anyOutcode = "SE";
            var fakeResponse = DataGenerator.GetRestaurantsResponse();
            
            var clientFactoryMock = GetClientFactory(fakeResponse, HttpStatusCode.OK);
            var requestFactoryMock = new Mock<IRequestFactory>();

            var restaurants = new JustEatService(clientFactoryMock.Object, requestFactoryMock.Object)
                                    .GetRestaurantsByOutcode(anyOutcode).ToList();

            Assert.That(fakeResponse.Restaurants, Is.EquivalentTo(restaurants));
        }

        [Test]
        public void GetRestaurantsByOutcode_WhenNotFoundResponse_ExpectEmptyRestaurantCollection()
        {
            const string anyOutcode = "SE";
            var fakeResponse = DataGenerator.GetRestaurantsResponse();

            var clientFactoryMock = GetClientFactory(fakeResponse, HttpStatusCode.NotFound);
            var requestFactoryMock = new Mock<IRequestFactory>();

            var restaurants = new JustEatService(clientFactoryMock.Object, requestFactoryMock.Object)
                .GetRestaurantsByOutcode(anyOutcode).ToList();

            Assert.That(new List<Restaurant>(), Is.EquivalentTo(restaurants));
        }

        [Test]
        public void GetRestaurantsByOutcode_WhenNoRestaurantsReturned_ExpectEmptyRestaurantCollection()
        {
            const string anyOutcode = "SE";
            var fakeResponse = DataGenerator.GetEmptyResponse();

            var clientFactoryMock = GetClientFactory(fakeResponse, HttpStatusCode.NotFound);
            var requestFactoryMock = new Mock<IRequestFactory>();

            var restaurants = new JustEatService(clientFactoryMock.Object, requestFactoryMock.Object)
                .GetRestaurantsByOutcode(anyOutcode).ToList();

            Assert.That(new List<Restaurant>(), Is.EquivalentTo(restaurants));
        }

        private Mock<IClientFactory> GetClientFactory(RestaurantsRoot fakeData, HttpStatusCode statusCode)
        {
            var restClientMock = new Mock<IRestClient>();
            var clientFactoryMock = new Mock<IClientFactory>();

            restClientMock
                .Setup(client => client.Execute<RestaurantsRoot>(It.IsAny<IRestRequest>()))
                .Returns(new RestResponse<RestaurantsRoot>{
                    StatusCode = statusCode,
                    Data = fakeData
                });

            clientFactoryMock
                .Setup(factory => factory.Create())
                .Returns(restClientMock.Object);

            return clientFactoryMock;
        }
    }
}
