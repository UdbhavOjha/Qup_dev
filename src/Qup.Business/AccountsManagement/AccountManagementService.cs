using System;
using System.Linq;
using Qup.Business.AccountsManagement.Models;
using Qup.Database;
using Qup.Business.Utilities;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Security.Cryptography;

namespace Qup.Business.AccountsManagement
{
    public class AccountManagementService
    {
        private QupEntities _context;
        public AccountManagementService()
        {
            _context = new QupEntities();
        }
        public BusinessAccountInformation CreateNewBusinessAccount(BusinessAccountInformation command)
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

                command.BusinessId = businessAccount.Id;

                // Link User To UserGroup 
                var mapUserToGroup = new UsersToUserGroup()
                {
                    UserId = businessAdmin.Id,
                    UserGroupId = 2 // Bar Admin user group
                };
                _context.UsersToUserGroups.Add(mapUserToGroup);
                _context.SaveChanges();

                // Generate QR code - just for now - move this to Business Logic
                GenerateQuickResponseCodeForNewBusiness(businessAccount.Id);
                
                command.BusinessAccountCreated = true;                
            }
            catch (Exception e)
            {
                command.BusinessAccountCreated = false;
            }

            return command;
        }

        private void GenerateQuickResponseCodeForNewBusiness(int id)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            var payload = "https://qup.azurewebsites.net/Login.aspx?profile=" + id.ToString();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);

            _context.BusinessProfiles.Add(new BusinessProfile
            {
                BusinessId = id,
                ProfileImage = ConvertImageToByte(qrCodeImage)
            });

            _context.SaveChanges();
        }

        private byte[] ConvertImageToByte(Image img)
        {
            using (var stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                return stream.ToArray();
            }
        }

        public bool CreateNewUser(UserSetUp command) 
        {
            try
            {
                // Add transactions
                // 2.1 generate password Hash
                var encryptedCredentials = GenericUtilityService.EncryptPassword(command.Password); // Next item

                // Create New User Token
                // Get a random number between 1 and 100000, hash it to get the sessionId, save string to DB and in cookie, return   
                var randomSessionId = new Random().Next(1, 100000).ToString();
                var sessionHash = new Rfc2898DeriveBytes(randomSessionId, 10).GetBytes(10);

                var newUser = new Qup.Database.User()
                {
                    FirstName = command.FirstName,
                    LastName = command.LastName,
                    Email = command.Email,
                    PhoneNumber = command.PhoneNumber,
                    DateCreated = DateTime.Now,
                    Salt = encryptedCredentials.Salt,
                    UserPassword = encryptedCredentials.EncryptedPassword,
                    UserKey = Convert.ToBase64String(sessionHash)
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

                // 4. Generate User QR code
                return true;
            }
            catch (Exception e)
            {
                throw e;
                // log exception in errorhandler
                //return false;
            }
        }

        public UserDetails GetUserBySessionId(string sessionId)
        {
            var user = new UserDetails();

            var userQuery = from c in _context.Users
                            where c.SessionKey == sessionId
                            select c;

            return user;
        }
    }
}
