
namespace GloveWizard.Domain.Models
{

    public class LoginResponse 
    {

        public int UserID { get; set; }
        public string Token { get; set; }
        public string UserName { get; set; }
        public DateTime ExpiresDate { get; set; }

    }

}