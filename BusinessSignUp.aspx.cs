using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Qup
{
    public partial class BusinessSignUp : System.Web.UI.Page
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
        }

        //private NewAccountSignUpForm GetFormData()
        //{
        //    return new NewAccountSignUpForm()
        //    {
        //        Address = address.Value.Trim(),
        //        EmailAddress = email.Value.Trim(),
        //        FirstName = firstName.Value.Trim(),
        //        MiddleName = middleName.Value.Trim(),
        //        LastName = lastName.Value.Trim(),
        //        MobileNumber = mobileNumber.Value.Trim(),
        //        OrganisationDescription = description.Value.Trim(),
        //        OrganisationName = companyName.Value.Trim(),
        //        PhoneNumber = phoneNumber.Value.Trim()
        //    };
        //}

        //private bool IsRecaptchaValid()
        //{
        //    var result = false;
        //    var captchaResponse = Request.Form["g-recaptcha-response"];
        //    var secretKey = ConfigurationManager.AppSettings["SecretKey"];
        //    var apiUrl = "https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}";
        //    var requestUri = string.Format(apiUrl, secretKey, captchaResponse);
        //    var request = (HttpWebRequest)WebRequest.Create(requestUri);

        //    using (WebResponse response = request.GetResponse())
        //    {
        //        using (StreamReader stream = new StreamReader(response.GetResponseStream()))
        //        {
        //            JObject jResponse = JObject.Parse(stream.ReadToEnd());
        //            var isSuccess = jResponse.Value<bool>("success");
        //            result = (isSuccess) ? true : false;
        //        }
        //    }
        //    return result;
        //}
    }
}