using FlixOne.InventoryManagement.Interfaces;

namespace FlixOne.InventoryManagement.Services {
    internal class UnknownCommand : NonTerminatingCommand {
        internal UnknownCommand(IUserInterface userInterface) : base(userInterface) { }
        internal override bool InternalCommand() {
            Interface.WriteWarning("Unable to determine the desired command.");
            return false;
        }
    }
}
