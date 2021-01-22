using ClosedXML.Excel;
using CsvHelper;
using GridMvc.Server;
using GridShared;
using GridShared.Utility;
using LeadAutomator.DataLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace LeadAutomator.Data
{
    public class LeadAutomatorService : LeadAutomatorServiceBase
    {
        public LeadAutomatorService(IConfiguration configuration) : base(configuration)
        {

        }


        public int GenerateCustomReport(List<ExclusionRule> customExclusionRules, IEnumerable<LeadGeneration> _leads)
        {
            int excludeCounter = 0;


            if (_leads.Count() > 0)
            {
                excludeCounter = Helper.ExcludeLeads(customExclusionRules, _leads);
            }

            return excludeCounter;

        }

        public int GenerateStandardReport(List<ExclusionRule> standardExclusionRules, IEnumerable<LeadGeneration> _leads)
        {
            int excludeCounter = 0;



            if (_leads.Count() > 0)
            {
                excludeCounter = Helper.ExcludeLeads(standardExclusionRules, _leads);
            }

            return excludeCounter;
        }

        public ItemsDTO<LeadGeneration> GetOrdersGridRows(Action<IGridColumnCollection<LeadGeneration>> columns, QueryDictionary<StringValues> query,
            IEnumerable<LeadGeneration> _leads)
        {

            var server = new GridServer<LeadGeneration>(_leads, new QueryCollection(query), true, "ordersGrid", columns, 10)
                .Sortable()
                .Filterable()
                .WithMultipleFilters();


            // return items to displays
            return server.ItemsToDisplay;
        }



        public byte[] GenerateExcel(IEnumerable<LeadGeneration> _leads)
        {
            byte[] excelFileBytes;

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Leads");
                var currentRow = 1;

                worksheet.Cell(currentRow, 1).Value = "Source";
                worksheet.Cell(currentRow, 2).Value = "PeopleSoftID";
                worksheet.Cell(currentRow, 3).Value = "CustomerName";
                worksheet.Cell(currentRow, 4).Value = "ContactID";
                worksheet.Cell(currentRow, 5).Value = "ContactFlag";
                worksheet.Cell(currentRow, 6).Value = "Salutation";
                worksheet.Cell(currentRow, 7).Value = "ContactName";
                worksheet.Cell(currentRow, 8).Value = "ContactEmail";
                worksheet.Cell(currentRow, 9).Value = "TypeofBusiness";
                worksheet.Cell(currentRow, 10).Value = "ContactPhoneNumber";

                foreach (var item in _leads)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).SetValue(item.Source);
                    worksheet.Cell(currentRow, 2).SetValue(item.PeopleSoftID);
                    worksheet.Cell(currentRow, 3).SetValue(item.CustomerName);
                    worksheet.Cell(currentRow, 4).SetValue(item.ContactID);
                    worksheet.Cell(currentRow, 5).SetValue(item.ContactFlag);
                    worksheet.Cell(currentRow, 6).SetValue(item.Salutation);
                    worksheet.Cell(currentRow, 7).SetValue(item.ContactName);
                    worksheet.Cell(currentRow, 8).SetValue(item.ContactEmail);
                    worksheet.Cell(currentRow, 9).SetValue(item.TypeofBusiness);
                    worksheet.Cell(currentRow, 9).SetValue(item.CustomerChannel);
                    worksheet.Cell(currentRow, 10).SetValue(item.ContactPhoneNumber);
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    excelFileBytes = stream.ToArray();
                }
                return excelFileBytes;
            }
        }

        public byte[] GenerateCSV(IEnumerable<LeadGeneration> _leads)
        {
            byte[] csvFileBytes;

            using (var memoryStream = new MemoryStream())
            {
                using (var writer = new StreamWriter(memoryStream))
                {
                    using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                    {
                        csv.WriteHeader(typeof(LeadGeneration));
                        csv.NextRecord();
                        csv.WriteRecords(_leads);
                    }
                }
                csvFileBytes = memoryStream.ToArray(); // Stores the CSV file that we just created as a byte array
            }

            return csvFileBytes;

        }


    }
}
