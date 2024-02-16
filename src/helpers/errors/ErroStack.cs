using System;
using System.Collections.Generic;

public class ErrorStack
{
    // Use a generic list instead of Stack<T> to allow for easier iteration and peeking
    private static readonly List<ErrorInfo> stack = new List<ErrorInfo>();

    // Method to push an error message onto the stack
    public static void PushError(string errorMessage)
    {
        var errorInfo = new ErrorInfo(errorMessage, DateTime.Now);
        stack.Add(errorInfo);
    }

    // Method to pop an error message from the stack
    public static string PopError()
    {
        if (stack.Count == 0)
        {
            return "No errors in the stack.";
        }
        else
        {
            // Remove and return the last error info from the stack
            var errorInfo = stack[stack.Count - 1];
            stack.RemoveAt(stack.Count - 1);
            return $"[{errorInfo.Timestamp}] Invalid parameter error: {errorInfo.ErrorMessage}";
        }
    }

    // Method to peek at all errors in the stack
    public static string PeekErrors()
    {
        if (stack.Count == 0)
        {
            return "No errors in the stack.";
        }

        // Construct a string with all errors in the stack
        string errors = "Errors in the stack:\n";
        foreach (var errorInfo in stack)
        {
            errors += $"[{errorInfo.Timestamp}] {errorInfo.ErrorMessage}\n";
        }
        return errors;
    }

    // Nested class to encapsulate error information
    private class ErrorInfo
    {
        public string ErrorMessage { get; }
        public DateTime Timestamp { get; }

        // Constructor to initialize error message and timestamp
        public ErrorInfo(string errorMessage, DateTime timestamp)
        {
            ErrorMessage = errorMessage;
            Timestamp = timestamp;
        }
    }
}