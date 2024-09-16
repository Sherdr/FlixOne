using FlixOne.InventoryManagement.Interfaces;

namespace FlixOne.InventoryManagement.Services {
    public class CatalogService : ICatalogService {
        private readonly IUserInterface userInterface;
        private readonly IInventoryCommandFactory commandFactory;

        public CatalogService(IUserInterface userInterface, IInventoryCommandFactory commandFactory) {
            this.userInterface = userInterface;
            this.commandFactory = commandFactory;
        }

        public void Run() {
            Greeting();
            var response = commandFactory.GetCommand("?").RunCommand();
            while (!response.shouldQuit) {
                var input = userInterface.ReadValue("> ").ToLower();
                var command = commandFactory.GetCommand(input);
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
