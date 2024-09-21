using FlixOne.InventoryManagementTests.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace FlixOne.InventoryManagementTests.ImplementationFactory {
    [TestClass]
    public class ImplementationFactoryTests {
        public ServiceProvider Services { get; private set; }

        [TestInitialize]
        public void Startup() {
            var expectedInterface = new TestUserInterface(new List<(string, string)>(), new List<string>(), new List<string>());
            var services = new ServiceCollection();
            services.AddTransient<InventoryCommand, AddInventoryCommand>();
            services.AddTransient<InventoryCommand, GetInventoryCommand>();
            services.AddTransient<InventoryCommand, HelpCommand>();
            services.AddTransient<InventoryCommand, QuitCommand>();
            services.AddTransient<InventoryCommand, UpdateQuantityCommand>();
            //unknownCommand must to reg a last.
            services.AddTransient<InventoryCommand, UnknownCommand>();
            Services = services.BuildServiceProvider();
        }

        public InventoryCommand GetCommand(string input) {
            return Services.GetServices<InventoryCommand>().First(svc => svc.IsCommandFor(input));
        }

        [TestMethod]
        public void AddInventoryCommand_Successful() {
            Assert.IsInstanceOfType(GetCommand("a"), typeof(AddInventoryCommand), "a should be AddInventoryCommand.");
            Assert.IsInstanceOfType(GetCommand("addinventory"), typeof(AddInventoryCommand), "addinventory should be AddInventoryCommand.");
            Assert.IsInstanceOfType(GetCommand("AddInventory"), typeof(AddInventoryCommand), "AddInventory should be AddInventoryCommand.");
        }

        [TestMethod]
        public void GetInventoryCommand_Successful() {
            Assert.IsInstanceOfType(GetCommand("g"), typeof(GetInventoryCommand), "g should be GetInventoryCommand.");
            Assert.IsInstanceOfType(GetCommand("getinventory"), typeof(GetInventoryCommand), "getinventory should be GetInventoryCommand.");
            Assert.IsInstanceOfType(GetCommand("GetInventory"), typeof(GetInventoryCommand), "GetInventory should be GetInventoryCommand.");
        }

        [TestMethod]
        public void HelpCommand_Successful() {
            Assert.IsInstanceOfType(GetCommand("?"), typeof(HelpCommand), "? should be HelpCommand.");
        }

        [TestMethod]
        public void QuitCommand_Successful() {
            Assert.IsInstanceOfType(GetCommand("q"), typeof(QuitCommand), "q should be QuitCommand.");
            Assert.IsInstanceOfType(GetCommand("quit"), typeof(QuitCommand), "quit should be QuitCommand.");
            Assert.IsInstanceOfType(GetCommand("Quit"), typeof(QuitCommand), "Quit should be QuitCommand.");
        }

        [TestMethod]
        public void UpdateQuantityCommand_Successful() {
            Assert.IsInstanceOfType(GetCommand("u"), typeof(UpdateQuantityCommand), "u should be UpdateQuantityCommand.");
            Assert.IsInstanceOfType(GetCommand("updatequantity"), typeof(UpdateQuantityCommand), "u should be UpdateQuantityCommand.");
            Assert.IsInstanceOfType(GetCommand("UpdateQuantity"), typeof(UpdateQuantityCommand), "UpdateQuantity should be UpdateQuantityCommand.");
        }

        [TestMethod]
        public void UnknownCommand_Successful() {
            Assert.IsInstanceOfType(GetCommand("add"), typeof(UnknownCommand), "add should be UnknownCommand.");
            Assert.IsInstanceOfType(GetCommand("update"), typeof(UnknownCommand), "update should be UnknownCommand.");
            Assert.IsInstanceOfType(GetCommand("GET"), typeof(UnknownCommand), "GET should be UnknownCommand.");
        }
    }
}
