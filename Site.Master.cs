using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Qup
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubscribeButton_Click(object sender, EventArgs e)
        {
            //string userEmail = String.Format("{0}", Request.Form["SubscriberEmail"]);
            //string userEmailCheck = String.Format("{0}", Request.Form["SubscriberEmailCheck"]);
            //string userMessage = "Piccly Main Website Subscription Email:" + userEmail;
            //string subject = "Main Website Newsletter subscription";
            //if (string.IsNullOrEmpty(userEmailCheck) && !(string.IsNullOrEmpty(userEmail)))
            //{
            //    SendEmail(subject, userMessage);
            //    //userMessage = "Thank you for subscribing to our newsletter.";
            //    Session["userMessage"] = "Thank you for subscribing to our newsletter.";
            //}
        }

        //private void SendEmail(string subject, string userMessage)
        //{
        //    var client = new SmtpClient
        //    {
        //        Host = "smtp.gmail.com",
        //        Port = 587,
        //        Credentials = new NetworkCredential("picclydesigns@gmail.com", "Thiswillwork100%"),
        //        EnableSsl = true,
        //        DeliveryMethod = SmtpDeliveryMethod.Network
        //    };

        //    client.Send("picclydesigns@gmail.com", "picclydesigns@gmail.com", subject, userMessage);
        //}
    }
}