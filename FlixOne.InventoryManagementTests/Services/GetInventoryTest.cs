using FlixOne.InventoryManagement.Models;
using FlixOne.InventoryManagement.Services;
using FlixOne.InventoryManagement.Services.Commands;
using FlixOne.InventoryManagementTests.Helpers;

namespace FlixOne.InventoryManagementTests.Services
{
    [TestClass]
    public class GetInventoryTest
    {
        [TestMethod]
        public void GetInventoryCommand_Successful()
        {
            var expectedInterface = new TestUserInterface(
                new List<(string, string)>(),
                new List<string> { "Gremlins\tQuantity:7", "Willsong\tQuantity:3" },
                new List<string>()
            );
            var context = new TestInventoryContext(new Dictionary<string, Book> {
                { "Gremlins", new Book { Id = 1, Name = "Gremlins", Quantity = 7} },
                { "Willsong", new Book { Id = 2, Name = "Willsong", Quantity = 3} }
            });
            var command = new GetInventoryCommand(expectedInterface, context);
            var result = command.RunCommand();

            Assert.IsFalse(result.shouldQuit, "GetInventory is not a terminating command.");
            Assert.IsTrue(result.wasSuccessful, "GetInventory did not complete successfully.");

            Assert.AreEqual(0, context.GetAddedBooks().Length, "GetInventory should not have added any books.");
            Assert.AreEqual(0, context.GetUpdatedBooks().Length, "GetInventory should not have update any books.");
        }
    }
}
