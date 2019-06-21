using System;

namespace MM.DataServices.Models
{
    public class MemberProfileContactInfoModel
    {
        public string Email { get; set; }
        public string OtherEmail { get; set; }
        public string IMDisplayName { get; set; }        
        public string IMServiceType { get; set; }
        public string WebsiteLink { get; set; }
        public string HomePhone { get; set; }
        public string CellPhone { get; set; }
        public string OtherPhone { get; set; }
        public string Address { get; set; }
        public string CityTown { get; set; }
        public string Neighborhood { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public bool ShowAddress { get; set; }
        public bool ShowEmailToMembers { get; set; }
        public bool ShowCellPhone { get; set; }
        public bool ShowHomePhone { get; set; }
        public bool ShowLinks { get; set; }
                     
    }
}