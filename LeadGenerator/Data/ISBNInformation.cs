namespace LeadAutomator.Data
{
    public class ISBNInformation
    {
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string ProductDescription { get; set; }

        public string ProductLevel4Description { get; set; }
        public string MinPeriod { get; set; }
        public string MaxPeriod { get; set; }
        public string BilledAmount { get; set; }
        public string Quantity { get; set; }
        public string ALL_CUSTOMERS_SALES { get; set; }
    }
}
