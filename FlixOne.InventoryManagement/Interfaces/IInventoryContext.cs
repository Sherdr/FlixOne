using FlixOne.InventoryManagement.Models;

namespace FlixOne.InventoryManagement.Interfaces {
    public interface IInventoryContext : IInventoryReadContext, IInventoryWriteContext { }

    public interface IInventoryReadContext {
        Book[] GetBooks();
    }

    public interface IInventoryWriteContext {
        bool AddBook(string name);
        bool UpdateQuantity(string name, int quantity);
    }
}
