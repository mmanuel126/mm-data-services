using System;
using System.Collections.Generic;

namespace MM.DataServices.Models
{
    public partial class TbNoteCommentPosts
    {
        public int PostId { get; set; }
        public int? NoteId { get; set; }
        public int? MemberId { get; set; }
        public string CommentDesc { get; set; }
        public DateTime? PostDate { get; set; }
    }
}
