using System;
using System.Web;
using Qup.Business.AccountsManagement;
using Qup.Business.AccountsManagement.Models;
using Qup.Security;

namespace Qup.Admins
{
    public partial class ViewProfile : WebPage
    {
        protected BusinessDetails BusinessDetails = new BusinessDetails();
        protected void Page_Load(object sender, EventArgs e)
        {
            AuthenticateUser();
            var businessId = Request.QueryString["businessId"];

            if (businessId != null)
            {
                var searchQueryHandler = new SearchHandler();
                BusinessDetails = searchQueryHandler.GetBusinessDetailsByBusinessId(Convert.ToInt32(businessId));

                if (BusinessDetails.BusinessName != null )
                {
                    businessProfileQuickResponseCodeImage.Src = "data:image/jpg;base64," + BusinessDetails.Profile;
                }

                else 
                {
                    throw new HttpException(404, "File Not Found"); 
                }
            }
        }
    }
}