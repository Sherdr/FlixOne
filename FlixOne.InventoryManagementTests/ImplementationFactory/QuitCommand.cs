namespace FlixOne.InventoryManagementTests.ImplementationFactory {
    public class QuitCommand : InventoryCommand {
        protected override string[] CommandStrings =>
            new string[] { "q", "quit" };
    }
}
