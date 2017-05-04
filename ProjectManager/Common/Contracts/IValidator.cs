using System.Collections.Generic;

namespace ProjectManager.CLI.Common.Contracts
{
    public interface IValidator
    {
        IEnumerable<string> GetValidationErrors(object obj);

        void Validate<T>(T obj) where T : class;
    }
}