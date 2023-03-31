namespace Voting
{
    public interface IUser
    {
        string Name { get; }
        bool HasVoted { get; set; }
    }
}
