using FlixOne.InventoryManagement.Interfaces;

namespace FlixOne.InventoryManagement.Services.Commands
{
    internal class AddInventoryCommand : NonTerminatingCommand, IParameterisedCommand
    {
        private readonly IInventoryWriteContext context;
        public string InventoryName { get; private set; }

        public AddInventoryCommand(IUserInterface userInterface, IInventoryWriteContext context) : base(userInterface)
        {
            this.context = context;
        }

        public bool GetParameters()
        {
            if (string.IsNullOrWhiteSpace(InventoryName))
            {
                InventoryName = GetParameter("name");
            }
            return !string.IsNullOrWhiteSpace(InventoryName);
        }

        internal override bool InternalCommand()
        {
            return context.AddBook(InventoryName);
        }
    }
}
