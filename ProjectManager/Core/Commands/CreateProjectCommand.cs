using System.Collections.Generic;
using System.Linq;
using Bytes2you.Validation;
using ProjectManager.CLI.Common;
using ProjectManager.CLI.Core.Commands.Contracts;
using ProjectManager.CLI.Data;
using ProjectManager.CLI.Factories;

namespace ProjectManager.CLI.Core.Commands
{
    public class CreateProjectCommand : ICommand
    {
        private const string InvalidParametersCountError = "Invalid command parameters count!";
        private const string EmptyParametersError = "Some of the passed parameters are empty!";
        private const string ProjectExistsError = "A project with that name already exists!";
        private const string SuccessMessage = "Successfully created a new project!";

        private readonly Database database;
        private readonly ModelsFactory factory;

        public CreateProjectCommand(Database database, ModelsFactory factory)
        {
            Guard.WhenArgument(database, "CreateProjectCommand Database").IsNull().Throw();
            Guard.WhenArgument(
                    factory, "CreateProjectCommand ModelsFactory")
                .IsNull().Throw();

            this.database = database;
            this.factory = factory;
        }

        public string Execute(List<string> parameters)
        {
            if (parameters.Count != 4)
            {
                throw new UserValidationException(InvalidParametersCountError);
            }

            if (parameters.Any(x => x == string.Empty))
            {
                throw new UserValidationException(EmptyParametersError);
            }

            if (this.database.Projects.Any(x => x.Name == parameters[0]))
            {
                throw new UserValidationException(ProjectExistsError);
            }

            var project = this.factory.CreateProject(parameters[0], parameters[1], parameters[2], parameters[3]);
            this.database.Projects.Add(project);

            return SuccessMessage;
        }
    }
}