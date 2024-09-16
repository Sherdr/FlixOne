using System.Runtime.CompilerServices;
using FlixOne.InventoryManagement.Interfaces;
[assembly: InternalsVisibleTo("FlixOne.InventoryManagementTests")]

namespace FlixOne.InventoryManagement.Services.Commands
{
    internal class QuitCommand : InventoryCommand
    {
        internal QuitCommand(IUserInterface userInterface) : base(true, userInterface) { }

        internal override bool InternalCommand()
        {
            Interface.WriteMessage("Thank you for using FlixOne Inventory Management System.");
            return true;
        }
    }
}
