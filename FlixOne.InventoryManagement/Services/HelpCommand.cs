using FlixOne.InventoryManagement.Interfaces;

namespace FlixOne.InventoryManagement.Services
{
    internal class HelpCommand : NonTerminatingCommand
    {
        public HelpCommand(IUserInterface userInterface) : base(userInterface) { }

        internal override bool InternalCommand()
        {
            Interface.WriteMessage("USAGE:");
            Interface.WriteMessage("\t Add to inventory (a)");
            Interface.WriteMessage("Examples:");
            return true;
        }
    }
}
