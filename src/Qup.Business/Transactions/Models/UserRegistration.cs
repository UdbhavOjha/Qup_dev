using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qup.Business.Transactions.Models
{
    public class UserRegistration
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public int BusinessId { get; set; }
    }
}
