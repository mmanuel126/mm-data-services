using System;
using System.Collections.Generic;

namespace MM.DataServices.Models
{
    public partial class TbVideoCategory
    {
        public TbVideoCategory()
        {
            TbVideos = new HashSet<TbVideos>();
        }

        public int CategoryId { get; set; }
        public string Description { get; set; }

        public ICollection<TbVideos> TbVideos { get; set; }
    }
}
