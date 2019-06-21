using System;
using System.Collections.Generic;

namespace MM.DataServices.Models
{
    public partial class TbNetworkMemberInvites
    {
        public int InviteId { get; set; }
        public int? NetworkId { get; set; }
        public int? MemberId { get; set; }
        public string Email { get; set; }
        public int? Status { get; set; }

        public TbMembers Member { get; set; }
        public TbNetworks Network { get; set; }
    }
}
