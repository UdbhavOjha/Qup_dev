using System;

namespace Qup.Business.Transactions.Models
{
    public class CustomerInQueue
    {
        public int QueueId { get; set; }
        public string Name { get; set; }

        public DateTime? QueueEntryTime { get; set; }

        public DateTime? QueueExitTime { get; set; }

        public int Capacity { get; set; }
    }
}
