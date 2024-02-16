using System.Collections.ObjectModel;
using CustomizedErrors;
using UserAccount;

public class Database
{
    private static Database? instance;
    private readonly ObservableCollection<User> users = new ObservableCollection<User>();

    // Private constructor to enforce singleton pattern
    private Database() { }

    // Method to create a singleton instance of Database
    public static Database CreateInstance()
    {
        instance ??= new Database();
        return instance;
    }

    // Method to save a user to the database
    public void SaveUser(User user)
    {
        // Validate user data
        Validators(user);

        // Add user to the collection
        users.Add(user);

        // Notify observers about the user addition
        NotifyObservers($"User {user.Email} has been added.");
    }

    // Method to perform data validation
    private void Validators(User user)
    {
        string errorMessage = "";

        // Validate email
        if (!Validator.ValidateEmail(user.Email))
        {
            errorMessage = "email";
            ErrorStack.PushError(errorMessage);
        }

        // Validate surname
        if (!Validator.ValidateName(user.Surname))
        {
            errorMessage = "surname";
            ErrorStack.PushError(errorMessage);
        }

        // Validate name
        if (!Validator.ValidateName(user.Name))
        {
            errorMessage = "name";
            ErrorStack.PushError(errorMessage);
        }

        // Throw an exception if there's any validation error
        if (!string.IsNullOrEmpty(errorMessage))
        {
            throw new InvalidParameterError(errorMessage);
        }
    }

    // Method to notify observers about user-related actions
    private void NotifyObservers(string message)
    {
        MessageObserver messageObserver = new MessageObserver();
        Subject subject = new Subject();
        subject.Attach(messageObserver);
        subject.Notify(message);
    }

    // Method to retrieve all users from the database
    public ObservableCollection<User> GetUsers()
    {
        return users;
    }
}
