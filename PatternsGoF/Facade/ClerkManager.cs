
namespace PatternsGoF.Facade
{
    public class ClerkManager
    {
        public Clerk Hire(string name,string position)
        {
            return new Clerk(name , position);
        }

        public Clerk Dismiss(Clerk clerk)
        {
            clerk.Name = null;
            clerk.Position = null;

            return clerk;
        }

        public Clerk ChangeClerk(Clerk clerk , string position)
        {
            clerk.Position = position;
            return clerk;
        }
    }
}
