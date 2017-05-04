using System;
using System.Collections.Generic;

namespace ProjectManager.CLI.Models.Contracts
{
    public interface IProject
    {
        DateTime EndingDate { get; set; }

        string Name { get; set; }

        DateTime StartingDate { get; set; }

        string State { get; set; }

        List<Task> Tasks { get; set; }

        List<User> Users { get; set; }

        string ToString();
    }
}