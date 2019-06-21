using System;
using System.Collections.Generic;

namespace MM.DataServices.Models
{
    public partial class TbColleges
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public string Type { get; set; }
        public string AwardsOffered { get; set; }
        public string CampusSetting { get; set; }
        public string CampusHousing { get; set; }
        public int? StudentPopulation { get; set; }
        public int? UnderGradStudents { get; set; }
        public string StudentToFacultyRatio { get; set; }
        public string Ipedsid { get; set; }
        public string Opeid { get; set; }
        public string State { get; set; }
        public int SchoolId { get; set; }
        public string ImageFile { get; set; }
    }
}
