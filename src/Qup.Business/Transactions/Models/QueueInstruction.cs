using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qup.Business.Transactions.Models
{
    public class QueueInstruction
    {
        public int BusinessId { get; set; }

        public DateTime QueueJoinTime { get; set; }

        public DateTime ExpectedEntryTime { get; set; }

        public DateTime ActualEntryTime { get; set; }

        public DateTime? ExitTime { get; set; }

        public int? PatronId { get; set; }

        public int? UserLedgerId { get; set; }

        public string SessionId { get; set; }
    }
}
