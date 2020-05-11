using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qup.Business.AccountsManagement.Models
{
    public class BusinessAccountInformation
    {
        public string BusinessName { get; set; }

        public string BusinessAddress { get; set; }

        public int Capacity { get; set; }

        public string AdminFirstName { get; set; }

        public string AdminLastName { get; set; }

        public string AdminPhone { get; set; }

        public string AdminEmail { get; set; }

        public string AdminPassword { get; set; }

        public bool BusinessAccountCreated { get; set; }

        public int BusinessId { get; set; }

    }
}
