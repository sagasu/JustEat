using RestSharp;

namespace CodingExercise.Logic.Factories.ClientFactory
{
    public interface IClientFactory
    {
        IRestClient Create();
    }
}