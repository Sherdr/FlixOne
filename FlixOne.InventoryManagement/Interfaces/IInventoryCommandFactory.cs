using FlixOne.InventoryManagement.Services;

namespace FlixOne.InventoryManagement.Interfaces {
    public interface IInventoryCommandFactory {
        InventoryCommand GetCommand(string input);
    }
}
