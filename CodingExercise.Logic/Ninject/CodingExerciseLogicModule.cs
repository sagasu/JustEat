using CodingExercise.Logic.Factories.ClientFactory;
using CodingExercise.Logic.Factories.RequestFactory;
using CodingExercise.Logic.Services;
using Ninject.Modules;

namespace CodingExercise.Logic.Ninject
{
    public class CodingExerciseLogicModule : NinjectModule
    {        
        public override void Load()
        {
            Bind<IJustEatService>().To<JustEatService>();
            Bind<IClientFactory>().To<RestaurantClientFactory>();
            Bind<IRequestFactory>().To<RestaurantRequestFactory>();
        }
    }
}
