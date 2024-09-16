using FlixOne.InventoryManagement.Models;
using FlixOne.InventoryManagement.Services;
using FlixOne.InventoryManagement.Services.Commands;
using FlixOne.InventoryManagementTests.Helpers;

namespace FlixOne.InventoryManagementTests.Services
{
    [TestClass]
    public class UpdateQuantityTest
    {
        [TestMethod]
        public void UpdateQuantityCommand_Successful()
        {
            var expectedBookName = "UpdateQuantityUnitTest";
            var expectedInterface = new TestUserInterface(
                new List<(string, string)> { ("Enter name:", expectedBookName), ("Enter quantity:", "6") },
                new List<string>(),
                new List<string>()
            );
            var context = new TestInventoryContext(new Dictionary<string, Book> {
                { "Beavers", new Book{ Id = 1, Name = "Beavers", Quantity = 3 } },
                { expectedBookName, new Book{ Id = 2, Name = expectedBookName, Quantity = 7 } },
                { "Ducks", new Book{ Id = 3, Name = "Ducks", Quantity = 12 } }
            });
            var command = new UpdateQuantityCommand(expectedInterface, context);
            var result = command.RunCommand();

            Assert.IsFalse(result.shouldQuit, "UpdateQuantity is not a terminating command.");
            Assert.IsTrue(result.wasSuccessful, "UpdateQuantity did not complete successfully.");

            Assert.AreEqual(0, context.GetAddedBooks().Length, "UpdateQuantity not should have added one new book.");
            var updateBooks = context.GetUpdatedBooks();
            Assert.AreEqual(1, updateBooks.Length, "UpdateQuantity should have update one new book.");
            Assert.AreEqual(expectedBookName, updateBooks.First().Name, "UpdateQuantity did not update the correct book.");
            Assert.AreEqual(13, updateBooks.First().Quantity, "UpdateQuantity did update book quantity successfully.");
        }
    }
}
