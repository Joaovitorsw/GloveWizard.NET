
namespace GloveWizard.Domain.Models
{

    public class CustomerRequest
    {

        public string CustomerName { get; set; }
        public ICollection<Contact> Contacts { get; set; } = new List<Contact>();

    }

}