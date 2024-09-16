using FlixOne.InventoryManagement.Interfaces;
using FlixOne.InventoryManagement.Repositories;
using FlixOne.InventoryManagement.Services.Commands;
using System.Reflection.Metadata;

namespace FlixOne.InventoryManagement.Services
{
    public class InventoryCommandFactory : IInventoryCommandFactory{
        private readonly IUserInterface userInterface;
        private readonly IInventoryContext inventoryContext;

        public InventoryCommandFactory(IUserInterface userInterface, IInventoryContext inventoryContext) {
            this.userInterface = userInterface;
            this.inventoryContext = inventoryContext;
        }

        public InventoryCommand GetCommand(string input) {
            switch (input.ToLower()) {
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
                case "updatequantity":
                    return new UpdateQuantityCommand(userInterface, inventoryContext);
                case "?":
                    return new HelpCommand(userInterface);
                default:
                    return new UnknownCommand(userInterface);
            }
        }
    }
}
