using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GloveWizard.Infrastructure.Entities
{
    public class Contacts
    {
        [Key]
        public int ContactID { get; set; }

        [ForeignKey("CustomerID")]
        public int CustomerID { get; set; }
        public string ContactName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public Customers Customers { get; set; }
    }
}
