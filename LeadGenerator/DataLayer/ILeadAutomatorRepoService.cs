using LeadAutomator.Data;
using System.Collections.Generic;

namespace LeadAutomator.DataLayer
{
    interface ILeadAutomatorRepoService
    {
        IEnumerable<ISBNInformation> ISBNInformationList(IEnumerable<string> isbn);
        IEnumerable<LeadGeneration> GetLeadGenerations(IEnumerable<string> isbnlist);
    }
}
