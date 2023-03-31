namespace Voting
{
    public class VotingCategory : IVotingCategory
    {
        public string Name { get; }
        public int Votes { get; set; }

        public VotingCategory(string name)
        {
            Name = name;
            Votes = 0;
        }

        public void AddVote()
        {
            Votes++;
        }
    }
}
