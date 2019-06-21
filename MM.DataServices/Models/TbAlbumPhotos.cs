using System;
using System.Collections.Generic;

namespace MM.DataServices.Models
{
    public partial class TbAlbumPhotos
    {
        public int PhotoId { get; set; }
        public int? AlbumId { get; set; }
        public string PhotoName { get; set; }
        public string PhotoDesc { get; set; }
        public string FileName { get; set; }
        public bool? Removed { get; set; }

        public TbAlbums Album { get; set; }
    }
}
