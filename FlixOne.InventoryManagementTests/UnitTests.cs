using FlixOne.InventoryManagement;

namespace FlixOne.InventoryManagementTests {

    [TestClass]
    public class UnitTests {
        [TestMethod]
        public void AddInventoryCommand_Successful() {
            Assert.Inconclusive("AddInventoryCommand_Successful has not been implemented.");
        }

        [TestMethod]
        public void GetInventoryCommand_Successful() {
            Assert.Inconclusive("GetInventoryCommand_Successful has not been implemented.");
        }

        [TestMethod]
        public void HelpCommand_Successful() {
            Assert.Inconclusive("HelpCommand_Successful has not been implemented.");
        }

        [TestMethod]
        public void QuitCommand_Successful() {
            var expectedInterface = new TestUserInterface {
                expectedReadValueRequests = new List<(string, string)>(),
                expectedWriteMessageRequests = new List<string> { "Thank you for using FlixOne Inventory Management System." },
                expectedWriteWarningRequests = new List<string>()
            };
            var command = new QuitCommand(expectedInterface);
            var result = command.RunCommand();
            expectedInterface.Validate();
            Assert.IsTrue(result.shouldQuit, "Quit is a terminating command");
            Assert.IsTrue(result.wasSuccessful, "Quit did not complete Successfully");
        }

        [TestMethod]
        public void UpdateQuantityCommand_Successful() {
            Assert.Inconclusive("UpdateQuantityCommand_Successful has not been implemented.");
        }
    }
}