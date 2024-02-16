using System.Text;

namespace UserAccount
{
    public class User
    {
        // Properties
        public string Email { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }

        // Constructor
        public User(string name, string email, string surname)
        {
            Name = name;
            Email = email;
            Surname = surname;
        }

        // Method to override ToString() and provide a custom representation of the object
        public override string ToString()
        {
            StringBuilder text = new StringBuilder();

            // Append email and surname
            text.Append($"Email: {Email}\n");
            text.Append($"Surname: {Surname}");

            return text.ToString();
        }
    }
}