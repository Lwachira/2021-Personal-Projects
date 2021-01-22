using LeadAutomator.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeadAutomator.DataLayer
{
    public class Helper
    {
        public static int ExcludeLeads(List<ExclusionRule> rules, IEnumerable<LeadGeneration> leadGenerations)
        {
            int excludeCounter = 0;

            foreach (var rule in rules)
            {
                try
                {
                    if (rule.Condition == Constant.ContainsCondition)
                    {
                        excludeCounter += RemoveItemsUsingContains(rule, leadGenerations.ToList());
                    }
                    else if (rule.Condition == Constant.EqualsCondition)
                    {
                        excludeCounter += RemoveItemUsingEquals(rule, leadGenerations.ToList());
                    }
                    else if (rule.Condition == Constant.IsEmptyCondition)
                    {
                        excludeCounter += RemoveItemUsingIsEmpty(rule, leadGenerations.ToList());
                    }
                    else if (rule.Condition == Constant.IsUniqueCondition)
                    {
                        excludeCounter += RemoveItemsUsignIsUnique(rule, leadGenerations.ToList());
                    }
                }
                catch
                {

                }

            }

            return excludeCounter;
        }

        private static int RemoveItemsUsignIsUnique(ExclusionRule rule, List<LeadGeneration> leadGenerations)
        {
            int removeCount = 0;

            var leadsDistinct = leadGenerations.GroupBy(i => new
            {
                i.Source,
                i.PeopleSoftID,
                i.CustomerName,
                i.ContactID,
                i.ContactFlag,
                i.Salutation,
                i.ContactName,
                i.ContactEmail
            })
                      .Select(g => g.First())
                      .ToList();

            removeCount = leadGenerations.RemoveAll(i => !leadsDistinct.Contains(i));
            return removeCount;
        }

        private static int RemoveItemUsingIsEmpty(ExclusionRule rule, List<LeadGeneration> leadGenerations)
        {
            int removeCount = 0;

            switch (rule.DataType)
            {
                case Constant.Source:
                    removeCount = leadGenerations.RemoveAll(i => i.Source == null || i.Source == " ");
                    break;
                case Constant.PeopleSoftID:
                    removeCount = leadGenerations.RemoveAll(i => i.PeopleSoftID == null || i.PeopleSoftID == " ");
                    break;
                case Constant.CustomerName:
                    removeCount = leadGenerations.RemoveAll(i => i.CustomerName == null || i.CustomerName == " ");
                    break;
                case Constant.ContactID:
                    removeCount = leadGenerations.RemoveAll(i => i.ContactID == null || i.ContactID == " ");
                    break;
                case Constant.ContactFlag:
                    removeCount = leadGenerations.RemoveAll(i => i.ContactFlag == null || i.ContactFlag == " ");
                    break;
                case Constant.Salutation:
                    removeCount = leadGenerations.RemoveAll(i => i.Salutation == null || i.Salutation == " ");
                    break;
                case Constant.ContactName:
                    removeCount = leadGenerations.RemoveAll(i => i.ContactName == null || i.ContactName == " ");
                    break;

                case Constant.ContactEmail:
                    removeCount = leadGenerations.RemoveAll(i => i.ContactEmail == null || i.ContactEmail == " ");
                    break;
                case Constant.SalesRep:
                    removeCount = leadGenerations.RemoveAll(i => i.SalesRep == null || i.SalesRep == " ");
                    break;
                case Constant.TypeofBusiness:
                    removeCount = leadGenerations.RemoveAll(i => i.TypeofBusiness == null || i.TypeofBusiness == " ");
                    break;
                case Constant.CustomerChannel:
                    removeCount = leadGenerations.RemoveAll(i => i.CustomerChannel == null || i.CustomerChannel == " ");
                    break;
                case Constant.ContactPhoneNumber:
                    removeCount = leadGenerations.RemoveAll(i => i.ContactPhoneNumber == null || i.ContactPhoneNumber == " ");
                    break;
                case Constant.ContactPhoneType:
                    removeCount = leadGenerations.RemoveAll(i => i.ContactPhoneType == null || i.ContactPhoneType == " ");
                    break;
            }

            return removeCount;
        }

        private static int RemoveItemUsingEquals(ExclusionRule rule, List<LeadGeneration> leadGenerations)
        {
            int removeCount = 0;

            switch (rule.DataType)
            {
                case Constant.Source:
                    removeCount = leadGenerations.RemoveAll(i => i.Source != null && i.Source.Equals(rule.Value));
                    break;
                case Constant.PeopleSoftID:
                    removeCount = leadGenerations.RemoveAll(i => i.PeopleSoftID != null && i.PeopleSoftID.Equals(rule.Value));
                    break;
                case Constant.CustomerName:
                    removeCount = leadGenerations.RemoveAll(i => i.CustomerName != null && i.CustomerName.Equals(rule.Value));
                    break;
                case Constant.ContactID:
                    removeCount = leadGenerations.RemoveAll(i => i.ContactID != null && i.ContactID.Equals(rule.Value));
                    break;
                case Constant.ContactFlag:
                    removeCount = leadGenerations.RemoveAll(i => i.ContactFlag != null && i.ContactFlag.Equals(rule.Value));
                    break;
                case Constant.Salutation:
                    removeCount = leadGenerations.RemoveAll(i => i.Salutation != null && i.Salutation.Equals(rule.Value));
                    break;
                case Constant.ContactName:
                    removeCount = leadGenerations.RemoveAll(i => i.ContactName != null && i.ContactName.Equals(rule.Value));
                    break;
                case Constant.ContactEmail:
                    removeCount = leadGenerations.RemoveAll(i => i.ContactEmail != null && i.ContactEmail.Equals(rule.Value));
                    break;
                case Constant.SalesRep:
                    removeCount = leadGenerations.RemoveAll(i => i.SalesRep != null && i.SalesRep != null && i.SalesRep.Equals(rule.Value));
                    break;
                case Constant.TypeofBusiness:
                    removeCount = leadGenerations.RemoveAll(i => i.TypeofBusiness != null && i.TypeofBusiness.Equals(rule.Value));
                    break;
                case Constant.CustomerChannel:
                    removeCount = leadGenerations.RemoveAll(i => i.CustomerChannel != null && i.CustomerChannel.Equals(rule.Value));
                    break;
                case Constant.ContactPhoneNumber:
                    removeCount = leadGenerations.RemoveAll(i => i.ContactPhoneNumber != null && i.ContactPhoneNumber.Equals(rule.Value));
                    break;
                case Constant.ContactPhoneType:
                    removeCount = leadGenerations.RemoveAll(i => i.ContactPhoneType != null && i.ContactPhoneType.Equals(rule.Value));
                    break;
            }

            return removeCount;
        }

        private static int RemoveItemsUsingContains(ExclusionRule rule, List<LeadGeneration> leadGenerations)
        {
            int removeCount = 0;

            switch (rule.DataType)
            {
                case Constant.Source:
                    removeCount = leadGenerations.RemoveAll(i => i.Source != null && i.Source.Contains(rule.Value, StringComparison.OrdinalIgnoreCase));
                    break;
                case Constant.PeopleSoftID:
                    removeCount = leadGenerations.RemoveAll(i => i.PeopleSoftID != null && i.PeopleSoftID.Contains(rule.Value, StringComparison.OrdinalIgnoreCase));
                    break;
                case Constant.CustomerName:
                    removeCount = leadGenerations.RemoveAll(i => i.CustomerName != null && i.CustomerName.Contains(rule.Value, StringComparison.OrdinalIgnoreCase));
                    break;
                case Constant.ContactID:
                    removeCount = leadGenerations.RemoveAll(i => i.ContactID != null && i.ContactID.Contains(rule.Value, StringComparison.OrdinalIgnoreCase));
                    break;
                case Constant.ContactFlag:
                    removeCount = leadGenerations.RemoveAll(i => i.ContactFlag != null && i.ContactFlag.Contains(rule.Value, StringComparison.OrdinalIgnoreCase));
                    break;
                case Constant.Salutation:
                    removeCount = leadGenerations.RemoveAll(i => i.Salutation != null && i.Salutation.Contains(rule.Value, StringComparison.OrdinalIgnoreCase));
                    break;
                case Constant.ContactName:
                    removeCount = leadGenerations.RemoveAll(i => i.ContactName != null && i.ContactName.Contains(rule.Value, StringComparison.OrdinalIgnoreCase));
                    break;
                case Constant.ContactEmail:
                    removeCount = leadGenerations.RemoveAll(i => i.ContactEmail != null && i.ContactEmail.Contains(rule.Value, StringComparison.OrdinalIgnoreCase));
                    break;
                case Constant.SalesRep:
                    removeCount = leadGenerations.RemoveAll(i => i.SalesRep != null && i.SalesRep.Contains(rule.Value, StringComparison.OrdinalIgnoreCase));
                    break;
                case Constant.TypeofBusiness:
                    removeCount = leadGenerations.RemoveAll(i => i.TypeofBusiness != null && i.TypeofBusiness.Contains(rule.Value, StringComparison.OrdinalIgnoreCase));
                    break;
                case Constant.CustomerChannel:
                    removeCount = leadGenerations.RemoveAll(i => i.CustomerChannel != null && i.CustomerChannel.Contains(rule.Value, StringComparison.OrdinalIgnoreCase));
                    break;
                case Constant.ContactPhoneNumber:
                    removeCount = leadGenerations.RemoveAll(i => i.ContactPhoneNumber != null && i.ContactPhoneNumber.Contains(rule.Value, StringComparison.OrdinalIgnoreCase));
                    break;
                case Constant.ContactPhoneType:
                    removeCount = leadGenerations.RemoveAll(i => i.ContactPhoneType != null && i.ContactPhoneType.Contains(rule.Value, StringComparison.OrdinalIgnoreCase));
                    break;
            }

            return removeCount;
        }
    }
}