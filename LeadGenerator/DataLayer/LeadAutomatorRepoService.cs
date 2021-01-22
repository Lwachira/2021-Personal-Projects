using Dapper;
using LeadAutomator.Data;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace LeadAutomator.DataLayer
{
    public class LeadAutomatorRepoService : ILeadAutomatorRepoService
    {
        private IConfiguration _configuration;


        public LeadAutomatorRepoService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IEnumerable<ISBNInformation> ISBNInformationList(IEnumerable<string> isbnlist) // Change isbnList to use IEnumerable<string>
        {
            IEnumerable<ISBNInformation> iSBNInformation;

            using (var conn = new SqlConnection(_configuration.GetConnectionString("SqlDBcontext")))
            {
                //conn.Open();

                var dt = new DataTable();
                dt.Columns.Add("ISBN");

                foreach (string isbn in isbnlist)
                {
                    dt.Rows.Add(isbn);
                }

                iSBNInformation = conn.Query<ISBNInformation>("[usp_LeadAutomationLeadSummary]", new { ISBN = dt.AsTableValuedParameter("ISBNTableType") }, commandType: CommandType.StoredProcedure);

            }
            return iSBNInformation;
        }


        public IEnumerable<LeadGeneration> GetLeadGenerations(IEnumerable<string> isbnlist)
        {
            IEnumerable<LeadGeneration> leads;

            using (var conn = new SqlConnection(_configuration.GetConnectionString("SqlDBcontext")))
            {
                // conn.Open();

                var dt = new DataTable();
                dt.Columns.Add("ISBN");

                foreach (string isbn in isbnlist)
                {
                    dt.Rows.Add(isbn);
                }

                leads = conn.Query<LeadGeneration>("[usp_LeadAutomationLeadList]", new { ISBN = dt.AsTableValuedParameter("ISBNTableType") }, commandTimeout: 300, commandType: CommandType.StoredProcedure);
            }
            return leads;

        }
    }
}
