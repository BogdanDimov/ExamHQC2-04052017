namespace ProjectManager.CLI.Models.Contracts
{
    public interface ITask
    {
        string State { get; set; }

        string TaskName { get; set; }

        User TaskOwner { get; set; }

        string ToString();
    }
}