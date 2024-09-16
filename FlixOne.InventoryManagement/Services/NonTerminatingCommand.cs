using FlixOne.InventoryManagement.Interfaces;
using FlixOne.InventoryManagement.Services.Commands;

namespace FlixOne.InventoryManagement.Services
{
    internal abstract class NonTerminatingCommand : InventoryCommand
    {
        protected NonTerminatingCommand(IUserInterface userInterface) : base(false, userInterface) { }
    }
}
