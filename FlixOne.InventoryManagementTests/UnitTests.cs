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
            Assert.Inconclusive("UpdateQuantityCommand_Successful has not been implemented.");
        }
    }
}