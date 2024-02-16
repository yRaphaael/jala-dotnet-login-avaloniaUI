using System;

namespace CustomizedErrors
{
    // Custom exception class for invalid parameter errors
    public class InvalidParameterError : Exception
    {
        // Constructor with parameter name
        public InvalidParameterError(string parameterName) 
            : base($"Invalid value for parameter '{parameterName}'.")
        {
            ParameterName = parameterName;
        }

        // Property to get the parameter name
        public string ParameterName { get; }
    }

    // Custom exception class for invalid name errors
    public class InvalidNameError : Exception
    {
        // Constructor with message
        public InvalidNameError(string message) 
            : base(message)
        {
        }
    }
}