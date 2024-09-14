namespace FlixOne.InventoryManagement.Interfaces
{
    public interface IUserInterface : IReadUserInterface, IWriteUserIntarface { }

    public interface IWriteUserIntarface
    {
        void WriteMessage(string message);
        void WriteWarning(string message);
    }

    public interface IReadUserInterface
    {
        string ReadValue(string message);
    }
}
