using FlixOne.InventoryManagement.Models;
using FlixOne.InventoryManagement.Services;
using FlixOne.InventoryManagementTests.Helpers;

namespace FlixOne.InventoryManagementTests {

    [TestClass]
    public class UnitTests {
        [TestMethod]
        public void AddInventoryCommand_Successful() {
            var expectedBookName = "AddInventoryUnitTest";
            var expectedInterface = new TestUserInterface {
                expectedReadValueRequests = new List<(string, string)> { ("Enter name:", expectedBookName) },
                expectedWriteMessageRequests = new List<string>(),
                expectedWriteWarningRequests = new List<string>()
            };
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
            var expectedBookName = "UpdateQuantityUnitTest";
            var expectedInterface = new TestUserInterface {
                expectedReadValueRequests = new List<(string, string)> { ("Enter name:", expectedBookName), ("Enter quantity:", "6") },
                expectedWriteMessageRequests = new List<string>(),
                expectedWriteWarningRequests = new List<string>()
            };
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