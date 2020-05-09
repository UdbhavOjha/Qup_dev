using System;
using Qup.Business.Authentication.Models;
using Qup.Business.Authentication;

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
                IpAddress = Request.UserHostAddress
            };

            var authentication = new UserAuthenticationManagement();
            var userValidationResults = authentication.AuthenticUserCredentials(userCredentials);

            if (userValidationResults.SessionValidated)
            {
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

            //if (!sessionStatus.Equals("failed"))
            //{
            //    HttpCookie sessionInfo = new HttpCookie("SessionInfo");
            //    sessionInfo["Session"] = sessionStatus;

            //    Response.Cookies.Add(sessionInfo);
            //    Response.Redirect("/Admin/Users/Dashboard.aspx");
            //}
        }
    }
}