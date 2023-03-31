using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voting
{

    public class VotingService : IVotingService
    {
        public List<IUser> Users { get; }
        public List<IVotingCategory> Categories { get; }

        public VotingService()
        {
            Users = new List<IUser>();
            Categories = new List<IVotingCategory>();
        }

        public IUser GetUser(string name)
        {
            return Users.Find(u => u.Name == name);
        }

        public List<string> GetCategories()
        {
            return new List<string>();
        }

        public IVotingCategory GetCategory(string name)
        {
            return Categories.Find(c => c.Name == name);
        }

        public bool AddUser(string name)
        {
            if (GetUser(name) != null)
            {
                return false;
            }

            Users.Add(new User(name));
            return true;
        }

        public bool AddCategory(string name)
        {
            if (GetCategory(name) != null)
            {
                return false;
            }

            Categories.Add(new VotingCategory(name));
            return true;
        }

        public bool CanUserVote(IUser user)
        {
            return !user.HasVoted;
        }

        public bool Vote(IUser user, IVotingCategory category)
        {
            if (!CanUserVote(user))
            {
                return false;
            }

            category.AddVote();
            user.HasVoted = true;

            return true;
        }

        public void ShowResults()
        {
            Console.WriteLine("Voting Sonuçları:");

            foreach (IVotingCategory category in Categories)
            {
                int totalVotes = category.Votes;
                int totalUsers = Users.Count;

                double percentage = (double)totalVotes / (totalUsers * 10) * 100;

                Console.WriteLine($"{category.Name}: {category.Votes} ({percentage}%)");
            }
        }
    }
}
