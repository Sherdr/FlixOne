using FlixOne.InventoryManagement.Interfaces;
using FlixOne.InventoryManagement.Models;

namespace FlixOne.InventoryManagementTests.Helpers
{
    internal class TestInventoryContext : IInventoryContext
    {
        private readonly IDictionary<string, Book> seedDictionary;
        private readonly IDictionary<string, Book> books;

        public TestInventoryContext(IDictionary<string, Book> books)
        {
            seedDictionary = books.ToDictionary(
                book => book.Key,
                book => new Book
                {
                    Id = book.Value.Id,
                    Name = book.Value.Name,
                    Quantity = book.Value.Quantity
                }
            );
            this.books = books;
        }

        public Book[] GetAddedBooks()
        {
            return books.Where(book => !seedDictionary.ContainsKey(book.Key))
                .Select(book => book.Value).ToArray();
        }

        public Book[] GetUpdatedBooks()
        {
            return books.Where(book => seedDictionary[book.Key].Quantity != book.Value.Quantity)
                .Select(book => book.Value).ToArray();
        }

        public bool AddBook(string name)
        {
            books.Add(name, new Book { Name = name });
            return true;
        }

        public Book[] GetBooks()
        {
            return books.Values.ToArray();
        }

        public bool UpdateQuantity(string name, int quantity)
        {
            books[name].Quantity += quantity;
            return true;
        }
    }
}
