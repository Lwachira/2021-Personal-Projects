using LeadAutomator.DataLayer;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace LeadAutomator.Data
{
    public class LeadAutomatorServiceBase
    {
        private readonly IConfiguration _configuration;


        public LeadAutomatorServiceBase(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        //Exclusion Logic 
        public void AddStandardExclusion(string selectedRule, bool isSelected, List<ExclusionRule> standardExclusionRules)
        {
            if (selectedRule == Constant.Advocate && isSelected)
            {
                ExclusionRule rule = new ExclusionRule()
                {
                    Condition = Constant.EqualsCondition,
                    DataType = Constant.CustomerChannel,
                    Value = Constant.AdvocatesRule
                };
                AddToStandardExclusionList(rule, standardExclusionRules);

            }
            if (selectedRule == Constant.University && isSelected)
            {
                ExclusionRule rule = new ExclusionRule()
                {
                    Condition = Constant.EqualsCondition,
                    DataType = Constant.CustomerChannel,
                    Value = Constant.UniversityRule
                };

                AddToStandardExclusionList(rule, standardExclusionRules);
            }
            if (selectedRule == Constant.Bookshop && isSelected)
            {
                ExclusionRule rule = new ExclusionRule()
                {
                    Condition = Constant.EqualsCondition,
                    DataType = Constant.CustomerChannel,
                    Value = Constant.BookshopRule
                };

                AddToStandardExclusionList(rule, standardExclusionRules);
            }
            if (selectedRule == Constant.Student && isSelected)
            {
                ExclusionRule rule = new ExclusionRule()
                {
                    Condition = Constant.EqualsCondition,
                    DataType = Constant.CustomerChannel,
                    Value = Constant.StudentRule
                };

                AddToStandardExclusionList(rule, standardExclusionRules);
            }
            if (selectedRule == Constant.KeyAccount && isSelected)
            {
                foreach (string item in Constant.KeyAccountRule)
                {
                    ExclusionRule rule = new ExclusionRule()
                    {
                        Condition = Constant.EqualsCondition,
                        DataType = Constant.SalesRep,
                        Value = item
                    };

                    AddToStandardExclusionList(rule, standardExclusionRules);
                }
            }
            if (selectedRule == Constant.Juta && isSelected)
            {
                ExclusionRule jutaCustomerNameRule = new ExclusionRule()
                {
                    Condition = Constant.ContainsCondition,
                    DataType = Constant.CustomerName,
                    Value = "Juta"
                };

                ExclusionRule jutaEmaiRule = new ExclusionRule()
                {
                    Condition = Constant.ContainsCondition,
                    DataType = Constant.ContactEmail,
                    Value = "Juta"
                };

                AddToStandardExclusionList(jutaCustomerNameRule, standardExclusionRules);
                AddToStandardExclusionList(jutaEmaiRule, standardExclusionRules);

            }
            if (selectedRule == Constant.InternalStaff && isSelected)
            {
                foreach (string item in Constant.InternalStaffRule)
                {
                    ExclusionRule rule = new ExclusionRule()
                    {
                        Condition = Constant.ContainsCondition,
                        DataType = Constant.ContactEmail,
                        Value = item
                    };

                    AddToStandardExclusionList(rule, standardExclusionRules);
                }
            }
            if (selectedRule == Constant.TrialAccount && isSelected)
            {

            }
            if (selectedRule == Constant.Unique && isSelected)
            {
                ExclusionRule rule = new ExclusionRule()
                {
                    Condition = Constant.IsUniqueCondition,
                    DataType = Constant.Unique,
                    Value = Constant.UniqueRule
                };

                AddToStandardExclusionList(rule, standardExclusionRules);
            }
            if (selectedRule == Constant.ContactPhoneType && isSelected)
            {
                ExclusionRule rule = new ExclusionRule()
                {
                    Condition = Constant.ContainsCondition,
                    DataType = Constant.ContactPhoneType,
                    Value = Constant.ContactFaxRule
                };

                AddToStandardExclusionList(rule, standardExclusionRules);
            }
        }

        public void AddToStandardExclusionList(ExclusionRule exclusionRule, List<ExclusionRule> standardExclusionRules)
        {
            standardExclusionRules.Add(exclusionRule);
        }

        public void AddCustomExclusion(ExclusionRule exclusionRule, List<ExclusionRule> customExclusionRules)
        {
            customExclusionRules.Add(exclusionRule);
        }


        // Database Retrevial Logic 
        public List<ISBNInformation> GetISBNInformationFromDatabase(IEnumerable<string> isbnList)
        {
            //if (isbnList?.Any() ?? false)
            // Look into extension methods

            if (isbnList != null && isbnList.Any())
            {
                LeadAutomatorRepoService leadAutomatorRepoService = new LeadAutomatorRepoService(_configuration);
                var iSBNInformation = leadAutomatorRepoService.ISBNInformationList(isbnList);
                return iSBNInformation.ToList();
            }

            return null; // Change nulls to empty lists

        }

        public List<LeadGeneration> GetLeadGenerationFromDatabase(IEnumerable<string> isbnList)
        {
            if (isbnList != null && isbnList.Any())
            {
                LeadAutomatorRepoService leadAutomatorRepoService = new LeadAutomatorRepoService(_configuration);

                var leadGenerations = leadAutomatorRepoService.GetLeadGenerations(isbnList);
                return leadGenerations.ToList();
            }
            else
            {
                return null;
            }
        }
    }
}