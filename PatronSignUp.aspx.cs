using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Qup
{
    public partial class PatronSignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void signUpSubmit_Click(object sender, EventArgs e)
        {
            //var formData = GetFormData();
            //var validator = new NewAccountSignUpFormValidator();
            //var results = validator.Validate(formData);
            //bool validationSuccess = results.IsValid;
            //Failures = results.Errors;

            //if (!validationSuccess)
            //{
            //    return;
            //}

            //// Recaptcha check
            //if (!IsRecaptchaValid())
            //{
            //    RecaptchaError = "Please tick the recaptcha checkbox.";
            //    return;
            //}

            Response.Redirect("/Clients/PatronDashboard.aspx");
        }
    }
}