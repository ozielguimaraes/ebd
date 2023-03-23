using Microsoft.Extensions.DependencyInjection;

namespace Ebd.Mobile
{
    public static class Startup
    {
        public static ServiceProvider ServiceProvider { get; private set; }

        public static void Init()
        {
            var provider = new ServiceCollection()
                .ConfigureServices()
                .ConfigureRepositories()
                .ConfigureViewModels()
                .BuildServiceProvider();

            ServiceProvider = provider;
        }
    }
}
