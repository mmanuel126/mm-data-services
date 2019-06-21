using System;
using System.Collections.Generic;

namespace MM.DataServices.Models
{
    public partial class TbNetworkCategory
    {
        public TbNetworkCategory()
        {
            TbNetworks = new HashSet<TbNetworks>();
        }

        public int CategoryId { get; set; }
        public string Description { get; set; }

        public ICollection<TbNetworks> TbNetworks { get; set; }
    }
}
