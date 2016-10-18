using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZUS.Zeus.Models
{
    public class User : Base
    {
        public int UserId { get; set; }

        public string NickName { get; set; }

        public string CreditCard { get; set; }

        public string PhoneNumber { get; set; }

        public decimal Balance { get; set; }
    }
}
