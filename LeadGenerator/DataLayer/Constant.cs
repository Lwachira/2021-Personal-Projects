namespace LeadAutomator.DataLayer
{
    public class Constant
    {
        //Condition 
        public const string ContainsCondition = "Contains";
        public const string EqualsCondition = "Equals";
        public const string IsEmptyCondition = "IsEmpty";
        public const string IsUniqueCondition = "IsUnique";

        //Data Type

        public const string Source = "Source";
        public const string PeopleSoftID = "PeopleSoftID";
        public const string CustomerName = "CustomerName";
        public const string ContactID = "ContactID";
        public const string ContactFlag = "ContactFlag";
        public const string Salutation = "Salutation";
        public const string ContactName = "ContactName";
        public const string ContactEmail = "ContactEmail";
        public const string SalesRep = "SalesRep";

        public const string TypeofBusiness = "TypeofBusiness";
        public const string CustomerChannel = "CustomerChannel";
        public const string ContactPhoneNumber = "ContactPhoneNumber";
        public const string ContactPhoneType = "ContactPhoneType";

        public const string Advocate = "Advocate";
        public const string University = "University";
        public const string Bookshop = "Bookshop";
        public const string KeyAccount = "KeyAccount";
        public const string Juta = "Juta";
        public const string InternalStaff = "InternalStaff";
        public const string TrialAccount = "TrialAccount";
        public const string Student = "Student";
        public const string Unique = "Unique";


        //Value

        //Standard Exclusion Rules

        public static readonly string AdvocatesRule = "LAD";

        public static readonly string UniversityRule = "ACA";

        public static readonly string BookshopRule = "BOO";

        public static readonly string StudentRule = "STU";

        public static readonly string[] KeyAccountRule = {
            "SALES-THABO THAGE",
            "SALES-DEON STRYDOM(PROFES)",
            "SALES-NGUBANE,REFILWE",
            "SALES-Natalie Wyatt",
            "SALES-HAYDEN NUNDHLAL(DBN)",
            "SALES-RENIECE MOSES (DBN)",
            "SALES-MUNEEB WADEE (CORP)",
            "SALES-NATALIE SANGSTER(BO)",
            "SALES-CAROL COETZEE (JHB)",
            "SALES-LUTFIYYA YACOOB(PRO)",
            "SALES-RENE GRIMMBACHER",
            "SALES-ROWAN WILLIAMS",
            "SALES-BEV LE ROUX B-SHOPS",
            "SALES-CHANTAL LAMPRECHT",
            "SALES-NTAKISHA KYAL(IOS)NS",
            "SALES-CBA WEB ORDERS",
            "SALES-MICHELLE BAKER(ADV)"
        };

        public static readonly string[] InternalStaffRule =
        {
            "lexisnexis.co.za",
            "korbitec.com",
            "kaleidocode.co.za",
            "kcpivot.co.za",
            "kcdev.co.za",
            "kc.co.za",
            "kcp.co.za",
            "ln.co.za",
            "cloudseed.io",
        };

        public static readonly string UniqueRule = "Remove all duplicated values";

        public static readonly string ContactFaxRule = "Fax";

    }
}
