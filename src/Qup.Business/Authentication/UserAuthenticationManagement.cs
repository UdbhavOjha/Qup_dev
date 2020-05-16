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

                var pbkdf2 = new Rfc2898DeriveBytes(userCredentials.Password, saltBytes);
                byte[] hash = pbkdf2.GetBytes(20);

                if (String.Equals(Convert.ToBase64String(hash), passwordHash))
                {
                    // If success - log the session 

                    // Create New Session Token
                    // 1. Get a random number between 1 and 100000, hash it to get the sessionId, save string to DB and in cookie, return   
                    var randomSessionId = new Random().Next(1, 100000).ToString();
                    var sessionHash = new Rfc2898DeriveBytes(randomSessionId, 10).GetBytes(7);

                    userCredentials.UserId = foundMatch.Id;
                    _dbContext.SessionLogs.Add(new SessionLog
                    {
                        UserId = userCredentials.UserId,
                        Browser = userCredentials.Browser,
                        IpAddress = userCredentials.IpAddress,
                        XForwardedFor = userCredentials.XForwardedFor,
                        ServerName = userCredentials.ServerName,
                        SessionKey = Convert.ToBase64String(sessionHash),
                        DateCreated = userCredentials.DateCreated
                    });
                    _dbContext.SaveChanges();

                    //Save the String of Session Hash in DB for the authenticated user
                    var userResult = _dbContext.Users.Find(foundMatch.Id);
                    userResult.SessionKey = Convert.ToBase64String(sessionHash);
                    _dbContext.SaveChanges();

                    userCredentials.SessionValidated = true;
                    userCredentials.SessionKey = userResult.SessionKey;

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

        public UserSession AuthenticateUserByCookie(UserSession userCredentials)
        {
            // Get user from DB if webname matches 
            var query =
                from c in _dbContext.Users
                where c.UserKey.Equals(userCredentials.UserKey)
                select c;

            // Match password
            if (query.Count() == 1)
            {
                var foundMatch = query.ToList().First();

                // Create New Session Token
                // 1. Get a random number between 1 and 100000, hash it to get the sessionId, save string to DB and in cookie, return   
                var randomSessionId = new Random().Next(1, 100000).ToString();
                var sessionHash = new Rfc2898DeriveBytes(randomSessionId, 10).GetBytes(7);

                userCredentials.UserId = foundMatch.Id;
                _dbContext.SessionLogs.Add(new SessionLog
                {
                    UserId = userCredentials.UserId,
                    Browser = userCredentials.Browser,
                    IpAddress = userCredentials.IpAddress,
                    XForwardedFor = userCredentials.XForwardedFor,
                    ServerName = userCredentials.ServerName,
                    SessionKey = Convert.ToBase64String(sessionHash),
                    DateCreated = userCredentials.DateCreated
                });
                _dbContext.SaveChanges();

                //Save the String of Session Hash in DB for the authenticated user
                var userResult = _dbContext.Users.Find(foundMatch.Id);
                userResult.SessionKey = Convert.ToBase64String(sessionHash);
                _dbContext.SaveChanges();

                userCredentials.SessionValidated = true;
                userCredentials.SessionKey = userResult.SessionKey;

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
            else
            {
                userCredentials.SessionValidated = false;
            }

            return userCredentials;
        }

        public UserSession LogSessionForNewUserAfterSignUp(UserSession sessionDetails)
        {
            var query =
               from c in _dbContext.Users
               where c.Email.Equals(sessionDetails.UserName)
               select c;

            if (query.Count() == 1)
            {
                var foundMatch = query.ToList().First();

                var randomSessionId = new Random().Next(1, 100000).ToString();
                var sessionHash = new Rfc2898DeriveBytes(randomSessionId, 10).GetBytes(7);

                _dbContext.SessionLogs.Add(new SessionLog
                {
                    UserId = foundMatch.Id,
                    Browser = sessionDetails.Browser,
                    IpAddress = sessionDetails.IpAddress,
                    XForwardedFor = sessionDetails.XForwardedFor,
                    ServerName = sessionDetails.ServerName,
                    SessionKey = Convert.ToBase64String(sessionHash),
                    DateCreated = sessionDetails.DateCreated
                });

                _dbContext.SaveChanges();

                //Save the String of Session Hash in DB for the authenticated user
                var userResult = _dbContext.Users.Find(foundMatch.Id);
                userResult.SessionKey = Convert.ToBase64String(sessionHash);
                _dbContext.SaveChanges();

                sessionDetails.SessionValidated = true;
                sessionDetails.SessionKey = userResult.SessionKey;
                sessionDetails.UserKey = userResult.UserKey;

                // Get User Group
                int userId = foundMatch.Id;

                var userGroupQuery =
                    (from c in _dbContext.UsersToUserGroups
                     where c.UserId == userId
                     select c.UserGroupId).Single();

                if (userGroupQuery != null)
                {
                    sessionDetails.UserGroup = Convert.ToInt16(userGroupQuery);
                }
            }

            return sessionDetails;
        }

        public string GenerateNewCookie()
        {
            var randomSessionId = new Random().Next(1, 100000).ToString();
            var sessionHash = new Rfc2898DeriveBytes(randomSessionId, 10).GetBytes(7);
            return Convert.ToBase64String(sessionHash);
        }
    }
}
