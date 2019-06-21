using System;
using System.Collections.Generic;

namespace MM.DataServices.Models
{
    public partial class TbPublicSchools
    {
        public string SchoolId { get; set; }
        public string StateSchoolId { get; set; }
        public string DistrictId { get; set; }
        public string StateDistrict { get; set; }
        public string LowGrade { get; set; }
        public string HighGrade { get; set; }
        public string SchoolName { get; set; }
        public string District { get; set; }
        public string CountryName { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Zip4Digit { get; set; }
        public string Phone { get; set; }
        public string LocalCode { get; set; }
        public string Locale { get; set; }
        public string Charter { get; set; }
        public string Magnet { get; set; }
        public string Titlle1School { get; set; }
        public string Title1SchoolWide { get; set; }
        public int? Students { get; set; }
        public int? Teachers { get; set; }
        public float? StudeintTeacherRatio { get; set; }
        public int? FreeLunch { get; set; }
        public int? ReducedLunch { get; set; }
        public string ImageFile { get; set; }
        public int Lgid { get; set; }
    }
}
