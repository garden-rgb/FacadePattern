using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsGoF.Facade
{
    public class President
    {
        Facade facade;

        public President()
        {
            facade = new Facade();
        }

        public Clerk ImprisonAnOfficial(Clerk clerk)
        {
            return facade.ImprissionAnOfficial(clerk);
        }

        public Clerk HireAnOfficial(string name,string position)
        {
            return facade.HireAnOfficial(name, position);
        }

        public Clerk ChangeAnOfficial(Clerk clerk, string position)
        {
            return facade.ChangeAnOfficial(clerk, position);
        }

        public PresidentNotes MakeAnAnnouncment(string content)
        {
           return facade.MakeADeclaration(content);
        }
    }
}
