using System.Collections.Generic;
using ProjectManager.CLI.Models.Contracts;

namespace ProjectManager.CLI.Data
{
    // You are not allowed to modify this interface (except to add documentation)
    public interface IDatabase
    {
        IList<IProject> Projects { get; }
    }
}
