using ProjectManager.CLI.Core.Commands.Contracts;

namespace ProjectManager.CLI.Factories.Contracts
{
    public interface ICommandsFactory
    {
        ICommand CreateCommandFromString(string commandName);
    }
}