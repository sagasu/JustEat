using System.Linq;
using CodingExercise.Logic.Factories.RequestFactory;
using NUnit.Framework;
using RestSharp;

namespace CodingExercise.Logic.Tests.Factories
{
    [TestFixture]
    public class RestaurantRequestFactoryTests
    {
        [Test]
        public void GetRestaurantRequestByOutcode_ExpectAcceptTenantInHeader()
        {
            const string anyOutcode = "SE19";
            var restaurantRequest = (RestRequest)new RestaurantRequestFactory().
                            GetRestaurantRequestByOutcode(anyOutcode);

            var acceptTenant = restaurantRequest.Parameters.FirstOrDefault(parameter => 
                parameter.Name == "Accept-Tenant" && 
                parameter.Type == ParameterType.HttpHeader)?.Value;
            
            Assert.AreEqual("uk", acceptTenant);
        }

        [Test]
        public void GetRestaurantRequestByOutcode_ExpectAcceptLanguageInHeader()
        {
            const string anyOutcode = "SE19";
            var restaurantRequest = (RestRequest)new RestaurantRequestFactory().
                            GetRestaurantRequestByOutcode(anyOutcode);

            var acceptLanguage = restaurantRequest.Parameters.FirstOrDefault(parameter => 
                parameter.Name == "Accept-Language" && 
                parameter.Type == ParameterType.HttpHeader)?.Value;
            
            Assert.AreEqual("en-GB", acceptLanguage);
        }

        [Test]
        public void GetRestaurantRequestByOutcode_ExpectAuthorizationInHeader()
        {
            const string anyOutcode = "SE19";
            var restaurantRequest = (RestRequest)new RestaurantRequestFactory().
                            GetRestaurantRequestByOutcode(anyOutcode);

            var authorization = restaurantRequest.Parameters.FirstOrDefault(parameter => 
                parameter.Name == "Authorization" && 
                parameter.Type == ParameterType.HttpHeader)?.Value;
            
            Assert.AreEqual("Basic VGVjaFRlc3RBUEk6dXNlcjI=", authorization);
        }

        [Test]
        public void GetRestaurantRequestByOutcode_WithProvidedOutcode_ExpectQueryParameterToBeSetToOutcomeValue()
        {
            const string anyOutcode = "SE19";
            var restaurantRequest = (RestRequest)new RestaurantRequestFactory().
                            GetRestaurantRequestByOutcode(anyOutcode);

            var queryParameter = restaurantRequest.Parameters.FirstOrDefault(parameter => 
                parameter.Name == "q" && 
                parameter.Type == ParameterType.QueryString)?.Value;
            
            Assert.AreEqual(anyOutcode, queryParameter);
        }

        [Test]
        public void GetRestaurantRequestByOutcode_ExpectOnBeforeDeserializationSetToJson()
        {
            const string anyOutcode = "SE19";
            var restaurantRequest = (RestRequest)new RestaurantRequestFactory().
                            GetRestaurantRequestByOutcode(anyOutcode);

            var onBeforeDeserializationContentType = restaurantRequest.JsonSerializer.ContentType;

            Assert.AreEqual("application/json", onBeforeDeserializationContentType);
        }

        [Test]
        public void GetRestaurantRequestByOutcode_ExpectSourceSetToRestaurants()
        {
            const string anyOutcode = "SE19";
            var restaurantRequest = (RestRequest)new RestaurantRequestFactory().
                            GetRestaurantRequestByOutcode(anyOutcode);

            var resource = restaurantRequest.Resource;

            Assert.AreEqual("restaurants", resource);
        }

        [Test]
        public void GetRestaurantRequestByOutcode_ExpectMethodSetToGET()
        {
            const string anyOutcode = "SE19";
            var restaurantRequest = (RestRequest)new RestaurantRequestFactory().
                            GetRestaurantRequestByOutcode(anyOutcode);

            var method = restaurantRequest.Method;

            Assert.AreEqual(Method.GET, method);
        }
    }
}
