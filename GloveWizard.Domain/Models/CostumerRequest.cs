
namespace GloveWizard.Domain.Models
{

    public class CostumerRequest
    {

        public string CustomerName { get; set; }
        public ICollection<Contact?> Contact { get; set; } = new List<Contact?>();

    }

}