namespace FlixOne.InventoryManagement {
    internal class HelpCommand : NonTerminatingCommand {
        internal override bool InternalCommand() {
            Console.WriteLine("USAGE:");
            Console.WriteLine("\t Add to inventory (a)");
            Console.WriteLine("Examples:");
            return true;
        }
    }
}
