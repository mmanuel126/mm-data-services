using System;
using System.Collections.Generic;

namespace MM.DataServices.Models
{
    public partial class TbPollAnswers
    {
        public int PollAnswerId { get; set; }
        public int PollId { get; set; }
        public string DisplayText { get; set; }
        public int SortOrder { get; set; }
    }
}
