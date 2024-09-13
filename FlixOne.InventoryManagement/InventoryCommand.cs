namespace FlixOne.InventoryManagement {
    public abstract class InventoryCommand {
        private readonly bool isTerminatingCommand;

        internal InventoryCommand(bool commandIsTerminating) {
            isTerminatingCommand = commandIsTerminating;
        }

        public (bool wasSuccessful, bool shouldQuit) RunCommand() {
            return (InternalCommand(), isTerminatingCommand);
        }

        internal abstract bool InternalCommand();
    }
}
