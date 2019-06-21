using System;
using System.Collections.Generic;

namespace MM.DataServices.Models
{
    public partial class TbDiscussionTopicPosts
    {
        public int PostId { get; set; }
        public int? TopicId { get; set; }
        public int? MemberId { get; set; }
        public string PostDesc { get; set; }
        public DateTime? PostDate { get; set; }

        public TbMembers Member { get; set; }
    }
}
