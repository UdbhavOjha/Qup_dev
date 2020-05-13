using System;
using Qup.Business.Authentication.Models;
using Qup.Business.Authentication;
using System.Web;

namespace Qup
{
    public partial class Login : System.Web.UI.Page
    {
        protected string cookiesOnBrowser;
        protected void Page_Load(object sender, EventArgs e)
        {            
            Verify();
        }

        protected void login_Click(object sender, EventArgs e)
        {
            Verify();
        }

        private void Verify() 
        {
            string userCookie = Request.Cookies["User"] != null ? Request.Cookies["User"].Value : string.Empty;

            var userCredentials = new UserSession
            {
                UserName = Request["username"],
                Password = Request["password"],
                IpAddress = Request.UserHostAddress,
                XForwardedFor = Request.Headers["X-Forwarded-For"],
                Browser = HttpContext.Current.Request.Browser.Browser,
                ServerName = Request.ServerVariables["SERVER_NAME"],
                DateCreated = DateTime.Now,
                UserKey = userCookie
            };

            var authentication = new UserAuthenticationManagement();
            UserSession userValidationResults = new UserSession();

            if (userCredentials.UserName != null)
            {
                userValidationResults = authentication.AuthenticUserCredentials(userCredentials);
            }
            else if (userCookie != string.Empty)
            {
                userValidationResults = authentication.AuthenticateUserByCookie(userCredentials);
            }


            if (userValidationResults.SessionValidated)
            {
                Response.Cookies["SessionInfo"].Value = userValidationResults.SessionKey;
                Response.Cookies["SessionInfo"].Expires = DateTime.Now.AddHours(3);
                Response.Cookies["User"].Value = userValidationResults.UserKey;

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