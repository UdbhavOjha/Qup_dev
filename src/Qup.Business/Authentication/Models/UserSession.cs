namespace Qup.Business.Authentication.Models
{
    public class UserSession
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string IpAddress { get; set; }

        public bool SessionValidated { get; set; }

        public int UserGroup { get; set; }
    }
}
