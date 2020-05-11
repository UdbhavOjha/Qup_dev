using System;
using Qup.Business.Authentication.Models;
using Qup.Business.Authentication;
using System.Web;

namespace Qup
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login_Click(object sender, EventArgs e)
        {
            var userCredentials = new UserSession
            {
                UserName = Request["username"],
                Password = Request["password"],
                IpAddress = Request.UserHostAddress,
                XForwardedFor = Request.Headers["X-Forwarded-For"],
                Browser = HttpContext.Current.Request.Browser.Browser,
                ServerName = Request.ServerVariables["SERVER_NAME"],
                DateCreated = DateTime.Now
            };

            var authentication = new UserAuthenticationManagement();
            var userValidationResults = authentication.AuthenticUserCredentials(userCredentials);

            if (userValidationResults.SessionValidated)
            {
                Response.Cookies["SessionInfo"].Value = userValidationResults.SessionKey;
                Response.Cookies["SessionInfo"].Expires = DateTime.Now.AddHours(3);

                if (userValidationResults.UserGroup == 1)
                {
                    Response.Redirect("/Clients/PatronDashboard.aspx");
                }
                else if (userValidationResults.UserGroup == 2)
                {
                    Response.Redirect("/Manager/Dashboard.aspx");
                }
                else if (userValidationResults.UserGroup == 3)
                {
                    Response.Redirect("/Admins/AdminDashboard.aspx");
                }
            }
        }
    }
}