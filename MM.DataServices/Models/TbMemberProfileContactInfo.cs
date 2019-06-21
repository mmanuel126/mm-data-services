using System;
using System.Collections.Generic;

namespace MM.DataServices.Models
{
    public partial class TbMemberProfileContactInfo
    {
        public int MemberId { get; set; }
        public string Email { get; set; }
        public bool? ShowEmailToMembers { get; set; }
        public string OtherEmail { get; set; }
        public string ImdisplayName { get; set; }
        public int? ImserviceType { get; set; }
        public string CellPhone { get; set; }
        public bool? ShowCellPhone { get; set; }
        public string HomePhone { get; set; }
        public bool? ShowHomePhone { get; set; }
        public string OtherPhone { get; set; }
        public string Address { get; set; }
        public bool? ShowAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string WebSiteLinks { get; set; }
        public bool? ShowLinks { get; set; }
        public string Neighborhood { get; set; }

        public TbMembers Member { get; set; }
    }
}
