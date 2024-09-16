using FlixOne.InventoryManagement.Services;
using FlixOne.InventoryManagementTests.Helpers;

namespace FlixOne.InventoryManagementTests {
    [TestClass]
    public class QuitTest {

        [TestMethod]
        public void QuitCommand_Successful() {
            var expectedInterface = new TestUserInterface(
                new List<(string, string)>(),
                new List<string> { "Thank you for using FlixOne Inventory Management System." },
                new List<string>()
            );
            var command = new QuitCommand(expectedInterface);
            var result = command.RunCommand();
            expectedInterface.Validate();

            Assert.IsTrue(result.shouldQuit, "Quit is a terminating command");
            Assert.IsTrue(result.wasSuccessful, "Quit did not complete Successfully");
        }
    }
}
