using System.Diagnostics;

namespace Ebd.Mobile
{
    public static class Startup
    {
        private static readonly Lazy<ServiceProvider> _serviceProvider = new Lazy<ServiceProvider>(CreateServiceProvider);

        public static ServiceProvider ServiceProvider => _serviceProvider.Value;

        private static ServiceProvider CreateServiceProvider()
        {
            return new ServiceCollection()
                .ConfigureServices()
                .ConfigureRepositories()
                .ConfigureViewModels()
                .BuildServiceProvider();
        }

        public static void Init()
        {
            Debug.WriteLine($"ServiceProvider is null: {ServiceProvider is null}");
        }
    }
}
