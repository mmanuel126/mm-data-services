using System;
using System.Collections.Generic;

namespace MM.DataServices.Models
{
    public partial class TbNotes
    {
        public int NoteId { get; set; }
        public int MemberId { get; set; }
        public string Title { get; set; }
        public string NoteText { get; set; }
        public int? PrivacyType { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
