using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsGoF.Facade
{
    interface IFacade
    {
        PresidentNotes MakeADeclaration(string content);
        Clerk ImprissionAnOfficial(Clerk clerk);
        Clerk HireAnOfficial(string name,string position);
        Clerk ChangeAnOfficial(Clerk clerk, string position);
    }
}
