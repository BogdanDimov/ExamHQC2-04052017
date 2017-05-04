using System.ComponentModel.DataAnnotations;
using System.Text;
using ProjectManager.CLI.Models.Contracts;

namespace ProjectManager.CLI.Models
{
    public class User : IUser
    {
        private const string UsernameRequiredMessage = "User Username is required!";
        private const string EmailRequiredMessage = "User Email is required!";
        private const string EmailNotValidMessage = "User Email is not valid!";

        public User(string username, string email)
        {
            this.UserName = username;
            this.Email = email;
        }

        [Required(ErrorMessage = UsernameRequiredMessage)]
        public string UserName { get; set; }

        [Required(ErrorMessage = EmailRequiredMessage)]
        //[EmailAddress(ErrorMessage = EmailNotValidMessage)]
        public string Email { get; set; }

        public override string ToString()
        {
            var b = new StringBuilder();
            b.AppendLine("    Username: " + this.UserName);
            b.AppendLine("    Email: " + this.Email);
            return b.ToString();
        }
    }
}
