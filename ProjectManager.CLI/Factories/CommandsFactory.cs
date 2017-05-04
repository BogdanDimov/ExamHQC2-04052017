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
        private const string InvalidCommandError = "The passed command is not valid!";
        private const string CreateProjectCommand = "createproject";
        private const string CreateTaskCommand = "createtask";
        private const string CreateUserCommand = "createuser";
        private const string ListProjectsCommand = "listprojects";

        private readonly Database database;
        private readonly ModelsFactory modelsFactory;

        public CommandsFactory(Database database, ModelsFactory modelsFactory)
        {
            this.database = database;
            this.modelsFactory = modelsFactory;
        }

        public ICommand CreateCommandFromString(string commandName)
        {
            var command = this.BuildCommand(commandName).ToLower();

            switch (command)
            {
                case CreateProjectCommand:
                    return new CreateProjectCommand(this.database, this.modelsFactory);
                case CreateTaskCommand:
                    return new CreateTaskCommand();
                //bug -- missing switch case for CreateUserCommand()
                case CreateUserCommand:
                    return new CreateUserCommand();
                case ListProjectsCommand:
                    return new ListProjectsCommand(this.database);
                default:
                    throw new UserValidationException(InvalidCommandError);
            }
        }

        private string BuildCommand(string parameters)
        {
            var command = string.Empty;

            //var end = DateTime.Now + TimeSpan.FromSeconds(1);
            //while (DateTime.Now < end)
            //{
            //}

            //possible bottleneck, calls tolower after each increment
            for (var i = 0; i < parameters.Length; i++)
            {
                command += parameters[i]/*.ToString().ToLower()*/;
            }

            return command;
        }
    }
}