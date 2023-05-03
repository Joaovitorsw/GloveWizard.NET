
namespace GloveWizard.Domain.Models
{
    public class Custumer
    {

        public int CustomerID { get; set; }
        public string CustomerName { get; set; }

        public ICollection<Contact?> Contact { get; set; } = new List<Contact?>();

    }
}

