using System.Configuration;
using RestSharp;

namespace CodingExercise.Logic.Factories.ClientFactory
{
    public class RestaurantClientFactory : IClientFactory
    {
        public IRestClient Create()
        {
            return new RestClient(ConfigurationManager.AppSettings["JustEatURL"]);
        }
    }
}
