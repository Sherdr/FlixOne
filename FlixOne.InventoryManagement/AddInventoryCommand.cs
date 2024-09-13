namespace FlixOne.InventoryManagement {
    internal class AddInventoryCommand : NonTerminatingCommand, IParameterisedCommand {
        public string InventoryName { get; private set; }

        public AddInventoryCommand(IUserInterface userInterface) : base(userInterface) {
        }

        public bool GetParameters() {
            if (string.IsNullOrWhiteSpace(InventoryName)) {
                InventoryName = GetParameter("name");
            }
            return !string.IsNullOrWhiteSpace(InventoryName);
        }

        internal override bool InternalCommand() {
            throw new NotImplementedException();
        }
    }
}
