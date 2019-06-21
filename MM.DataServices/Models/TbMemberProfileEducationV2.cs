using System;
using System.Collections.Generic;

namespace MM.DataServices.Models
{
    public partial class TbMemberProfileEducationV2
    {
        public int MemberId { get; set; }
        public int SchoolId { get; set; }
        public int SchoolType { get; set; }
        public string SchoolName { get; set; }
        public string ClassYear { get; set; }
        public string Major { get; set; }
        public int? DegreeType { get; set; }
        public string Societies { get; set; }
        public string Description { get; set; }
    }
}
