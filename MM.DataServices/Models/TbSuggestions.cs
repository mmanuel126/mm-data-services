using System;
using System.Collections.Generic;

namespace MM.DataServices.Models
{
    public partial class TbSuggestions
    {
        public int MemberId { get; set; }
        public string ContactEmail { get; set; }

        public TbMembers Member { get; set; }
    }
}
