using System;
using System.Collections.Generic;
using System.Linq;
using Qup.Business.AccountsManagement.Models;
using Qup.Database;

namespace Qup.Business.AccountsManagement
{
    public class SearchHandler
    {
        private readonly QupEntities dbContext = new QupEntities(); 
        public IEnumerable<UserDetails> GetUsersByUserGroups(string userGroup)
        {
            var users = new List<UserDetails>();

            var queryResults = dbContext.spUsersByUserGroup(userGroup);

            foreach (var item in queryResults)
            {
                users.Add(new UserDetails
                {
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    FullName = item.FullName,
                    Email = item.Email, 
                    PhoneNumber = item.PhoneNumber
                });
            }

            return users;
        }

        public IEnumerable<BusinessDetails> GetBusinesses()
        {
            var businessList = new List<BusinessDetails>();
            var queryResults = from c in dbContext.Businesses
                        where c.IsActive == true
                        select c;
            foreach (var item in queryResults)
            {
                businessList.Add(new BusinessDetails { 
                    BusinessId = item.Id,
                    BusinessName = item.Name, 
                    Address = item.Address,
                    Capacity = item.Capacity
                });
            }
            
            return businessList;
        }

        public int GetBusinessesOnPlatformCount()
        {
            var queryResults = from c in dbContext.Businesses
                               where c.IsActive == true
                               select c;
            return queryResults.Count();
        }

        public int GetRegisteredPatronsOnPlatformCount()
        {
            var queryResults = dbContext.spUsersByUserGroup("Patron");
            return queryResults.Count();
        }

        public BusinessDetails GetBusinessDetailsByBusinessId(int businessId)
        {
            
            var queryResults = from c in dbContext.vwGetBusinessDetails
                               where c.Id == businessId
                               select c;

            if (queryResults.Any() && queryResults.Count() == 1)
            {
                var result = queryResults.FirstOrDefault();
                var businessDetails = new BusinessDetails() 
                {
                    BusinessId = result.Id,
                    DateCreated = result.DateCreated,
                    BusinessName = result.Name,
                    Address = result.Address,
                    Capacity = result.Capacity,
                    Profile = Convert.ToBase64String(result.ProfileImage)
                };
                return businessDetails;
            }

            return new BusinessDetails();
        }

        public int GetPatronIdBySessionId(string sessionId)
        {
            var queryResult = from c in dbContext.Users
                              where c.SessionKey == sessionId
                              select c;

            if (queryResult.Any())
            {
                return queryResult.FirstOrDefault().Id;
            }

            return 0;

        }
    }
}
