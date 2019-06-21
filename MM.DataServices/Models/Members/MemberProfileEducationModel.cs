using System;

namespace MM.DataServices.Models
{
    public class MemberProfileEducationModel
    {

        public String schoolID { get; set; }
        public String schoolName { get; set; }
        public String schoolImage { get; set; }
        public String schoolAddress { get; set; }
        public String major { get; set; }
        public String degree { get; set; }
        public String degreeTypeID { get; set; }
        public String yearClass { get; set; }
        public String schoolType { get; set; }
        public String Societies { get; set; }
       
       // public InstitutionModel SchoolInfo { get; set; }
    }
}