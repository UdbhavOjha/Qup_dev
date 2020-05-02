using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Qup
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login_Click(object sender, EventArgs e)
        {
            //var userCredentials = new AuthenticateUserSession
            //{
            //    UserName = Request["username"],
            //    Password = Request["password"],
            //    IpAddress = Request.UserHostAddress
            //};

            //var authentication = new UserAuthentication();
            //var sessionStatus = authentication.AuthenticateUserCredentials(userCredentials);

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