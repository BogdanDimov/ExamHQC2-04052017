using System.ComponentModel.DataAnnotations;
using System.Text;
using ProjectManager.CLI.Models.Contracts;

namespace ProjectManager.CLI.Models
{
    public class User : IUser
    {
        public User(string username, string email)
        {
            this.UserName = username;
            this.Email = email;
        }

        [Required(ErrorMessage = "User Username is required!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "User Email is required!")]
        [EmailAddress(ErrorMessage = "User Email is not valid!")]
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
