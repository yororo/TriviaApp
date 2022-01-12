using Microsoft.Extensions.DependencyInjection;
using TriviaApp.Data.Model.Interface;
using TriviaApp.Data.Source.API.OpenTriviaAPI;

namespace TriviaApp.Data.Service.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddDataServiceServices(this IServiceCollection service)
        {
            service.AddSingleton<IDataServiceApi, DataServiceOpenTriviaApi>();
        }
    }
}
