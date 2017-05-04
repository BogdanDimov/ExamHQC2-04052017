using System.ComponentModel.DataAnnotations;
using System.Text;
using ProjectManager.CLI.Models.Contracts;

namespace ProjectManager.CLI.Models
{
    public class Task : ITask
    {
        public Task(string name, User taskOwner, string state)
        {
            this.TaskName = name;
            this.TaskOwner = taskOwner;
            this.State = state;
        }

        [Required(ErrorMessage = "Task Name is required!")]
        public string TaskName { get; set; }

        [Required(ErrorMessage = "Task Owner is required")]
        public User TaskOwner { get; set; }

        public string State { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.AppendLine("    Name: " + this.TaskName);
            builder.Append("    State: " + this.State);

            return builder.ToString();
        }
    }
}
