namespace FlixOne.InventoryManagement {
    public abstract class InventoryCommand {
        private readonly bool isTerminatingCommand;

        internal InventoryCommand(bool commandIsTerminating) {
            isTerminatingCommand = commandIsTerminating;
        }

        public (bool wasSuccessful, bool shouldQuit) RunCommand() {
            if (this is IParameterisedCommand parameterisedCommand) {
                var allParametersCompleted = false;
                while (allParametersCompleted == false) {
                    allParametersCompleted = parameterisedCommand.GetParameters();
                }
            }
            return (InternalCommand(), isTerminatingCommand);
        }

        internal abstract bool InternalCommand();
    }
}
