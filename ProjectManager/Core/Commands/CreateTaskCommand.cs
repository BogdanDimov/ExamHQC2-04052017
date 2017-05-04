using System.Collections.Generic;
using System.Linq;
using ProjectManager.CLI.Common;
using ProjectManager.CLI.Core.Commands.Contracts;
using ProjectManager.CLI.Data;
using ProjectManager.CLI.Factories;

namespace ProjectManager.CLI.Core.Commands
{
    public sealed class CreateTaskCommand : ICommand
    {
        private const string InvalidParametersCountError = "Invalid command parameters count!";
        private const string EmptyParametersError = "Some of the passed parameters are empty!";
        private const string SuccessMessage = "Successfully created a new task!";

        public string Execute(List<string> parameters)
        {
            var database = new Database();
            var factory = new ModelsFactory();

            if (parameters.Count != 4)
            {
                throw new UserValidationException(InvalidParametersCountError);
            }

            if (parameters.Any(x => x == string.Empty))
            {
                throw new UserValidationException(EmptyParametersError);
            }

            var project = database.Projects[int.Parse(parameters[0])];
            var owner = project.Users[int.Parse(parameters[1])];
            var task = factory.CreateTask(owner, parameters[2], parameters[3]);
            project.Tasks.Add(task);

            return SuccessMessage;
        }
    }
}