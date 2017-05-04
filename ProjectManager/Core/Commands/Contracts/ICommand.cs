using System.Collections.Generic;

namespace ProjectManager.CLI.Core.Commands.Contracts
{
    public interface ICommand
    {
        string Execute(List<string> parameters);
    }
}
