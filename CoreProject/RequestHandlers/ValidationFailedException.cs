using System;
using System.Collections.Generic;

namespace Dell.FRDI.Core.RequestHandlers.Pipeline
{
    internal class ValidationFailedException: Exception
    {
        private Dictionary<string, IEnumerable<string>> _errors;

        public ValidationFailedException(Dictionary<string, IEnumerable<string>> errors) : base("Validation failed")
        {
            _errors = errors;
        }
    }
}