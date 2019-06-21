using System;
using System.Collections.Generic;

namespace MM.DataServices.Models
{
    public partial class TbActivityType
    {
        public TbActivityType()
        {
            TbMembersRecentActivities = new HashSet<TbMembersRecentActivities>();
        }

        public int ActivityTypeId { get; set; }
        public string ActivityTypeDesc { get; set; }
        public string ImageFile { get; set; }

        public ICollection<TbMembersRecentActivities> TbMembersRecentActivities { get; set; }
    }
}
