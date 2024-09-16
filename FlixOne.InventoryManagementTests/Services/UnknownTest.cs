using FlixOne.InventoryManagement.Services;
using FlixOne.InventoryManagement.Services.Commands;
using FlixOne.InventoryManagementTests.Helpers;

namespace FlixOne.InventoryManagementTests.Services
{
    [TestClass]
    public class UnknownTest
    {
        [TestMethod]
        public void UnknownCommand_Successful()
        {
            var expectedInterface = new TestUserInterface(
                new List<(string, string)>(),
                new List<string>(),
                new List<string> { "Unable to determine the desired command." }
            );
            var command = new UnknownCommand(expectedInterface);
            var result = command.RunCommand();

            Assert.IsFalse(result.shouldQuit, "Unknown is not terminating command.");
            Assert.IsFalse(result.wasSuccessful, "Unknown should not complete Successfully");
        }
    }
}
