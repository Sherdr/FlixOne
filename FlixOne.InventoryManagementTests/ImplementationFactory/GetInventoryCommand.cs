namespace FlixOne.InventoryManagementTests.ImplementationFactory {
    public class GetInventoryCommand : InventoryCommand{
        protected override string[] CommandStrings =>
            new string[] { "g", "getinventory" };
    }
}
