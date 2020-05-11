using System;
using Qup.Business.AccountsManagement;
using Qup.Business.AccountsManagement.Models;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;

namespace Qup.Admins
{
    public partial class NewBusinessOnboard : System.Web.UI.Page
    {
        protected string UserMessage = String.Empty;

        protected string businessProfileUrl = String.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void signUpSubmit_Click(object sender, EventArgs e)
        {
            // Get values 
            var businessName = companyName.Value.Trim();
            var businessAddress = address.Value.Trim();
            var businessSeatingCapacity = seatingCapacity.Value.Trim();

            var businessAdminFirstName = firstName.Value.Trim();
            var businessAdminLastName = lastName.Value.Trim();
            var businessAdminPhoneNumber = mobileNumber.Value.Trim();
            var businessAdminEmail = email.Value.Trim();
            var businessAdminPassword = password.Value.Trim();



            // 1. Server Side Validation 
            bool formValuesValidationResult = ValidateRequest();

            // 2. Save
            if (formValuesValidationResult)
            {
                var businessAccountInformation = new BusinessAccountInformation()
                {
                    BusinessName = businessName,
                    BusinessAddress = businessAddress,
                    Capacity = Convert.ToInt32(businessSeatingCapacity),
                    AdminFirstName = businessAdminFirstName,
                    AdminLastName = businessAdminLastName,
                    AdminPhone = businessAdminPhoneNumber,
                    AdminEmail = businessAdminEmail,
                    AdminPassword = businessAdminPassword
                };

                var accountSetService = new AccountManagementService();
                var result = accountSetService.CreateNewBusinessAccount(businessAccountInformation);
                if (result.BusinessAccountCreated)
                {
                    UserMessage = "New Business Account created successfully.";
                    businessProfileUrl = "/Admins/ViewProfile?businessId=" + result.BusinessId.ToString();
                    ResetFieldValues();                    
                }
                else
                {
                    UserMessage = "New Business Account failed to be created.";
                }
            }
            else
            {
                // return error message
            }
            
        }

        private bool ValidateRequest() 
        {
            return true;
        }

        private void ResetFieldValues()
        {
            firstName.Value = string.Empty;
            lastName.Value = string.Empty;
            mobileNumber.Value = string.Empty;
            email.Value = string.Empty;
            address.Value = string.Empty;
            companyName.Value = string.Empty;
            password.Value = string.Empty;
            seatingCapacity.Value = string.Empty;
        }
    }
}