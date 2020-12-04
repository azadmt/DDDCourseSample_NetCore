namespace IdentityServer.Controllers
{
    public class UserModel
    {
        public string Username { get; set; }
        public string EmailAddress { get; set; }
        
        public string[] Roles { get; set; }
    }

    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}