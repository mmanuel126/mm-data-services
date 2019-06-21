using System;
using System.Collections.Generic;

namespace MM.DataServices.Models
{
    public partial class TbVideos
    {
        public int VideoId { get; set; }
        public int MemberId { get; set; }
        public string VideoName { get; set; }
        public string Description { get; set; }
        public string FileName { get; set; }
        public DateTime? VidDate { get; set; }
        public int? VidCategory { get; set; }
        public int? VidType { get; set; }
        public bool? Removed { get; set; }

        public TbMembers Member { get; set; }
        public TbVideoCategory VidCategoryNavigation { get; set; }
    }
}
