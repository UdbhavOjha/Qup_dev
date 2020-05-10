using System;
using Qup.Database;
using Qup.Business.Transactions.Models;

namespace Qup.Business.Transactions
{
    public class UserLedger
    {
        private readonly QupEntities dbContext = new QupEntities();

        public void RegisterCustomerInQueue(UserRegistration userInstruction) 
        {
            var user = new Qup.Database.UserLedger() 
            {
                Name = userInstruction.Name,
                Email = userInstruction.Email,
                PhoneNumber = userInstruction.Phone,
                DateCreated = DateTime.Now,
                BusinessId = 1 // Change this later
            };

            dbContext.UserLedgers.Add(user);
            dbContext.SaveChanges();

            // Save Queue Ledger
            var queueHandler = new QueueLedger();
            queueHandler.AddCustomerToQueue(new QueueInstruction 
            {
                BusinessId = 1, 
                QueueJoinTime = DateTime.Now,
                ExpectedEntryTime = DateTime.Now,
                ActualEntryTime = DateTime.Now,
                UserLedgerId = user.Id
            });
        }
    }
}
