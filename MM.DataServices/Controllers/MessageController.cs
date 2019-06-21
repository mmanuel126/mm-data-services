using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MM.DataServices.Models;
using MM.DataServices.Messaging;

namespace MM.DataServices.Controllers
{
    [Route("services/[controller]/[action]")]
    public class MessageController : Controller
    {
        MessageDataManager msgMgr;

        public MessageController()
        {
            msgMgr = new MessageDataManager();
        }

        /// <summary>
        /// Gets the member notifications.
        /// </summary>
        /// <returns>The member notifications.</returns>
        /// <param name="memberID">Member identifier.</param>
        /// <param name="showType">Show type.</param>
        [HttpGet]
        public List<TbNotifications> GetMemberNotifications([FromQuery] int memberID, [FromQuery] string showType)
        {
            List<TbNotifications> lst = msgMgr.GetMemberNotifications(memberID, showType);
            return lst;
        }

        /// <summary>
        /// Gets the member messages.
        /// </summary>
        /// <returns>The member messages.</returns>
        /// <param name="memberID">Member identifier.</param>
        /// <param name="type">Type.</param>
        /// <param name="showType">Show type.</param>
        [HttpGet]
        public List<SearchMessagesModel> GetMemberMessages([FromQuery] int memberID, [FromQuery] string type, [FromQuery]  string showType)
        {
            var mlist = msgMgr.GetMemberMessages(memberID, type, showType);
            return mlist;
        }

        /// <summary>
        /// Gets the total unread messages.
        /// </summary>
        /// <returns>The total unread messages.</returns>
        /// <param name="memberID">Member identifier.</param>
        [HttpGet]
        public int GetTotalUnreadMessages([FromQuery] int memberID)
        {
            int res = msgMgr.GetTotalUnreadMessages(memberID);
            return (res);
        }

        /// <summary>
        /// Creates a message.
        /// </summary>
        /// <param name="to">To.</param>
        /// <param name="from">From.</param>
        /// <param name="subject">Subject.</param>
        /// <param name="body">Body.</param>
        /// <param name="attachment">Attachment.</param>
        /// <param name="original">Original.</param>
        [HttpPost]
        public void CreateMessage([FromQuery]  int to, [FromQuery]  int from, [FromQuery] string subject, [FromQuery] string body, [FromQuery] string attachment, [FromQuery]  string original)
        {
            msgMgr.CreateMessage(to, from, subject, body, attachment, original);
        }

        /// <summary>
        /// Creates the message by source.
        /// </summary>
        /// <param name="to">To.</param>
        /// <param name="from">From.</param>
        /// <param name="subject">Subject.</param>
        /// <param name="body">Body.</param>
        /// <param name="attachment">Attachment.</param>
        /// <param name="source">Source.</param>
        /// <param name="original">Original.</param>
        [HttpPost]
        public void CreateMessageBySource([FromQuery] string to, [FromQuery] string from, [FromQuery] string subject, [FromQuery] string body, [FromQuery] string attachment, [FromQuery] string source, [FromQuery]  string original)
        {
            msgMgr.CreateMessage(to, from, subject, body, attachment, source, original);
        }

        /// <summary>
        /// Toggles the state of the notification.
        /// </summary>
        /// <param name="status">If set to <c>true</c> status.</param>
        /// <param name="notificationID">Notification identifier.</param>
        [HttpPut]
        public void ToggleNotificationState([FromQuery] bool status, [FromQuery] int notificationID)
        {
            msgMgr.ToggleNotificationState(status, notificationID);
        }

        /// <summary>
        /// Deletes the notification.
        /// </summary>
        /// <param name="notificationID">Notification identifier.</param>
        /// <param name="memberID">Member identifier.</param>
        [HttpDelete]
        public void DeleteNotification([FromQuery] int notificationID, [FromQuery] int memberID)
        {
            msgMgr.DeleteNotification(notificationID, memberID);
        }

        /// <summary>
        /// Toggles the state of the message.
        /// </summary>
        /// <param name="status">Status.</param>
        /// <param name="msgID">Message identifier.</param>
        /// <param name="folder">Folder.</param>
        [HttpPut]
        public void ToggleMessageState([FromQuery] MessageDataManager.MessageStatus status, [FromQuery]  int msgID, [FromQuery]  string folder)
        {
            msgMgr.ToggleMessageState(status, msgID, folder);
        } 

        /// <summary>
        /// Gets list of notifications by identifier.
        /// </summary>
        /// <returns>The notification by identifier.</returns>
        /// <param name="nid">Nid.</param>
        [HttpGet]
        public IQueryable<TbNotifications> GetNotificationByID([FromQuery] int nid)
        {
            IQueryable<TbNotifications> lst = msgMgr.GetNotificationByID(nid);
            return lst;
        }

        /// <summary>
        /// Gets the message info by identifier.
        /// </summary>
        /// <returns>The message info by identifier.</returns>
        /// <param name="msgID">Message identifier.</param>
        /// <param name="folder">Folder.</param>
        [HttpGet]
        public List<MessageInfoModel> GetMessageInfoByID([FromQuery] int msgID, [FromQuery] string folder)
        {
            List<MessageInfoModel> lst = msgMgr.GetMessageInfoByID(msgID, folder);
            return lst;
        }

        /// <summary>
        /// Deletes the move message.
        /// </summary>
        /// <param name="msgID">Message identifier.</param>
        /// <param name="mt">Mt.</param>
        /// <param name="folder">Folder.</param>
        [HttpDelete]
        public void DeleteMoveMessage([FromQuery] int msgID, [FromQuery]  MessageDataManager.MessageMoveType mt, [FromQuery] string folder)
        {
            msgMgr.DeleteMoveMessage(msgID, mt, folder);
        }

        /// <summary>
        /// Deletes the message.
        /// </summary>
        /// <param name="msgID">Message identifier.</param>
        [HttpDelete]
        public void DeleteMessage([FromQuery] int msgID)
        {
           msgMgr.DeleteMessage(msgID);
        }

        /// <summary>
        /// Searchs messages given search key for member id.
        /// </summary>
        /// <returns>The messages.</returns>
        /// <param name="memberID">Member identifier.</param>
        /// <param name="searchKey">Search key.</param>
        /// <param name="type">Type.</param>
        [HttpGet]
        public List<SearchMessagesModel> SearchMessages([FromQuery]  int memberID, [FromQuery]  string searchKey, [FromQuery]  string type)
        {
            List<SearchMessagesModel> msgList = msgMgr.SearchMessages(memberID, searchKey, type);
            return msgList;
        }

        /// <summary>
        /// Empties the message folder (inbox, archive, etc).
        /// </summary>
        /// <param name="mID">M identifier.</param>
        /// <param name="folder">Folder.</param>
        [HttpDelete]
        public void EmptyMessageFolders([FromQuery] int mID, [FromQuery]  string folder)
        {
            msgMgr.EmptyMessageFolders(mID, folder);
        }

    }
}
