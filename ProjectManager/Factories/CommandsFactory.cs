using System;
using ProjectManager.CLI.Common;
using ProjectManager.CLI.Core.Commands;
using ProjectManager.CLI.Core.Commands.Contracts;
using ProjectManager.CLI.Data;
using ProjectManager.CLI.Factories.Contracts;

namespace ProjectManager.CLI.Factories
{
    public class CommandsFactory : ICommandsFactory
    {
        private readonly Database database;
        private readonly ModelsFactory modelsFactory;

        public CommandsFactory(Database database, ModelsFactory modelsFactory)
        {
            this.database = database;
            this.modelsFactory = modelsFactory;
        }

        public ICommand CreateCommandFromString(string commandName)
        {
            var cmd = this.BuildCommand(commandName);

            switch (cmd)
            {
                case "createproject": return new CreateProjectCommand(this.database, this.modelsFactory);
                case "createtask": return new CreateTaskCommand();
                case "listprojects": return new ListProjectsCommand(this.database);
                default: throw new UserValidationException("The passed command is not valid!");
            }
        }

        private string BuildCommand(string parameters)
        {
            var command = string.Empty;

            var end = DateTime.Now + TimeSpan.FromSeconds(1);
            while (DateTime.Now < end)
            {
            }

            for (var i = 0; i < parameters.Length; i++)
            {
                command += parameters[i].ToString().ToLower();
            }

            return command;
        }
    }
}