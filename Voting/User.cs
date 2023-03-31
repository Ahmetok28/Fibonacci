namespace Voting
{
    public class User : IUser
    {
        public string Name { get; }
        public bool HasVoted { get; set; }

        public User(string name)
        {
            Name = name;
            HasVoted = false;
        }
    }
}
