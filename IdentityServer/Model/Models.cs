using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Model
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

    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }

    }

    public class SecurityToken
    {
        public string Username { get; set; }
        public string[] Roles { get; set; }
    }

    //public class UserPermission
    //{
    //    public int UserId { get; set; }
    //    public string Name { get; set; }
    //}
}
