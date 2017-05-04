using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using ProjectManager.CLI.Common.Contracts;

namespace ProjectManager.CLI.Common
{
    public class Validator : IValidator
    {
        public void Validate<T>(T obj) where T : class
        {
            var validationErrors = this.GetValidationErrors(obj);

            if (validationErrors.Count() != 0)
            {
                throw new UserValidationException(validationErrors.First());
            }
        }

        public IEnumerable<string> GetValidationErrors(object obj)
        {
            var type = obj.GetType();
            var properties = type.GetProperties();
            var attrType = typeof(ValidationAttribute);

            foreach (var propertyInfo in properties)
            {
                var customAttributes = propertyInfo.GetCustomAttributes(attrType, inherit: true);
                foreach (var customAttribute in customAttributes)
                {
                    var validationAttribute = (ValidationAttribute)customAttribute;
                    var valid = validationAttribute.IsValid(propertyInfo.GetValue(obj, BindingFlags.GetProperty, null, null, null));

                    if (!valid)
                    {
                        yield return validationAttribute.ErrorMessage;
                    }
                }
            }
        }
    }
}