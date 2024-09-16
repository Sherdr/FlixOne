using FlixOne.InventoryManagement.Interfaces;

namespace FlixOne.InventoryManagement.Services {
    internal class GetInventoryCommand : NonTerminatingCommand {
        private readonly IInventoryContext context;
        internal GetInventoryCommand(IUserInterface userInterface, IInventoryContext context) : base(userInterface) {
            this.context = context;
        }

        internal override bool InternalCommand() {
            foreach (var book in context.GetBooks()) {
                Interface.WriteMessage($"{book.Name}\tQuantity:{book.Quantity}");
            }
            return true;
        }
    }
}
