using Autofac;
using Microsoft.Extensions.DependencyInjection;

namespace FlixOne.InventoryManagementTests.ImplementationFactory {
    [TestClass]
    public class AutofacImplementationFactoryTests {
        public IContainer Container { get; private set; }
        [TestInitialize]
        public void Startup() {
            var services = new ServiceCollection();
            var builder = new ContainerBuilder();

            builder.RegisterType<AddInventoryCommand>().Named<InventoryCommand>("a");
            builder.RegisterType<AddInventoryCommand>().Named<InventoryCommand>("addinventory");

            builder.RegisterType<GetInventoryCommand>().Named<InventoryCommand>("g");
            builder.RegisterType<GetInventoryCommand>().Named<InventoryCommand>("getinventory");

            builder.RegisterType<HelpCommand>().Named<InventoryCommand>("?");

            builder.RegisterType<QuitCommand>().Named<InventoryCommand>("q");
            builder.RegisterType<QuitCommand>().Named<InventoryCommand>("quit");

            builder.RegisterType<UpdateQuantityCommand>().Named<InventoryCommand>("u");
            builder.RegisterType<UpdateQuantityCommand>().Named<InventoryCommand>("updatequantity");

            builder.RegisterType<UnknownCommand>().As<InventoryCommand>();

            Container = builder.Build();
        }

        public InventoryCommand GetCommand(string input) {
            return Container.ResolveOptionalNamed<InventoryCommand>(input.ToLower()) ?? Container.Resolve<InventoryCommand>();
        }

        [TestMethod]
        public void AddInventoryCommand_Successful() {
            Assert.IsInstanceOfType(GetCommand("a"), typeof(AddInventoryCommand), "a should be AddInventoryCommand.");
            Assert.IsInstanceOfType(GetCommand("addinventory"), typeof(AddInventoryCommand), "addinventory should be AddInventoryCommand.");
        }

        [TestMethod]
        public void GetInventoryCommand_Successful() {
            Assert.IsInstanceOfType(GetCommand("g"), typeof(GetInventoryCommand), "a should be GetInventoryCommand.");
            Assert.IsInstanceOfType(GetCommand("getinventory"), typeof(GetInventoryCommand), "getinventory should be GetInventoryCommand.");
        }

        [TestMethod]
        public void HelpCommand_Successful() {
            Assert.IsInstanceOfType(GetCommand("?"), typeof(HelpCommand), "a should be HelpCommand.");
        }

        [TestMethod]
        public void QuitCommand_Successful() {
            Assert.IsInstanceOfType(GetCommand("q"), typeof(QuitCommand), "q should be QuitCommand.");
            Assert.IsInstanceOfType(GetCommand("quit"), typeof(QuitCommand), "quit should be QuitCommand.");
        }

        [TestMethod]
        public void UpdateQuantityCommand_Successful() {
            Assert.IsInstanceOfType(GetCommand("u"), typeof(UpdateQuantityCommand), "u should be UpdateQuantityCommand.");
            Assert.IsInstanceOfType(GetCommand("updatequantity"), typeof(UpdateQuantityCommand), "updatequantity should be UpdateQuantityCommand.");
        }

        [TestMethod]
        public void UnknownCommand_Successful() {
            Assert.IsInstanceOfType(GetCommand("ADD"), typeof(UnknownCommand), "ADD should be UnknownCommand.");
            Assert.IsInstanceOfType(GetCommand("exit"), typeof(UnknownCommand), "exit should be UnknownCommand.");
        }
    }
}
