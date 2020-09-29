using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserAddressDTO
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public int Country { get; set; }
        public int City { get; set; }
        public long PostalCode { get; set; }
    }
}
