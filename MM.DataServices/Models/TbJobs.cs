using System;
using System.Collections.Generic;

namespace MM.DataServices.Models
{
    public partial class TbJobs
    {
        public int PostId { get; set; }
        public string JobTitle { get; set; }
        public string Sector { get; set; }
        public string Industry { get; set; }
        public string Company { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string JobType { get; set; }
        public string ExperienceType { get; set; }
        public string JobFunction { get; set; }
        public string Compensation { get; set; }
        public string ReferralBonus { get; set; }
        public string JobDescription { get; set; }
        public string SkillsExperience { get; set; }
        public string CompanyDescription { get; set; }
        public int? PostMemberId { get; set; }
        public bool? ShowPosterProfile { get; set; }
        public int? ApplicantRouting { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }
        public int? Status { get; set; }
        public DateTime? DatePosted { get; set; }
    }
}
