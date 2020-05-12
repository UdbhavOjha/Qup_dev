using System;

namespace Qup.Business.AccountsManagement.Models
{
    public class BusinessDetails
    {
        public int BusinessId { get; set; }
        public string BusinessName { get; set; }

        public string Address { get; set; }

        public int Capacity { get; set; }

        public string Profile { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
