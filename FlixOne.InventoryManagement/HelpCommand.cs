namespace FlixOne.InventoryManagement {
    public class HelpCommand : InventoryCommand {
        public HelpCommand() : base(false) { }

        internal override bool InternalCommand() {
            Console.WriteLine("USAGE:");
            Console.WriteLine("\t Add to inventory (a)");
            Console.WriteLine("Examples:");
            return true;
        }
    }
}
