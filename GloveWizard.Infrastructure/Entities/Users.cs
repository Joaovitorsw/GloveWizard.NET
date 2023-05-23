using System.ComponentModel.DataAnnotations;

namespace GloveWizard.Infrastructure.Entities
{
    public class Users
    {
        [Key]

        public int UserID { get; set; }

        public string UserName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
