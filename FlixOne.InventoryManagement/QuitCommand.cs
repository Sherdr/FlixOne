namespace FlixOne.InventoryManagement {
    public class QuitCommand : InventoryCommand {
        public QuitCommand() : base(true) { }

        internal override bool InternalCommand() {
            Console.WriteLine("Thank you for using FlixOne Inventory Management System.");
            return true;
        }
    }
}
