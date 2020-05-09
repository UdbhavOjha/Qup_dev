using System;
using Qup.Business.AccountsManagement.Models;
using Qup.Database;
using Qup.Business.Utilities;

namespace Qup.Business.AccountsManagement
{
    public class AccountManagementService
    {
        private QupEntities _context;
        public AccountManagementService()
        {
            _context = new QupEntities();
        }
        public bool CreateNewBusinessAccount(BusinessAccountInformation command)
        {           

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
                _context.Businesses.Add(businessAccount);

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
                _context.Users.Add(businessAdmin);
                _context.SaveChanges();

                // Link User To UserGroup 
                var mapUserToGroup = new UsersToUserGroup()
                {
                    UserId = businessAdmin.Id,
                    UserGroupId = 2 // Bar Admin user group
                };
                _context.UsersToUserGroups.Add(mapUserToGroup);
                _context.SaveChanges();

                // 4. Generate Business QR code
                return true;
            }
            catch (Exception e)
            {
                throw e;
                // log exception in errorhandler
                //return false;
            }            
        }

        public bool CreateNewUser(UserSetUp command) 
        {
            try
            {
                // Add transactions
                // 2.1 generate password Hash
                var encryptedCredentials = GenericUtilityService.EncryptPassword(command.Password); // Next item

                var newUser = new Qup.Database.User()
                {
                    FirstName = command.FirstName,
                    LastName = command.LastName,
                    Email = command.Email,
                    PhoneNumber = command.PhoneNumber,
                    DateCreated = DateTime.Now,
                    Salt = encryptedCredentials.Salt,
                    UserPassword = encryptedCredentials.EncryptedPassword
                };
                _context.Users.Add(newUser);
                _context.SaveChanges();

                // Link User To UserGroup 
                var mapUserToGroup = new UsersToUserGroup()
                {
                    UserId = newUser.Id,
                    UserGroupId = command.UserType 
                };

                _context.UsersToUserGroups.Add(mapUserToGroup);
                _context.SaveChanges();

                // 4. Generate Business QR code
                return true;
            }
            catch (Exception e)
            {
                throw e;
                // log exception in errorhandler
                //return false;
            }
        }
    }
}
