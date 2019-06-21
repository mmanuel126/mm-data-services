using System;
using System.Collections.Generic;

namespace MM.DataServices.Models
{
    public partial class TbNetworkSettings
    {
        public int NetworkId { get; set; }
        public bool? NonAdminCanWrite { get; set; }
        public bool? ShowGroupEvents { get; set; }
        public bool? ShowProfileBox { get; set; }
        public bool? ShowProfileTab { get; set; }
        public bool? EnableDiscussionBoard { get; set; }
        public bool? EnablePhotos { get; set; }
        public bool? OnlyAllowAdminsToUploadPhotos { get; set; }
        public bool? ShowEnablePhotoProfileBox { get; set; }
        public bool? ShowEnableProfileTab { get; set; }
        public bool? EnableVideos { get; set; }
        public bool? OnlyAllowAdminsToUploadVideos { get; set; }
        public bool? ShowVideoProfileBox { get; set; }
        public bool? ShowVideoProfileTab { get; set; }
        public bool? EnableLinks { get; set; }
        public bool? OnlyAllowAdminsToPostLinks { get; set; }
        public int? Access { get; set; }

        public TbNetworks Network { get; set; }
    }
}
