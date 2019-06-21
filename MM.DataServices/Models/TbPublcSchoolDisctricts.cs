using System;
using System.Collections.Generic;

namespace MM.DataServices.Models
{
    public partial class TbPublcSchoolDisctricts
    {
        public string NcesdistrictId { get; set; }
        public string StateDistrictId { get; set; }
        public string SchoolName { get; set; }
        public string CountyName { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Zip4 { get; set; }
        public string Phone { get; set; }
        public string Students { get; set; }
        public string Teachers { get; set; }
        public string Schools { get; set; }
        public string LocaleCode { get; set; }
        public string Locale { get; set; }
        public string StudentTeacherRatio { get; set; }
        public string Type { get; set; }
        public int Lgid { get; set; }
        public string ImageFile { get; set; }
    }
}
