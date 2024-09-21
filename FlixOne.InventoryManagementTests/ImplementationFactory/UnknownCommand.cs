namespace FlixOne.InventoryManagementTests.ImplementationFactory {
    public class UnknownCommand : InventoryCommand {
        protected override string[] CommandStrings =>
            new string[0];

        public override bool IsCommandFor(string input) {
            return true;
        }
    }
}
