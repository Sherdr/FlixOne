namespace FlixOne.InventoryManagement {
    public abstract class InventoryCommand {
        private readonly bool isTerminatingCommand;

        internal InventoryCommand(bool commandIsTerminating) {
            isTerminatingCommand = commandIsTerminating;
        }

        public bool RunCommand(out bool shouldQuit) {
            shouldQuit = isTerminatingCommand;
            return InternalCommand();
        }

        internal abstract bool InternalCommand();
    }
}
