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
                    BusinessName = item.Name, 
                    Address = item.Address,
                    Capacity = item.Capacity
                });
            }
            
            return businessList;
        }
    }
}
