using System;
using System.Collections.Generic;

namespace MM.DataServices.Models
{
    public partial class TbEventPosts
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? PostDate { get; set; }
        public string AttachFile { get; set; }
        public int? MemberId { get; set; }
        public int? EventId { get; set; }
        public int? FileType { get; set; }

        public TbEvents Event { get; set; }
    }
}
