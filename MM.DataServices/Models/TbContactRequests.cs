using System;
using System.Collections.Generic;

namespace MM.DataServices.Models
{
    public partial class TbContactRequests
    {
        public int RequestId { get; set; }
        public int? FromMemberId { get; set; }
        public int? ToMemberId { get; set; }
        public DateTime? RequestDate { get; set; }
        public int? Status { get; set; }

        public TbMembers FromMember { get; set; }
        public TbMembers ToMember { get; set; }
    }
}
