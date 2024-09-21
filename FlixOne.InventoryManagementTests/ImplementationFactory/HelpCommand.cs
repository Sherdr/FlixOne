namespace FlixOne.InventoryManagementTests.ImplementationFactory {
    public class HelpCommand : InventoryCommand {
        protected override string[] CommandStrings =>
            new string[] { "?" };
    }
}
