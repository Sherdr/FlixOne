using FlixOne.InventoryManagement.Models;

namespace FlixOne.InventoryManagement.Interfaces {
    public interface IInventoryContext {
        Book[] GetBooks();
        bool AddBook(string name);
        bool UpdateQuantity(string name, int quantity);
    }
}
