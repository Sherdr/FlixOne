namespace FlixOne.InventoryManagementTests.ImplementationFactory {
    public abstract class InventoryCommand {
        protected abstract string[] CommandStrings { get; }

        public virtual bool IsCommandFor(string input) {
            return CommandStrings.Contains(input.ToLower()); 
        }
    }
}
