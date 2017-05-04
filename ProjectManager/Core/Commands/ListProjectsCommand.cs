using System;
using System.Collections.Generic;
using System.Linq;
using Bytes2you.Validation;
using ProjectManager.CLI.Common;
using ProjectManager.CLI.Core.Commands.Contracts;
using ProjectManager.CLI.Data;

namespace ProjectManager.CLI.Core.Commands
{
    public class ListProjectsCommand : ICommand
    {
        private readonly Database database;

        public ListProjectsCommand(Database database)
        {
            // guard clause
            Guard.WhenArgument(database, "ListProjectsCommand Database").IsNull().Throw();
            this.database = database;
        }

        public string Execute(List<string> parameters)
        {
            if (parameters.Count != 0)
            {
                throw new UserValidationException("Invalid command parameters count!");
            }

            if (parameters.Any(x => x == string.Empty))
            {
                throw new UserValidationException("Some of the passed parameters are empty!");
            }

            return string.Join(Environment.NewLine, this.database.Projects);
        }
    }
}
