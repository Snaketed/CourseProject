using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserCardInfoDTO
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string CardNumber { get; set; }
        public string ValidMonth { get; set; }
        public string ValidYear { get; set; }
        public string CVC { get; set; }
    }
}
