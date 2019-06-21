using System;
using System.Collections.Generic;

namespace MM.DataServices.Models
{
    public partial class TbMemberProfileEmploymentInfoV2
    {
        public int EmpInfoId { get; set; }
        public int MemberId { get; set; }
        public int? CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Position { get; set; }
        public string JobDesc { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string StartMonth { get; set; }
        public string StartYear { get; set; }
        public string EndMonth { get; set; }
        public string EndYear { get; set; }
        public bool? CurrentlyWorkedHere { get; set; }
    }
}
