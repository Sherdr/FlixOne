using FlixOne.InventoryManagement;

namespace FlixOne.InventoryManagementClient {
    internal class Program {
        static void Main(string[] args) {
            Greeting();
            GetCommand("?").RunCommand(out bool shouldQuit);
            while (!shouldQuit) {
                Console.WriteLine(" > ");
                var input = Console.ReadLine();
                var command = GetCommand(input);
                var wasSuccessful = command.RunCommand(out shouldQuit);
                if (!wasSuccessful) {
                    Console.WriteLine("Enter ? to view options.");
                }
            }
            Console.WriteLine("CatalogService has completed.");
        }

        private static InventoryCommand GetCommand(string? input) {
            return new HelpCommand();
        }

        private static void Greeting() {
            throw new NotImplementedException();
        }
    }
}
