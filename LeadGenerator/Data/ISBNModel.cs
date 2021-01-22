using System.ComponentModel.DataAnnotations;

namespace LeadAutomator.Data
{
    public class ISBNModel
    {
        [Required]
        public string ISBN { get; set; }
    }
}
