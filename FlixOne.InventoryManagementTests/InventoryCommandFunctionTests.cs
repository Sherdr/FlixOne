using FlixOne.InventoryManagement.Interfaces;
using FlixOne.InventoryManagement.Repositories;
using FlixOne.InventoryManagement.Services.Commands;
using FlixOne.InventoryManagementTests.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace FlixOne.InventoryManagementTests
{
    [TestClass]
    public class InventoryCommandFunctionTests {
        ServiceProvider Services { get; set; }

        [TestInitialize]
        public void Startup() {
            var expectedInterface = new TestUserInterface(
                new List<(string, string)>(),
                new List<string>(),
                new List<string>()
            );
            var services = new ServiceCollection();
            services.AddSingleton<IInventoryContext, InventoryContext>();
            services.AddTransient<Func<string, InventoryCommand>>(InventoryCommand.GetInventoryCommand);
            Services = services.BuildServiceProvider();
        }

        [TestMethod]
        public void QuitCommand_Successful() {
            Assert.IsInstanceOfType(Services.GetService<Func<string, InventoryCommand>>().Invoke("q"),
                typeof(QuitCommand), "q should be QuitCommand");
            Assert.IsInstanceOfType(Services.GetService<Func<string, InventoryCommand>>().Invoke("quit"),
                typeof(QuitCommand), "quit should be QuitCommand");
        }

        [TestMethod]
        public void AddInventoryCommand_Successful() {
            Assert.IsInstanceOfType(Services.GetService<Func<string, InventoryCommand>>().Invoke("a"),
                typeof(AddInventoryCommand), "a should be AddInventoryCommand");
            Assert.IsInstanceOfType(Services.GetService<Func<string, InventoryCommand>>().Invoke("addinventory"),
                typeof(AddInventoryCommand), "addinventory should be AddInventoryCommand");
        }

        [TestMethod]
        public void HelpCommand_Successful() {
            Assert.IsInstanceOfType(Services.GetService<Func<string, InventoryCommand>>().Invoke("?"),
                typeof(HelpCommand), "? should be HelpCommand");
        }

        [TestMethod]
        public void UnknownCommand_Successful() {
            Assert.IsInstanceOfType(Services.GetService<Func<string, InventoryCommand>>().Invoke(""),
                typeof(UnknownCommand), "space should be UnknownCommand");
            Assert.IsInstanceOfType(Services.GetService<Func<string, InventoryCommand>>().Invoke("123"),
                typeof(UnknownCommand), "123 should be UnknownCommand");
        }

        [TestMethod]
        public void UpdateQuantityCommand_Successful() {
            Assert.IsInstanceOfType(Services.GetService<Func<string, InventoryCommand>>().Invoke("u"),
                typeof(UpdateQuantityCommand), "u should be UpdateQuantityCommand");
            Assert.IsInstanceOfType(Services.GetService<Func<string, InventoryCommand>>().Invoke("updatequantity"),
                typeof(UpdateQuantityCommand), "updatequnatity should be UpdateQuantityCommand");
        }
    }
}
