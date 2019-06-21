using System;
using System.Collections.Generic;

namespace MM.DataServices.Models
{
    public partial class TbMemberProfileEducation
    {
        public int MemberId { get; set; }
        public string HighSchool { get; set; }
        public string HighSchoolClassYear { get; set; }
        public string College1 { get; set; }
        public string College1ClassYear { get; set; }
        public string College1Major { get; set; }
        public int? College1DegreeType { get; set; }
        public string College1Societies { get; set; }
        public string College2 { get; set; }
        public string College2ClassYear { get; set; }
        public string College2Major { get; set; }
        public int? College2DegreeType { get; set; }
        public string College2Societies { get; set; }

        public TbMembers Member { get; set; }
    }
}
