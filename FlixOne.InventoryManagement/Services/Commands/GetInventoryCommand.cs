using FlixOne.InventoryManagement.Interfaces;

namespace FlixOne.InventoryManagement.Services.Commands
{
    internal class GetInventoryCommand : NonTerminatingCommand
    {
        private readonly IInventoryReadContext context;
        internal GetInventoryCommand(IUserInterface userInterface, IInventoryReadContext context) : base(userInterface)
        {
            this.context = context;
        }

        internal override bool InternalCommand()
        {
            foreach (var book in context.GetBooks())
            {
                Interface.WriteMessage($"{book.Name}\tQuantity:{book.Quantity}");
            }
            return true;
        }
    }
}
