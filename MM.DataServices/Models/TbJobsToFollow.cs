using System;
using System.Collections.Generic;

namespace MM.DataServices.Models
{
    public partial class TbJobsToFollow
    {
        public int JobFollowId { get; set; }
        public int PostId { get; set; }
        public int MemberId { get; set; }
    }
}
