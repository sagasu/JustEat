using System.Collections.Generic;
using System.Net;
using CodingExercise.Logic.Factories.ClientFactory;
using CodingExercise.Logic.Factories.RequestFactory;
using CodingExercise.Logic.Models;
using RestSharp;

namespace CodingExercise.Logic.Services
{
    public class JustEatService : IJustEatService
    {
        private readonly IClientFactory _clientFactory;
        private readonly IRequestFactory _requestFactory;

        public JustEatService(IClientFactory clientFactory, IRequestFactory requestFactory)
        {
            _clientFactory = clientFactory;
            _requestFactory = requestFactory;
        }

        public IEnumerable<Restaurant> GetRestaurantsByOutcode(string outcode)
        {
            var client = _clientFactory.Create();
            var request = _requestFactory.GetRestaurantRequestByOutcode(outcode);

            var response = client.Execute<RestaurantsRoot>(request);

            return IsResponseCorrect(response) ? response.Data.Restaurants : new List<Restaurant>();
        }

        private static bool IsResponseCorrect(IRestResponse<RestaurantsRoot> response)
        {
            return response.StatusCode == HttpStatusCode.OK && response.Data?.Restaurants != null;
        }
    }
}
