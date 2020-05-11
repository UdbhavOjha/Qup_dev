using System;

namespace Qup.Business.Authentication.Models
{
    public class UserSession
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string IpAddress { get; set; }

        public bool SessionValidated { get; set; }

        public int UserGroup { get; set; }

        public int UserId { get; set; }

        public string Browser { get; set; }

        public string XForwardedFor { get; set; }

        public string ServerName { get; set; }

        public string SessionKey { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
