
namespace GloveWizard.Domain.Models
{

    public class LoginResponse 
    {

        public int UserID { get; set; }
        public string Token { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime ExpiresDate { get; set; }

        public List<string> Roles { get; set; }

    }

}