using FlixOne.InventoryManagement.Interfaces;
using FlixOne.InventoryManagement.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FlixOne.InventoryManagementClient {
    internal class Program {
        static void Main(string[] args) {
            var services = new ServiceCollection();
            ConfigureServices(services);
            var provider = services.BuildServiceProvider();
            var catalog = provider.GetService<ICatalogService>();
            catalog.Run();

            Console.WriteLine("CatalogService has completed.");
        }

        static void ConfigureServices(IServiceCollection services) {
            services.AddTransient<IUserInterface, ConsoleUserInterface>();
            services.AddTransient<ICatalogService, CatalogService>();
            services.AddTransient<IInventoryCommandFactory, InventoryCommandFactory>();
        }
    }
}
