using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsGoF.Facade
{
    class Facade : IFacade
    {
        private PresidentNotes notes;
        private ClerkManager clerkManager;

        public Facade()
        {
            clerkManager = new ClerkManager();
            notes = new PresidentNotes();
        }

        public Clerk ChangeAnOfficial(Clerk clerk, string position)
        {
            return clerkManager.ChangeClerk(clerk, position);
        }

        public Clerk HireAnOfficial(string name,string position)
        {
            return clerkManager.Hire(name, position);
        }

        public Clerk ImprissionAnOfficial(Clerk clerk)
        {
            return clerkManager.Dismiss(clerk);
        }

        public PresidentNotes MakeADeclaration(string content)
        {
            return notes.MakeAnAnnouncment(content);
        }
    }
}
