namespace Voting
{
    public interface IVotingService
    {
        List<IUser> Users { get; }
        List<IVotingCategory> Categories { get; }

        IUser GetUser(string name);
        IVotingCategory GetCategory(string name);
        bool AddUser(string name);
        bool AddCategory(string name);
        List<string> GetCategories();
        bool CanUserVote(IUser user);
        bool Vote(IUser user, IVotingCategory category);
        void ShowResults();
    }
}
