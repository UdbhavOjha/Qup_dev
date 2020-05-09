using System.Collections.Generic;
using System.Linq;
using Qup.Business.AccountsManagement.Models;
using Qup.Database;

namespace Qup.Business.AccountsManagement
{
    public class SearchHandler
    {
        private readonly QupEntities dbContext = new QupEntities(); 
        public IEnumerable<UserDetails> GetUsersByUserGroupsAndName(string userGroup, string name)
        {
            var users = new List<UserDetails>();

            var queryResults = dbContext.spUsersByUserGroup(userGroup);
            var filteredResults = queryResults.Where( r => r.FullName.Contains(name));

            foreach (var item in filteredResults)
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
    }
}
