using FlixOne.InventoryManagement.Interfaces;
using FlixOne.InventoryManagement.Repositories;
using System.Reflection.Metadata;

namespace FlixOne.InventoryManagement.Services {
    public class InventoryCommandFactory {
        private readonly IUserInterface userInterface;
        private readonly IInventoryContext inventoryContext = InventoryContext.Singleton;

        public InventoryCommandFactory(IUserInterface userInterface) {
            this.userInterface = userInterface;
        }

        public InventoryCommand GetCommand(string input) {
            switch (input) {
                case "q":
                case "quit":
                    return new QuitCommand(userInterface);
                case "a":
                case "addinventory":
                    return new AddInventoryCommand(userInterface, inventoryContext);
                case "g":
                case "getinventory":
                    return new GetInventoryCommand(userInterface, inventoryContext);
                case "u":
                case "updateinventory":
                    return new UpdateQuantityCommand(userInterface, inventoryContext);
                case "?":
                    return new HelpCommand(userInterface);
                default:
                    return new UnknownCommand(userInterface);
            }
        }
    }
}
