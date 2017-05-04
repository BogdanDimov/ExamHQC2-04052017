namespace ProjectManager.CLI.Models.Contracts
{
    public interface IUser
    {
        string Email { get; set; }

        string UserName { get; set; }

        string ToString();
    }
}