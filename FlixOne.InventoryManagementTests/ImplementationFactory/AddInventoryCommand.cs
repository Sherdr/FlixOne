namespace FlixOne.InventoryManagementTests.ImplementationFactory {
    public class AddInventoryCommand : InventoryCommand {
        protected override string[] CommandStrings =>
            new string[] { "a", "addinventory" };
    }
}
