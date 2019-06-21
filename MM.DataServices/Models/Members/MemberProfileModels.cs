using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MM.DataServices.Models
{
    public class MemberProfileBasicInfoModel
    {
        public string memProfileImage { get; set; }
        public string memProfileName { get; set; }
        public string memberProfileTitle { get; set; }
        public string memProfileBusinessSector { get; set; }
        public string memProfileIndustry { get; set; }
        public string memProfileStatus { get; set; }
        public string memProfileGender { get; set; }
        public string memProfileDOB { get; set; }
        public string memProfileInterestedInc { get; set; }
        public string memProfileLookingFor { get; set; }       
        public string CurrentCity { get; set; }
        public string CurrentStatus { get; set; }
        public string DOBDay { get; set; }
        public string DOBMonth { get; set; }
        public string DOBYear { get; set; }
        public string FirstName { get; set; }
        public string HomeNeighborhood { get; set; }
        public string Hometown { get; set; }      
        public string InterestedInType { get; set; }
        public string JoinedDate { get; set; }
        public string LastName { get; set; }
        public string LookingForEmployment { get; set; }
        public string LookingForNetworking { get; set; }
        public string LookingForPartnership { get; set; }
        public string LookingForRecruitment { get; set; }
        public string MemberID { get; set; }
        public string MiddleName { get; set; }
        public string PoliticalView { get; set; }
        public string ReligiousView { get; set; }        
        public string Sex { get; set; }
        public string ShowDOBType { get; set; }
        public string ShowSexInProfile { get; set; }    
        
        public string GetLGEntitiesCount { get; set; }
    }
}
