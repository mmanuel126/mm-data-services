using System;
using System.Collections.Generic;

namespace MM.DataServices.Models
{
    public partial class TbNetworkDiscussionTopics
    {
        public int TopicId { get; set; }
        public int? NetworkId { get; set; }
        public int? MemberId { get; set; }
        public string TopicDesc { get; set; }
        public DateTime? CreatedDate { get; set; }

        public TbMembers Member { get; set; }
        public TbNetworks Network { get; set; }
    }
}
