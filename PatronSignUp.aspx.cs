using System;
using System.Web;
using Qup.Business.AccountsManagement;
using Qup.Business.AccountsManagement.Models;
using Qup.Business.Authentication;
using Qup.Business.Authentication.Models;

namespace Qup
{
    public partial class PatronSignUp : System.Web.UI.Page
    {
        private const int PatronUserGroup = 1;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void signUpSubmit_Click(object sender, EventArgs e)
        {
            var patronFirstName = firstName.Value;
            var patronLastName = lastName.Value;
            var patronEmail = email.Value;
            var patronPhoneNumber = mobileNumber.Value;
            var patronPassword = password.Value;

            // Validate form

            // create account if validation successful
            var accountHandler = new AccountManagementService();
            accountHandler.CreateNewUser( new UserSetUp 
            {
                FirstName = patronFirstName,
                LastName = patronLastName,
                Email = patronEmail,
                PhoneNumber = patronPhoneNumber,
                Password = patronPassword,
                UserType = PatronUserGroup
            });
            // user key has been created


            var userCredentials = new UserSession
            {
                UserName = patronEmail,
                Password = patronPassword,
                IpAddress = Request.UserHostAddress,
                XForwardedFor = Request.Headers["X-Forwarded-For"],
                Browser = HttpContext.Current.Request.Browser.Browser,
                ServerName = Request.ServerVariables["SERVER_NAME"],
                DateCreated = DateTime.Now,
                UserKey = String.Empty
            };

            var authenticationHandler = new UserAuthenticationManagement();
            UserSession userValidationResults = new UserSession();
            
            userValidationResults = authenticationHandler.LogSessionForNewUserAfterSignUp(userCredentials);
            
            if (userValidationResults.SessionValidated)
            {
                Response.Cookies["SessionInfo"].Value = userValidationResults.SessionKey;
                Response.Cookies["SessionInfo"].Expires = DateTime.Now.AddHours(3);
                Response.Cookies["User"].Value = userValidationResults.UserKey;

                if (userValidationResults.UserGroup == PatronUserGroup)
                {
                    Response.Redirect("/Clients/JoinQueue.aspx?profile=1");
                }
            }
        }
    }
}