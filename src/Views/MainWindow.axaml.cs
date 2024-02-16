using System;
using Assignment3.ViewModels;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using CustomizedErrors;
using UserAccount;

namespace Assignment3.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Event handler for the sign-up button
        public void Handle(object sender, RoutedEventArgs e)
        {
            try
            {
                // Retrieve input values
                string? nameText = name.Text;
                string? emailText = email.Text;
                string? surnameText = surname.Text;

                // Check if all fields are filled
                bool existsAllFields = string.IsNullOrEmpty(nameText) || string.IsNullOrEmpty(emailText) || string.IsNullOrEmpty(surnameText);
                if (existsAllFields) return;

                // Create a new user object
                User user = new User(nameText!, emailText!, surnameText!);
                // Add the user to the ViewModel
                MainWindowViewModel.AddNewUser(user);

                // Display success message
                successLabel.Text = $"Congratulations! You've successfully signed up. Welcome to our community {user.Name}";
                successLabel.IsVisible = true;
                errorLabel.IsVisible = false;

                // Clear input fields
                Clear();
            }
            catch (Exception ex)
            {
                // Handle any exceptions and display error message
                HandleError(ErrorStack.PopError(), ex);
            }
        }

        // Method to handle errors
        private void HandleError(string errorMessage, Exception exception)
        {
            // Display error message
            errorLabel.Text = errorMessage;
            errorLabel.IsVisible = true;
            successLabel.IsVisible = false;
        }

        // Event handler for filtering users by email
        private void FilterTextUpdate(object sender, KeyEventArgs e)
        {
            // Call the ViewModel method to filter users
            MainWindowViewModel.FilterUser(filterByEmail.Text);
        }

        // Method to clear input fields
        private void Clear()
        {
            name.Text = "";
            email.Text = "";
            surname.Text = "";
        }
    }
}
