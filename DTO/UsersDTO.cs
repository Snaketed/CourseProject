using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UsersDTO
    {
       
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] Password { get; set; }
        public System.Guid Salt{ get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string Keyword { get; set; }
        public DateTime RowInsertTime { get; set; }

    }
}
