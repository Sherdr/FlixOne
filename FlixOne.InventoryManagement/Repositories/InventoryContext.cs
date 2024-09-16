using FlixOne.InventoryManagement.Interfaces;
using FlixOne.InventoryManagement.Models;
using System.Collections.Concurrent;

namespace FlixOne.InventoryManagement.Repositories {
    public class InventoryContext : IInventoryContext {
        private readonly IDictionary<string, Book> books;
        private static object @lock = new object();

        public InventoryContext() {
            books = new ConcurrentDictionary<string, Book>();
        }

        public bool AddBook(string name) {
            books.Add(name, new Book { Name = name });
            return true;
        }

        public Book[] GetBooks() {
            return books.Values.ToArray();
        }

        public bool UpdateQuantity(string name, int quantity) {
            lock (@lock) {
                books[name].Quantity += quantity;
            }
            return true;
        }
    }
}
