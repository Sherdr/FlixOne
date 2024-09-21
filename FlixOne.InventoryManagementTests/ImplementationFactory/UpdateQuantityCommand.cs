namespace FlixOne.InventoryManagementTests.ImplementationFactory {
    public class UpdateQuantityCommand : InventoryCommand {
        protected override string[] CommandStrings =>
            new string[] { "u", "updatequantity" };
    }
}
