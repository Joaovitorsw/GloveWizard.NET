using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GloveWizard.Infrastructure.Entities
{

    public class Contacts
    {

        [Key]
        public int contact_id { get; set; }

        [ForeignKey("customer_id")]
        public int customer_id { get; set; }
        public string contact_name  { get; set; }
        public string  phone { get; set; }
        public string email { get; set; }

        public  Customers customers { get; set; }

    }
}