using System;
using System.Collections.Generic;

namespace MM.DataServices.Models
{
    public partial class TbMemberPostResponses
    {
        public int PostResponseId { get; set; }
        public int? PostId { get; set; }
        public string Description { get; set; }
        public DateTime? ResponseDate { get; set; }
        public int? MemberId { get; set; }

        public TbMembers Member { get; set; }
        public TbMemberPosts Post { get; set; }
    }
}
