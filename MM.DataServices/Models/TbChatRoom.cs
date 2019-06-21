using System;
using System.Collections.Generic;

namespace MM.DataServices.Models
{
    public partial class TbChatRoom
    {
        public TbChatRoom()
        {
            TbChatMessages = new HashSet<TbChatMessages>();
            TbLoggedInUser = new HashSet<TbLoggedInUser>();
        }

        public int RoomId { get; set; }
        public string Name { get; set; }
        public bool? Responded { get; set; }

        public ICollection<TbChatMessages> TbChatMessages { get; set; }
        public ICollection<TbLoggedInUser> TbLoggedInUser { get; set; }
    }
}
