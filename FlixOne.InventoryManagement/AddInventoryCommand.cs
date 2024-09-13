namespace FlixOne.InventoryManagement {
    public class AddInventoryCommand : InventoryCommand, IParameterisedCommand {
        public string InventoryName { get; private set; }

        public AddInventoryCommand() : base(false) {
        }

        public bool GetParameters() {
            if (string.IsNullOrWhiteSpace(InventoryName)) {
                //InventoryName = GetParameter();
            }
            return !string.IsNullOrWhiteSpace(InventoryName);
        }

        internal override bool InternalCommand() {
            throw new NotImplementedException();
        }
    }
}
