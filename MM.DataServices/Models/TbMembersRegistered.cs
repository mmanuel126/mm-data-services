using System;
using System.Collections.Generic;

namespace MM.DataServices.Models
{
    public partial class TbMembersRegistered
    {
        public int MemberCodeId { get; set; }
        public int MemberId { get; set; }
        public DateTime? RegisteredDate { get; set; }

        public TbMembers Member { get; set; }
    }
}
