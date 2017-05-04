using System.Collections.Generic;
using System.Linq;
using ProjectManager.CLI.Common;
using ProjectManager.CLI.Data;
using ProjectManager.CLI.Factories;

namespace ProjectManager.CLI.Core.Commands
{
    public class CreateUserCommand
    {
        private const string InvalidParametersCountError = "Invalid command parameters count!";
        private const string EmptyParametersError = "Some of the passed parameters are empty!";
        private const string SuccessMessage = "Successfully created a new user!";
        private const string UserAlreadyExistsError = "A user with that username already exists!";

        public string Execute(List<string> prms)
        {
            var database = new Database();
            var modelsFactory = new ModelsFactory();

            if (prms.Count != 3)
            {
                throw new UserValidationException(InvalidParametersCountError);
            }

            if (prms.Any(x => x == string.Empty))
            {
                throw new UserValidationException(EmptyParametersError);
            }

            if (database.Projects[int.Parse(prms[0])].Users.Any() &&
                database.Projects[int.Parse(prms[0])].Users.Any(x => x.UserName == prms[1]))
            {
                throw new UserValidationException(UserAlreadyExistsError);
            }

            database.Projects[int.Parse(prms[0])].Users.Add(modelsFactory.CreateUser(prms[1], prms[2]));

            return SuccessMessage;
        }
    }
}