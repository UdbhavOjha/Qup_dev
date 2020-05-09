using System;
using Qup.Business.AccountsManagement.Models;
using Qup.Database;
using Qup.Business.Utilities;

namespace Qup.Business.AccountsManagement
{
    public class AccountManagementService
    {
        public bool CreateNewBusinessAccount(BusinessAccountInformation command)
        {
            var context = new QupEntities();

            try
            {
                // Add transactions

                // 1. Save Business
                var businessAccount = new Qup.Database.Business()
                {
                    Name = command.BusinessName,
                    Address = command.BusinessAddress,
                    Capacity = command.Capacity,
                    IsActive = true,
                    DateCreated = DateTime.Now
                };
                context.Businesses.Add(businessAccount);

                // 2. Save Business Admin
                // 2.1 generate password Hash
                var encryptedCredentials = GenericUtilityService.EncryptPassword(command.AdminPassword); // Next item

                var businessAdmin = new Qup.Database.User()
                {
                    FirstName = command.AdminFirstName,
                    LastName = command.AdminLastName,
                    Email = command.AdminEmail,
                    PhoneNumber = command.AdminPhone,
                    DateCreated = DateTime.Now,
                    Salt = encryptedCredentials.Salt,
                    UserPassword = encryptedCredentials.EncryptedPassword
                };
                context.Users.Add(businessAdmin);
                context.SaveChanges();

                // Link User To UserGroup 
                var mapUserToGroup = new UsersToUserGroup()
                {
                    UserId = businessAdmin.Id,
                    UserGroupId = 2 // Bar Admin user group
                };
                context.UsersToUserGroups.Add(mapUserToGroup);
                context.SaveChanges();

                // 4. Generate Business QR code
                return true;
            }
            catch (Exception e)
            {
                // log exception in errorhandler
                return false;
            }            
        }
    }
}
