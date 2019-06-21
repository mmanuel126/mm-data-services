using System;
using System.Collections.Generic;

namespace MM.DataServices.Models
{
    public partial class TbMembersRecentActivities
    {
        public int ActivityId { get; set; }
        public string Description { get; set; }
        public DateTime? ActivityDate { get; set; }
        public int? MemberId { get; set; }
        public int? ActivityTypeId { get; set; }

        public TbActivityType ActivityType { get; set; }
        public TbMembers Member { get; set; }
    }
}
