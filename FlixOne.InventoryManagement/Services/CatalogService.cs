using FlixOne.InventoryManagement.Interfaces;
using FlixOne.InventoryManagement.Services.Commands;

namespace FlixOne.InventoryManagement.Services
{
    public class CatalogService : ICatalogService {
        private readonly IUserInterface userInterface;
        private readonly Func<string, InventoryCommand> commandFactory;

        public CatalogService(IUserInterface userInterface, Func<string, InventoryCommand> commandFactory) {
            this.userInterface = userInterface;
            this.commandFactory = commandFactory;
        }

        public void Run() {
            Greeting();
            var response = commandFactory("?").RunCommand();
            while (!response.shouldQuit) {
                var input = userInterface.ReadValue("> ").ToLower();
                var command = commandFactory(input);
                response = command.RunCommand();
                if (!response.wasSuccessful) {
                    userInterface.WriteMessage("Enter ? to view options.");
                }
            }
        }

        private void Greeting() {
            userInterface.WriteWarning("Welcome to FlixOne Inventory Management System.");
        }
    }
}
