namespace Voting
{
    public interface IVotingCategory
    {
        string Name { get; }
        int Votes { get; set; }
        void AddVote();
    }
}
