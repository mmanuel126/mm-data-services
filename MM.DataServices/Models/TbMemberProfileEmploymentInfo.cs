using System;
using System.Collections.Generic;

namespace MM.DataServices.Models
{
    public partial class TbMemberProfileEmploymentInfo
    {
        public int MemberId { get; set; }
        public string Employer1 { get; set; }
        public string Emp1Position { get; set; }
        public string Emp1JobDesc { get; set; }
        public string Emp1City { get; set; }
        public string Emp1State { get; set; }
        public string Emp1StartMonth { get; set; }
        public string Emp1StartYear { get; set; }
        public string Emp1EndMonth { get; set; }
        public string Emp1EndYear { get; set; }
        public bool? CurrentlyWorkHere { get; set; }
        public string Employer2 { get; set; }
        public string Emp2Position { get; set; }
        public string Emp2JobDesc { get; set; }
        public string Emp2City { get; set; }
        public string Emp2State { get; set; }
        public string Emp2StartMonth { get; set; }
        public string Emp2StartYear { get; set; }
        public string Emp2EndMonth { get; set; }
        public string Emp2EndYear { get; set; }
        public string Employer3 { get; set; }
        public string Emp3Position { get; set; }
        public string Emp3JobDesc { get; set; }
        public string Emp3City { get; set; }
        public string Emp3State { get; set; }
        public string Emp3StartMonth { get; set; }
        public string Emp3StartYear { get; set; }
        public string Emp3EndMonth { get; set; }
        public string Emp3EndYear { get; set; }

        public TbMembers Member { get; set; }
    }
}
