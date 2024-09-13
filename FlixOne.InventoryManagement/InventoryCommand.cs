namespace FlixOne.InventoryManagement {
    public abstract class InventoryCommand {
        private readonly bool isTerminatingCommand;
        protected IUserInterface Interface { get; }

        protected InventoryCommand(bool commandIsTerminating, IUserInterface userInterface) {
            Interface = userInterface;
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

        internal string GetParameter(string parameterName) {
            return Interface.ReadValue($"Enter {parameterName}:");
        }

        internal abstract bool InternalCommand();
    }
}
