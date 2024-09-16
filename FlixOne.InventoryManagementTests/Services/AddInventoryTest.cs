using FlixOne.InventoryManagement.Models;
using FlixOne.InventoryManagement.Services;
using FlixOne.InventoryManagement.Services.Commands;
using FlixOne.InventoryManagementTests.Helpers;

namespace FlixOne.InventoryManagementTests.Services
{
    [TestClass]
    public class AddInventoryTest
    {
        [TestMethod]
        public void AddInventoryCommand_Successful()
        {
            var expectedBookName = "AddInventoryUnitTest";
            var expectedInterface = new TestUserInterface(
                new List<(string, string)> { ("Enter name:", expectedBookName) },
                new List<string>(),
                new List<string>()
            );
            var context = new TestInventoryContext(new Dictionary<string, Book> {
                { "Gremlins", new Book{ Id = 1, Name = "Gremlins", Quantity = 7 } }
            });
            var command = new AddInventoryCommand(expectedInterface, context);
            var result = command.RunCommand();

            Assert.IsFalse(result.shouldQuit, "AddInventory is not a terminating command.");
            Assert.IsTrue(result.wasSuccessful, "AddInventory did not complete successfully.");

            Assert.AreEqual(1, context.GetAddedBooks().Length, "AddInventory should have added one book.");
            var newBook = context.GetAddedBooks().First();
            Assert.AreEqual(expectedBookName, newBook.Name, "AddInventory did not add book successfully.");
        }
    }
}
