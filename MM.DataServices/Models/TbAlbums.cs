using System;
using System.Collections.Generic;

namespace MM.DataServices.Models
{
    public partial class TbAlbums
    {
        public TbAlbums()
        {
            TbAlbumPhotos = new HashSet<TbAlbumPhotos>();
        }

        public int AlbumId { get; set; }
        public int? MemberId { get; set; }
        public string AlbumName { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int? PrivacySetting { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? Removed { get; set; }

        public TbMembers Member { get; set; }
        public ICollection<TbAlbumPhotos> TbAlbumPhotos { get; set; }
    }
}
