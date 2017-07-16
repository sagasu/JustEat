using CodingExercise.Logic.Factories.ClientFactory;
using NUnit.Framework;

namespace CodingExercise.Logic.Tests.Factories
{
    [TestFixture]
    public class RestaurantClientFactoryTests
    {
        [Test]
        public void Create_CreateRestClientWithDesiredURL()
        {
            var rcf = new RestaurantClientFactory();
            var restClient = rcf.Create();
            
            Assert.AreEqual("http://www.google.com/", restClient.BaseUrl.ToString());
        }
    }
}
