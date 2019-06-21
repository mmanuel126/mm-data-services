using System;
using System.Collections.Generic;

namespace MM.DataServices.Models
{
    public partial class TbEventInvites
    {
        public int InviteId { get; set; }
        public int? EventId { get; set; }
        public int? MemberId { get; set; }
        public string Email { get; set; }
        public string Rsvpstatus { get; set; }

        public TbEvents Event { get; set; }
        public TbMembers Member { get; set; }
    }
}
