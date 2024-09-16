using FlixOne.InventoryManagement.Interfaces;

namespace FlixOne.InventoryManagement.Services.Commands
{
    internal class UpdateQuantityCommand : NonTerminatingCommand, IParameterisedCommand
    {
        private readonly IInventoryWriteContext context;
        private int quantity;
        internal int Quantity
        {
            get { return quantity; }
            private set { quantity = value; }
        }
        internal string InventoryName { get; private set; }
        public UpdateQuantityCommand(IUserInterface userInterface, IInventoryWriteContext context) : base(userInterface)
        {
            this.context = context;
        }

        public bool GetParameters()
        {
            if (string.IsNullOrWhiteSpace(InventoryName))
            {
                InventoryName = GetParameter("name");
            }
            if (Quantity == 0)
            {
                int.TryParse(GetParameter("quantity"), out quantity);
            }
            return !string.IsNullOrWhiteSpace(InventoryName) && Quantity != 0;
        }

        internal override bool InternalCommand()
        {
            return context.UpdateQuantity(InventoryName, Quantity);
        }
    }
}
