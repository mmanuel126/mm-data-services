using System;
using System.Collections.Generic;

namespace MM.DataServices.Models
{
    public partial class TbContacts
    {
        public int MemberId { get; set; }
        public int ContactId { get; set; }
        public int Status { get; set; }
        public DateTime? DateStamp { get; set; }

        public TbMembers Contact { get; set; }
        public TbMembers Member { get; set; }
    }
}
