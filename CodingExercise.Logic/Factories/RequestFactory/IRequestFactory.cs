using RestSharp;

namespace CodingExercise.Logic.Factories.RequestFactory
{
    public interface IRequestFactory
    {
        IRestRequest GetRestaurantRequestByOutcode(string outcode);
    }
}