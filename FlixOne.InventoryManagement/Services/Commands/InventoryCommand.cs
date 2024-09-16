using FlixOne.InventoryManagement.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace FlixOne.InventoryManagement.Services.Commands
{
    public abstract class InventoryCommand
    {
        private readonly bool isTerminatingCommand;
        protected IUserInterface Interface { get; }

        protected InventoryCommand(bool commandIsTerminating, IUserInterface userInterface)
        {
            Interface = userInterface;
            isTerminatingCommand = commandIsTerminating;
        }

        public (bool wasSuccessful, bool shouldQuit) RunCommand()
        {
            if (this is IParameterisedCommand parameterisedCommand)
            {
                var allParametersCompleted = false;
                while (allParametersCompleted == false)
                {
                    allParametersCompleted = parameterisedCommand.GetParameters();
                }
            }
            return (InternalCommand(), isTerminatingCommand);
        }

        internal string GetParameter(string parameterName)
        {
            return Interface.ReadValue($"Enter {parameterName}:");
        }

        public static Func<IServiceProvider, Func<string, InventoryCommand>> GetInventoryCommand => provider => input =>
        {
            switch (input.ToLower())
            {
                case "q":
                case "quit":
                    return new QuitCommand(provider.GetService<IUserInterface>());
                case "a":
                case "addinventory":
                    return new AddInventoryCommand(provider.GetService<IUserInterface>(), provider.GetService<IInventoryWriteContext>());
                case "g":
                case "getinventory":
                    return new GetInventoryCommand(provider.GetService<IUserInterface>(), provider.GetService<IInventoryReadContext>());
                case "u":
                case "updatequantity":
                    return new UpdateQuantityCommand(provider.GetService<IUserInterface>(), provider.GetService<IInventoryWriteContext>());
                case "?":
                    return new HelpCommand(provider.GetService<IUserInterface>());
                default:
                    return new UnknownCommand(provider.GetService<IUserInterface>());
            }
        };

        internal abstract bool InternalCommand();
    }
}
