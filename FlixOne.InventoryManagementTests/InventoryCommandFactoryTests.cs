using FlixOne.InventoryManagement.Services;
using FlixOne.InventoryManagementTests.Helpers;

namespace FlixOne.InventoryManagementTests {
    [TestClass]
    public class InventoryCommandFactoryTests {
        InventoryCommandFactory Factory { get; set; }

        [TestInitialize]
        public void Initialize() {
            var expectedInterface = new TestUserInterface(
                new List<(string, string)>(),
                new List<string>(),
                new List<string>()
            );
            Factory = new InventoryCommandFactory(expectedInterface);
        }

        [TestMethod]
        public void QuitCommand_Successful() {
            Assert.IsInstanceOfType(Factory.GetCommand("q"), typeof(QuitCommand), "q should be QuitCommand.");
            Assert.IsInstanceOfType(Factory.GetCommand("quit"), typeof(QuitCommand), "q should be QuitCommand.");
        }

        [TestMethod]
        public void HelpCommand_Successful() {
            Assert.IsInstanceOfType(Factory.GetCommand("?"), typeof(HelpCommand), "? should be HelpCommand.");
        }

        [TestMethod]
        public void UnknownCommand_Successful() {
            Assert.IsInstanceOfType(Factory.GetCommand("add"), typeof(UnknownCommand), "unmatched command should be UnknownCommand.");
            Assert.IsInstanceOfType(Factory.GetCommand("addinventry"), typeof(UnknownCommand), "unmatched command should be UnknownCommand.");
            Assert.IsInstanceOfType(Factory.GetCommand("h"), typeof(UnknownCommand), "unmatched command should be UnknownCommand.");
            Assert.IsInstanceOfType(Factory.GetCommand("help"), typeof(UnknownCommand), "unmatched command should be UnknownCommand.");
        }

        [TestMethod]
        public void UpdateQuantity_Successful() {
            Assert.IsInstanceOfType(Factory.GetCommand("u"), typeof(UpdateQuantityCommand), "u should be UpdateQuantityCommand.");
            Assert.IsInstanceOfType(Factory.GetCommand("updatequantity"), typeof(UpdateQuantityCommand), "updatequantity should be UpdateQuantityCommand.");
            Assert.IsInstanceOfType(Factory.GetCommand("updateQuantity"), typeof(UpdateQuantityCommand), "updatequantity should be UpdateQuantityCommand.");
        }
    }
}
