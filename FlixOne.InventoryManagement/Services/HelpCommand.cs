using FlixOne.InventoryManagement.Interfaces;

namespace FlixOne.InventoryManagement.Services
{
    internal class HelpCommand : NonTerminatingCommand
    {
        public HelpCommand(IUserInterface userInterface) : base(userInterface) { }

        internal override bool InternalCommand()
        {
            Interface.WriteMessage("USAGE:");
            Interface.WriteMessage("\taddinventory (a)");
            Interface.WriteMessage("\tgetinventory (g)");
            Interface.WriteMessage("\tupdatequantity (u)");
            Interface.WriteMessage("\tquit (q)");
            Interface.WriteMessage("\t?");
            Interface.WriteMessage("Examples:");
            Interface.WriteMessage("\tNew Inventory\n\t> a\n\tEnter name:{name}\n");
            Interface.WriteMessage("\tGet Inventory\n\t> g\n");
            Interface.WriteMessage("\tUpdate Quantity\n\t> u\n\tEnter name:{name}\n\tEnter quantity:{difference}\n");
            return true;
        }
    }
}
