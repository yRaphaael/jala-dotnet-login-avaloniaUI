using System.Text.RegularExpressions;

public class Validator
{
    // Method to validate an email address
    public static bool ValidateEmail(string email)
    {
        // Regular expression pattern for validating email addresses
        string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        // Create a Regex object with the pattern
        Regex regex = new Regex(pattern);

        // Check if the email matches the pattern
        return regex.IsMatch(email);
    }

    // Method to validate a name
    public static bool ValidateName(string name)
    {
        // Regular expression pattern for validating names
        string pattern = @"^[a-zA-Z0-9_-]{3,16}$";
        // Create a Regex object with the pattern
        Regex regex = new Regex(pattern);

        // Check if the name matches the pattern
        return regex.IsMatch(name);
    }
}