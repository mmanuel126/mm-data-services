using System;
using System.Collections.Generic;

namespace MM.DataServices.Models
{
    public partial class TbNetworkRecentActivities
    {
        public int ActivityId { get; set; }
        public string Description { get; set; }
        public DateTime? ActivityDate { get; set; }
        public int? MemberId { get; set; }
        public int? NetworkId { get; set; }
        public int? ActivityTypeId { get; set; }

        public TbMembers Member { get; set; }
        public TbNetworks Network { get; set; }
    }
}
