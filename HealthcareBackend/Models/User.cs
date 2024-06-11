

namespace HealthcareBackend.Models
{
    public class User
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
    }
    public class RegisterModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        
    }

    public class LoginModel
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
    }

    public class ForgetPasswordModel
    {
         public string ResetToken { get; set; }
    }
}
