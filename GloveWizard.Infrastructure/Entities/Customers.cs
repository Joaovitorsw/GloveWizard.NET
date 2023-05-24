using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GloveWizard.Infrastructure.Entities
{
    [Table("customers")]
    public class Customers
    {
        [Key]
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }

        public ICollection<Contacts> Contacts { get; set; }
    }
}
