using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("FlixOne.InventoryManagementTests")]

namespace FlixOne.InventoryManagement {
    internal class QuitCommand : InventoryCommand {
        internal QuitCommand(IUserInterface userInterface) : base(true, userInterface) { }

        internal override bool InternalCommand() {
            Interface.WriteMessage("Thank you for using FlixOne Inventory Management System.");
            return true;
        }
    }
}
