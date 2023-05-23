using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GloveWizard.Infrastructure.Entities
{
    [Table("customers")]
    public class Customers
    {
        [Key]
        public int customer_id { get; set; }
        public string customer_name { get; set; }

        public ICollection<Contacts> contacts { get; set; }
    }
}
