using System;
using Qup.Business.AccountsManagement;
using Qup.Business.AccountsManagement.Models;
using Qup.Security;

namespace Qup.Admins
{
    public partial class CreateNewUser : WebPage
    {
        protected string UserMessage = String.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            AuthenticateUser();
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
            password.Value = string.Empty;
        }

        protected void signUpSubmit_Click(object sender, EventArgs e)
        {
            var businessAdminFirstName = firstName.Value.Trim();
            var businessAdminLastName = lastName.Value.Trim();
            var businessAdminPhoneNumber = mobileNumber.Value.Trim();
            var businessAdminEmail = email.Value.Trim();
            var businessAdminPassword = password.Value.Trim();
            var userGroupType = userType.Value;

            // 1. Server Side Validation 
            bool formValuesValidationResult = ValidateRequest();

            // 2. Save
            if (formValuesValidationResult)
            {
                var userInformation = new UserSetUp()
                {
                    FirstName = businessAdminFirstName,
                    LastName = businessAdminLastName,
                    PhoneNumber = businessAdminPhoneNumber,
                    Email = businessAdminEmail,
                    Password = businessAdminPassword,
                    UserType = Convert.ToInt16(userGroupType)
                };

                var accountSetService = new AccountManagementService();
                var result = accountSetService.CreateNewUser(userInformation);
                if (result)
                {
                    UserMessage = "New User Account created successfully.";
                    ResetFieldValues();
                }
                else
                {
                    UserMessage = "New User failed to be created.";
                }
            }
            else
            {
                // return error message
            }
        }
    }
}