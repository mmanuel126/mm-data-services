using System;
using System.Collections.Generic;

namespace MM.DataServices.Models
{
    public partial class TbNetworkPhotos
    {
        public int PhotoId { get; set; }
        public int? NetworkId { get; set; }
        public int? MemberId { get; set; }
        public string PhotoName { get; set; }
        public string PhotoDesc { get; set; }
        public string FileName { get; set; }
        public bool? Removed { get; set; }
        public DateTime CreatedDate { get; set; }

        public TbMembers Member { get; set; }
        public TbNetworks Network { get; set; }
    }
}
