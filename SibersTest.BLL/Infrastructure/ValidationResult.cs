using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SibersTest.BLL.Infrastructure
{
    /// <summary>
    /// Describes result of model validation in business logic layer.
    /// </summary>
    public class ValidationResult
    {
        public string Key { get; private set; }
        public string ErrorMessage { get; private set; }

        public ValidationResult(string key, string errorMessage) : this(errorMessage)
        {
            Key = key;
        }

        public ValidationResult(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
}
