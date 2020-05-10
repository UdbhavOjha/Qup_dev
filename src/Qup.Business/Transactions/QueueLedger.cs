using Qup.Business.Transactions.Models;
using Qup.Database;
using System;
using System.Collections.Generic;

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

            foreach (var item in queryResults)
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
            customersInQueue.Reverse();

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

    }
}
