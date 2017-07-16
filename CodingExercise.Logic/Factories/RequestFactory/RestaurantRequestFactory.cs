using RestSharp;

namespace CodingExercise.Logic.Factories.RequestFactory
{
    public class RestaurantRequestFactory : IRequestFactory
    {
        public IRestRequest GetRestaurantRequestByOutcode(string outcode)
        {
            var request = new RestRequest("restaurants", Method.GET);
            var parameter = CreateParameterFromOutcode(outcode);
            
            request.AddParameter(parameter);
            
            request.AddHeader("Accept-Tenant", "uk");
            request.AddHeader("Accept-Language", "en-GB");
            request.AddHeader("Authorization", "Basic VGVjaFRlc3RBUEk6dXNlcjI=");

            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };

            return request;
        }

        private Parameter CreateParameterFromOutcode(string outcode)
        {
            return new Parameter{Name = "q", Value = outcode, Type = ParameterType.QueryString };
        }
    }
}
