
namespace GloveWizard.Domain.Models
{
    public class Customer
    {

        public int CustomerID { get; set; }
        public string CustomerName { get; set; }

        public ICollection<Contact> Contacts { get; set; } = new List<Contact>();

    }
}

