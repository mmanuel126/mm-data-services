using System;
using System.Collections.Generic;

namespace MM.DataServices.Models
{
    public partial class TbEvents
    {
        public TbEvents()
        {
            TbEventInvites = new HashSet<TbEventInvites>();
            TbEventPosts = new HashSet<TbEventPosts>();
        }

        public int EventId { get; set; }
        public int? NetworkId { get; set; }
        public int? MemberId { get; set; }
        public DateTime? StartDate { get; set; }
        public string StartTime { get; set; }
        public string StartEndTime { get; set; }
        public DateTime? EndDate { get; set; }
        public string EndTime { get; set; }
        public string EndEndTime { get; set; }
        public string PlanningWhat { get; set; }
        public string Location { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string MoreInfo { get; set; }
        public bool? InviteAllGroupMembers { get; set; }
        public bool? AnyoneCanViewRsvp { get; set; }
        public bool? ShowGuestList { get; set; }
        public string EventImg { get; set; }
        public DateTime? CreatedDate { get; set; }

        public TbMembers Member { get; set; }
        public TbNetworks Network { get; set; }
        public ICollection<TbEventInvites> TbEventInvites { get; set; }
        public ICollection<TbEventPosts> TbEventPosts { get; set; }
    }
}
