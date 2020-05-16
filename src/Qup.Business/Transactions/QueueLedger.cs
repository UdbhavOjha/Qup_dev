using Qup.Business.Transactions.Models;
using Qup.Database;
using System;
using System.Collections.Generic;
using Qup.Business.Authentication;
using Qup.Business.AccountsManagement;
using System.Linq;

namespace Qup.Business.Transactions
{
    public class QueueLedger
    {
        private readonly QupEntities dbContext = new QupEntities();
        public void AddCustomerToQueue(QueueInstruction instruction)
        {
            var queueInstruction = new Database.QueueTransaction()
            {
                BusinessId = 1,
                QueueJoinDateTime = instruction.QueueJoinTime,
                ExpectedEntryDateTime = instruction.ExpectedEntryTime,
                ActualEntryDateTime = instruction.ActualEntryTime,
                ExitTime = instruction.ExitTime,
                PatronId = instruction.PatronId,
                UserLedgerId = instruction.UserLedgerId
            };

            dbContext.QueueTransactions.Add(queueInstruction);
            dbContext.SaveChanges();        
        }

        public IEnumerable<CustomerInQueue> GetCustomersInQueue(int businessId, DateTime fromDate, DateTime toDate)
        {
            var customersInQueue = new List<CustomerInQueue>();
            var queryResults = dbContext.spGetCustomersInQueueByDate(fromDate, toDate, businessId);

            var results = queryResults.ToList();

            if (results.Count > 0 )
            {
                foreach (var item in results)
                {
                    customersInQueue.Add(new CustomerInQueue
                    {
                        Name = item.Name,
                        QueueEntryTime = item.EntryTime,
                        QueueExitTime = item.ExitTime,
                        Capacity = item.Capacity,
                        QueueId = item.QueueId
                    });
                }
            }                      

            return customersInQueue;
        }

        public void SaveCustomerQueueExit(int queueId)
        {
            var result = dbContext.QueueTransactions.Find(queueId);
                         
            if (result != null)
            {
                result.ExitTime = DateTime.Now;
                dbContext.SaveChanges();
            }
        }

        public bool LeaveQueue(QueueInstruction leaveInstruction)
        {
            if (leaveInstruction.SessionId != null)
            {
                // Get Customer Queue
                var userQueue = dbContext.spGetUserQueue(leaveInstruction.SessionId, leaveInstruction.BusinessId);
                int queueId = 0;

                foreach (var item in userQueue)
                {
                    queueId = item.Id;
                }

                if (queueId != 0)
                {
                    SaveCustomerQueueExit(queueId);
                }                

                return true;
            }

            return false;
        }

    }
}
