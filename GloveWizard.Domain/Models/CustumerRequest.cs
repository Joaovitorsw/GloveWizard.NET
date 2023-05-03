
namespace GloveWizard.Domain.Models
{

    public class CustumerRequest
    {

        public string CustomerName { get; set; }
        public ICollection<Contact?> Contact { get; set; } = new List<Contact?>();

    }

}