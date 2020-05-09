using System;
using System.Linq;
using System.Text;
using Qup.Database;
using Qup.Business.Authentication.Models;
using System.Security.Cryptography;

namespace Qup.Business.Authentication
{
    public class UserAuthenticationManagement
    {
        //public int? UserId { get; set; }
        private readonly QupEntities _dbContext = new QupEntities();

        public UserSession AuthenticUserCredentials(UserSession userCredentials)
        {
            // Get user from DB if webname matches 
            var query =
                from c in _dbContext.Users
                where c.Email.Equals(userCredentials.UserName)
                select c;

            // Match password
            if (query.Count() == 1)
            {
                var foundMatch = query.ToList().First();

                var passwordHash = foundMatch.UserPassword;
                byte[] hashBytes = Convert.FromBase64String(passwordHash);

                var salt = foundMatch.Salt;
                var saltBytes = Guid.Parse(salt).ToByteArray();
                //byte[] saltBytes = Convert.FromBase64String(salt);
                //byte[] saltBytes = Encoding.ASCII.GetBytes(salt);

                var pbkdf2 = new Rfc2898DeriveBytes(userCredentials.Password, saltBytes);
                byte[] hash = pbkdf2.GetBytes(20);

                if (String.Equals(Convert.ToBase64String(hash), passwordHash))
                {
                    // If success - log the session 
                    //var sessionInfo = new SessionLog
                    //{
                    //    UserId = foundMatch.UserId,
                    //    Ipaddress = userCredentials.IpAddress,
                    //    LoginDate = DateTime.Now
                    //};

                    //UserId = foundMatch.UserId;


                    //using (var context = new ZeroDbContext())
                    //{
                    //    context.Entry(sessionInfo).State = EntityState.Added;
                    //    context.SaveChanges();
                    //}

                    // Create New Session
                    // 1. Get a random number between 1 and 100000, hash it to get the sessionId, save string to DB and in cookie, return   
                    //var randomSessionId = new Random().Next(1, 100000).ToString();
                    //var sessionHash = new Rfc2898DeriveBytes(randomSessionId, 10).GetBytes(7);

                    // Save the String of Session Hash in DB for the authenticated user
                    //using (var context = new ZeroDbContext())
                    //{
                    //    var userResult = context.UserCredentials.Single(u => u.UserId == foundMatch.UserId);
                    //    if (userResult != null)
                    //    {
                    //        userResult.DateLastLogged = DateTime.Now;
                    //        userResult.SessionKey = Convert.ToBase64String(sessionHash);
                    //        context.SaveChanges();
                    //    }
                    //}
                    //return Convert.ToBase64String(sessionHash);

                    userCredentials.SessionValidated = true;
                    // Get User Group
                    int userId = foundMatch.Id;

                    var userGroupQuery =
                        (from c in _dbContext.UsersToUserGroups
                        where c.UserId == userId 
                        select c.UserGroupId).Single();

                    if (userGroupQuery != null)
                    {
                        userCredentials.UserGroup = Convert.ToInt16(userGroupQuery);
                    }
                }
            }
            else
            {
                userCredentials.SessionValidated = false;
            }
            
            return userCredentials;
        }
    }
}
