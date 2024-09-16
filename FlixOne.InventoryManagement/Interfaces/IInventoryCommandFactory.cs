using FlixOne.InventoryManagement.Services.Commands;

namespace FlixOne.InventoryManagement.Interfaces
{
    public interface IInventoryCommandFactory {
        InventoryCommand GetCommand(string input);
    }
}
