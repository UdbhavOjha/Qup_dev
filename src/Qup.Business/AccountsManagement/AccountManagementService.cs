using System;
using Qup.Business.AccountsManagement.Models;
using Qup.Database;
using Qup.Business.Utilities;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

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
            var payload = "https://qup.azurewebsites.net?profile=" + id.ToString();
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
