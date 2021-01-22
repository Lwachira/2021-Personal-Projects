using LeadAutomator.Data;
using System.Collections.Generic;

namespace LeadAutomator.Services
{
    public class AppData
    {
        public IEnumerable<string> ISBNList { get; set; }

        public IEnumerable<LeadGeneration> Leads { get; set; }

        public IEnumerable<ISBNInformation> ISBNInformation { get; set; }
    }
}
