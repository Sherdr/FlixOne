﻿namespace FlixOne.InventoryManagement {
    public class ConsoleUserInterface {
        public string ReadValue(string message) {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        public void WriteMessage(string message) {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
        }

        public void WriteWarning(string message) {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(message);
        }
    }
}