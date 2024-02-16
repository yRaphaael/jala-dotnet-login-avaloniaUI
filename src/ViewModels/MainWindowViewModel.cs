using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CustomizedErrors;
using UserAccount;

namespace Assignment3.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        // Collection to hold all users
        public static ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>();

        // Collection to hold users before any update or filter operation
        public static ObservableCollection<User> UsersBeforeUpdate { get; set; } = new ObservableCollection<User>();

        // Method to add a new user
        public static void AddNewUser(User user)
        {
            // Save user in database
            Database.CreateInstance().SaveUser(user);
            // Add user to Users collection
            Users.Add(user);
            // Add user to UsersBeforeUpdate collection
            UsersBeforeUpdate.Add(user);
        }

        // Method to filter users by email
        public static void FilterUser(string? textToFilter) 
        {
            if (textToFilter == null) return; // Verificar se textToFilter não é null

            string textWithoutSpace = textToFilter.Trim();
            if (IsNullOrEmptyText(textWithoutSpace)) return;
            CheckIfNotHaveUserToFilter();

            List<User> filteredUsers = Users.Where(obj => obj.Email.Contains(textWithoutSpace)).ToList();

            Users.Clear();
            ImplementFilteredUsers(filteredUsers);
        }

        private void Validators(User user) 
        {
            string errorMessage = "";
            if (user.Email != null && !Validator.ValidateEmail(user.Email)) 
            {
                errorMessage = "email";
                ErrorStack.PushError(errorMessage);
            }
            if (user.Surname != null && !Validator.ValidateName(user.Surname)) 
            {
                errorMessage = "surname";
                ErrorStack.PushError(errorMessage);
            }
            if (user.Name != null && !Validator.ValidateName(user.Name)) 
            {
                errorMessage = "name";
                ErrorStack.PushError(errorMessage);
            }

            if (!string.IsNullOrEmpty(errorMessage)) throw new InvalidParameterError(errorMessage);
        }


        // Method to check if filter text is null or empty
        public static bool IsNullOrEmptyText(string? text)
        {
            if (string.IsNullOrEmpty(text))
            {
                // Clear Users collection
                Users.Clear();
                // Add all users from UsersBeforeUpdate collection to Users collection
                foreach (User user in UsersBeforeUpdate)
                {
                    Users.Add(user);
                }

                return true;
            }

            return false;
        }

        // Method to check if Users collection is empty and add all users from UsersBeforeUpdate collection
        public static void CheckIfNotHaveUserToFilter()
        {
            if (Users.Count == 0)
            {
                // Add all users from UsersBeforeUpdate collection to Users collection
                foreach (User user in UsersBeforeUpdate)
                {
                    Users.Add(user);
                }
            }
        }

        // Method to add filtered users to Users collection
        public static void ImplementFilteredUsers(System.Collections.Generic.List<User> filteredUsers)
        {
            // Add filtered users to Users collection
            foreach (User user in filteredUsers)
            {
                Users.Add(user);
            }
        }
    }
}
