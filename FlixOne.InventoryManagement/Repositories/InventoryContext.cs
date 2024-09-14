using FlixOne.InventoryManagement.Interfaces;
using FlixOne.InventoryManagement.Models;

namespace FlixOne.InventoryManagement.Repositories {
    internal class InventoryContext : IInventoryContext {
        private readonly IDictionary<string, Book> books;

        public InventoryContext() {
            books = new Dictionary<string, Book>();
        }
        public bool AddBook(string name) {
            books.Add(name, new Book { Name = name });
            return true;
        }

        public Book[] GetBooks() {
            return books.Values.ToArray();
        }

        public bool UpdateQuantity(string name, int quantity) {
            books[name].Quantity += quantity;
            return true;
        }
    }
}
