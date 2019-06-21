using System;
using System.Collections.Generic;

namespace MM.DataServices.Models
{
    public partial class TbLoggedInUser
    {
        public int LoggedInUserId { get; set; }
        public int? UserId { get; set; }
        public int? RoomId { get; set; }

        public TbChatRoom Room { get; set; }
        public TbMembers User { get; set; }
    }
}
