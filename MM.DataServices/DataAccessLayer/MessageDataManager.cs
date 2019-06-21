using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MM.DataServices.Models;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;


namespace MM.DataServices.Messaging
{
    /// <summary>
    /// Describes the functionalities for member and network messages
    /// </summary>
    public class MessageDataManager
    {

        #region methods...

        public MessageDataManager()
        {
            //
            // TODO: Add constructor logic here if any
            //
        }

        public enum MessageStatus { UnRead, Read, Forwarded, RepliedTo };
        public enum MessageMoveType { Deleted, Junk, Sent, Message };
        public enum MessageFolder { Inbox, Junk, Sent, Deleted };

        /// <summary>
        /// get a listo of member notifications
        /// </summary>
        /// <param name="memberID"></param>
        /// <param name="showType"></param>
        /// <returns></returns>
        public List<TbNotifications> GetMemberNotifications(int memberID, string showType)
        {
			using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
			{
                List<TbNotifications> nlist = null;
                if (showType == "All")
                    nlist = (from n in context.TbNotifications
                             join m in context.TbMemberNotifications
                             on n.NotificationId equals m.NotificationId
                             where(m.MemberId== memberID)
                             orderby n.SentDate descending
                             select n).ToList();
                else
                    nlist = (from n in context.TbNotifications
                             join m in context.TbMemberNotifications
                             on n.NotificationId equals m.NotificationId
                             where (m.MemberId == memberID) && (n.Status == false) orderby n.SentDate descending select n).ToList();

                return nlist;
            }
        }

        /// <summary>
        /// Get member messages for member id
        /// </summary>
        /// <param name="memberID"></param>
        /// <param name="type"></param>
        /// <param name="showType"></param>
        /// <returns></returns>
        public List<SearchMessagesModel> GetMemberMessages(int memberID, string type, string showType)
        {
			//type is Inbox, Junk, Sent, or Deleted
			using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
			{

				var lP = (from p in context.TbMemberProfile where p.MemberId == memberID select p.MemberId).ToList()[0].ToString();

                List<SearchMessagesModel> msgList = null;
                if (type == "Inbox")
                {

                    if (showType != "All" && showType != "UnRead")
                    {
                        msgList = (from msg in context.TbMessages
                                                              join mpf in context.TbMemberProfile on msg.SenderId equals mpf.MemberId
                                                              into t from nt in t.DefaultIfEmpty()
                                                              where
                                                                   msg.ContactId == memberID &&

                                                                    (nt.FirstName.Contains(showType) || nt.LastName.Contains(showType)
                                                                     || msg.Body.Contains(showType))

                                                              orderby msg.MsgDate descending
                                                              select new SearchMessagesModel()
                                                              {
                                                                  Attachement = msg.Attachment.ToString(),
                                                                  body = (msg.Body.Length > 35) ? msg.Body.Substring(0, Math.Min(msg.Body.Length, 33)) + "..." : msg.Body,
                                                                  contactName = nt.FirstName + " " + nt.LastName,
                                                                  contactImage = string.IsNullOrEmpty((from p in context.TbMemberProfile where p.MemberId == msg.ContactId select p.MemberId).ToList()[0].ToString()) ? "default.png" : (from p in context.TbMemberProfile where p.MemberId == msg.ContactId select p.MemberId).ToList()[0].ToString(),
                                                                  senderImage = string.IsNullOrEmpty(nt.PicturePath) ? "default.png" : nt.PicturePath,// mpf.PicturePath,
                                                                  contactID = memberID.ToString(),
                                                                  flagLevel = msg.FlagLevel.ToString(),
                                                                  importanceLevel = msg.ImportanceLevel.ToString(),
                                                                  messageID = msg.MessageId.ToString(),
                                                                  messageState = msg.MessageState.ToString(),
                                                                  senderID = nt.FirstName + " " + nt.LastName,
                                                                  subject = msg.Subject,
                                                                  msgDate = msg.MsgDate.ToString(),
                                                                  fromID = msg.SenderId.ToString(),
                                                                  firstName = nt.FirstName,
                                                                  fullBody = msg.Body 
                                                              }).ToList();
                    }

                    if (showType == "All") {
						msgList = (from msg in context.TbMessages
								   join mpf in context.TbMemberProfile on msg.SenderId equals mpf.MemberId
                                   into t
                                   from nt in t.DefaultIfEmpty()
                                   where 
										msg.ContactId == memberID 

								   orderby msg.MsgDate descending
								   select new SearchMessagesModel()
								   {
									   Attachement = msg.Attachment.ToString(),
									   body = (msg.Body.Length > 35) ? msg.Body.Substring(0, Math.Min(msg.Body.Length, 33)) + "..." : msg.Body,
									   contactName = nt.FirstName + " " + nt.LastName,
									   contactImage = string.IsNullOrEmpty((from p in context.TbMemberProfile where p.MemberId == msg.ContactId select p.MemberId).ToList()[0].ToString()) ? "default.png" : (from p in context.TbMemberProfile where p.MemberId == msg.ContactId select p.MemberId).ToList()[0].ToString(),
									   senderImage = string.IsNullOrEmpty(nt.PicturePath) ? "default.png" : nt.PicturePath,// mpf.PicturePath,
									   contactID = memberID.ToString(),
									   flagLevel = msg.FlagLevel.ToString(),
									   importanceLevel = msg.ImportanceLevel.ToString(),
									   messageID = msg.MessageId.ToString(),
									   messageState = msg.MessageState.ToString(),
									   senderID = nt.FirstName + " " + nt.LastName,
                                       subject = msg.Subject,
									   msgDate = msg.MsgDate.ToString(),
									   fromID = msg.SenderId.ToString(),
									   firstName = nt.FirstName,
                                       fullBody = msg.Body
                                   }).ToList();
                    }
                    else 
                    {
						msgList = (from msg in context.TbMessages
								   join mpf in context.TbMemberProfile on msg.SenderId equals mpf.MemberId
                                   into t
                                   from nt in t.DefaultIfEmpty()
                                   where
										msg.ContactId == memberID && msg.MessageState == 0 

								   orderby msg.MsgDate descending
								   select new SearchMessagesModel()
								   {
									   Attachement = msg.Attachment.ToString(),
									   body = (msg.Body.Length > 35) ? msg.Body.Substring(0, Math.Min(msg.Body.Length, 33)) + "..." : msg.Body,
									   contactName = nt.FirstName + " " + nt.LastName,
									   contactImage = string.IsNullOrEmpty((from p in context.TbMemberProfile where p.MemberId == msg.ContactId select p.MemberId).ToList()[0].ToString()) ? "default.png" : (from p in context.TbMemberProfile where p.MemberId == msg.ContactId select p.MemberId).ToList()[0].ToString(),
									   senderImage = string.IsNullOrEmpty(nt.PicturePath) ? "default.png" : nt.PicturePath,// mpf.PicturePath,
									   contactID = memberID.ToString(),
									   flagLevel = msg.FlagLevel.ToString(),
									   importanceLevel = msg.ImportanceLevel.ToString(),
									   messageID = msg.MessageId.ToString(),
									   messageState = msg.MessageState.ToString(),
									   senderID = nt.FirstName + " " + nt.LastName,
                                       subject = msg.Subject,
									   msgDate = msg.MsgDate.ToString(),
									   fromID = msg.SenderId.ToString(),
									   firstName = nt.FirstName,
                                       fullBody = msg.Body
                                   }).ToList();
                    }

                }
                else if (type == "Junk") 
                {
					msgList = (from msg in context.TbMessagesJunk 
							   join mpf in context.TbMemberProfile on msg.SenderId equals mpf.MemberId
							   where
									msg.ContactId == memberID 

							   orderby msg.MsgDate descending
							   select new SearchMessagesModel()
							   {
								   Attachement = msg.Attachment.ToString(),
								   body = (msg.Body.Length > 35) ? msg.Body.Substring(0, Math.Min(msg.Body.Length, 33)) + "..." : msg.Body,
								   contactName = mpf.FirstName + " " + mpf.LastName,
								   contactImage = string.IsNullOrEmpty((from p in context.TbMemberProfile where p.MemberId == msg.ContactId select p.MemberId).ToList()[0].ToString()) ? "default.png" : (from p in context.TbMemberProfile where p.MemberId == msg.ContactId select p.MemberId).ToList()[0].ToString(),
								   senderImage = string.IsNullOrEmpty(mpf.PicturePath) ? "default.png" : mpf.PicturePath,// mpf.PicturePath,
								   contactID = memberID.ToString(),
								   flagLevel = msg.FlagLevel.ToString(),
								   importanceLevel = msg.ImportanceLevel.ToString(),
								   messageID = msg.MessageId.ToString(),
								   messageState = msg.MessageState.ToString(),
								   senderID = msg.SenderId.ToString(),
								   subject = msg.Subject,
								   msgDate = msg.MsgDate.ToString(),
								   fromID = msg.SenderId.ToString(),
								   firstName = mpf.FirstName
							   }).ToList();
                }
                else if (type == "Sent") 
                {
                    if (showType == "All")
                    {
                        msgList = (from msg in context.TbMessagesSent
                                   join mpf in context.TbMemberProfile on msg.SenderId equals mpf.MemberId
                                   where
                                        msg.ContactId == memberID

                                   orderby msg.MsgDate descending
                                   select new SearchMessagesModel()
                                   {
                                       Attachement = msg.Attachment.ToString(),
                                       body = (msg.Body.Length > 35) ? msg.Body.Substring(0, Math.Min(msg.Body.Length, 33)) + "..." : msg.Body,
                                       contactName = mpf.FirstName + " " + mpf.LastName,
                                       contactImage = string.IsNullOrEmpty((from p in context.TbMemberProfile where p.MemberId == msg.ContactId select p.MemberId).ToList()[0].ToString()) ? "default.png" : (from p in context.TbMemberProfile where p.MemberId == msg.ContactId select p.MemberId).ToList()[0].ToString(),
                                       senderImage = string.IsNullOrEmpty(mpf.PicturePath) ? "default.png" : mpf.PicturePath,// mpf.PicturePath,
                                       contactID = memberID.ToString(),
                                       flagLevel = msg.FlagLevel.ToString(),
                                       importanceLevel = msg.ImportanceLevel.ToString(),
                                       messageID = msg.MessageId.ToString(),
                                       messageState = msg.MessageState.ToString(),
                                       senderID = msg.SenderId.ToString(),
                                       subject = msg.Subject,
                                       msgDate = msg.MsgDate.ToString(),
                                       fromID = msg.SenderId.ToString(),
                                       firstName = mpf.FirstName
                                   }).ToList();
                    }
                    else 
                    {
						msgList = (from msg in context.TbMessagesSent
								   join mpf in context.TbMemberProfile on msg.SenderId equals mpf.MemberId
								   where
										msg.ContactId == memberID && msg.MessageState == 0

								   orderby msg.MsgDate descending
								   select new SearchMessagesModel()
								   {
									   Attachement = msg.Attachment.ToString(),
									   body = (msg.Body.Length > 35) ? msg.Body.Substring(0, Math.Min(msg.Body.Length, 33)) + "..." : msg.Body,
									   contactName = mpf.FirstName + " " + mpf.LastName,
									   contactImage = string.IsNullOrEmpty((from p in context.TbMemberProfile where p.MemberId == msg.ContactId select p.MemberId).ToList()[0].ToString()) ? "default.png" : (from p in context.TbMemberProfile where p.MemberId == msg.ContactId select p.MemberId).ToList()[0].ToString(),
									   senderImage = string.IsNullOrEmpty(mpf.PicturePath) ? "default.png" : mpf.PicturePath,// mpf.PicturePath,
									   contactID = memberID.ToString(),
									   flagLevel = msg.FlagLevel.ToString(),
									   importanceLevel = msg.ImportanceLevel.ToString(),
									   messageID = msg.MessageId.ToString(),
									   messageState = msg.MessageState.ToString(),
									   senderID = msg.SenderId.ToString(),
									   subject = msg.Subject,
									   msgDate = msg.MsgDate.ToString(),
									   fromID = msg.SenderId.ToString(),
									   firstName = mpf.FirstName
								   }).ToList();
                    }
                }
				else if (type == "Sent")
				{
					if (showType == "All")
					{
						msgList = (from msg in context.TbMessagesDeleted 
								   join mpf in context.TbMemberProfile on msg.SenderId equals mpf.MemberId
								   where
										msg.ContactId == memberID

								   orderby msg.MsgDate descending
								   select new SearchMessagesModel()
								   {
									   Attachement = msg.Attachment.ToString(),
									   body = (msg.Body.Length > 35) ? msg.Body.Substring(0, Math.Min(msg.Body.Length, 33)) + "..." : msg.Body,
									   contactName = mpf.FirstName + " " + mpf.LastName,
									   contactImage = string.IsNullOrEmpty((from p in context.TbMemberProfile where p.MemberId == msg.ContactId select p.MemberId).ToList()[0].ToString()) ? "default.png" : (from p in context.TbMemberProfile where p.MemberId == msg.ContactId select p.MemberId).ToList()[0].ToString(),
									   senderImage = string.IsNullOrEmpty(mpf.PicturePath) ? "default.png" : mpf.PicturePath,// mpf.PicturePath,
									   contactID = memberID.ToString(),
									   flagLevel = msg.FlagLevel.ToString(),
									   importanceLevel = msg.ImportanceLevel.ToString(),
									   messageID = msg.MessageId.ToString(),
									   messageState = msg.MessageState.ToString(),
									   senderID = msg.SenderId.ToString(),
									   subject = msg.Subject,
									   msgDate = msg.MsgDate.ToString(),
									   fromID = msg.SenderId.ToString(),
									   firstName = mpf.FirstName
								   }).ToList();
					}
					else
					{
						msgList = (from msg in context.TbMessagesDeleted 
								   join mpf in context.TbMemberProfile on msg.SenderId equals mpf.MemberId
								   where
										msg.ContactId == memberID && msg.MessageState == 0

								   orderby msg.MsgDate descending
								   select new SearchMessagesModel()
								   {
									   Attachement = msg.Attachment.ToString(),
									   body = (msg.Body.Length > 35) ? msg.Body.Substring(0, Math.Min(msg.Body.Length, 33)) + "..." : msg.Body,
									   contactName = mpf.FirstName + " " + mpf.LastName,
									   contactImage = string.IsNullOrEmpty((from p in context.TbMemberProfile where p.MemberId == msg.ContactId select p.MemberId).ToList()[0].ToString()) ? "default.png" : (from p in context.TbMemberProfile where p.MemberId == msg.ContactId select p.MemberId).ToList()[0].ToString(),
									   senderImage = string.IsNullOrEmpty(mpf.PicturePath) ? "default.png" : mpf.PicturePath,// mpf.PicturePath,
									   contactID = memberID.ToString(),
									   flagLevel = msg.FlagLevel.ToString(),
									   importanceLevel = msg.ImportanceLevel.ToString(),
									   messageID = msg.MessageId.ToString(),
									   messageState = msg.MessageState.ToString(),
									   senderID = msg.SenderId.ToString(),
									   subject = msg.Subject,
									   msgDate = msg.MsgDate.ToString(),
									   fromID = msg.SenderId.ToString(),
									   firstName = mpf.FirstName
								   }).ToList();
					}
				}
                return msgList;
            }
        }

        /// <summary>
        /// Get total unread messages  for member id
        /// </summary>
        /// <param name="memberID"></param>
        /// <returns></returns>
        public int GetTotalUnreadMessages(int memberID)
        {
			// type is Inbox, Junk, Sent, or Deleted -- 
			// [spGetTotalUnreadMessages] not used, instead used ling to sql query below
			using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
			{
                var q = (from p in context.TbMessages where p.ContactId == memberID && p.MessageState == 0 select p.MessageId).Count();
                return (q);
            }                      
        }


        /// <summary>
        /// create a message 
        /// </summary>
        /// <param name="to"></param>
        /// <param name="from"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="attachment"></param>
        /// <param name="original"></param>
        public void CreateMessage(int to, int from, string subject, string body, string attachment, string original)
        {
			using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
			{

                //create a new message object
                TbMessages m = new TbMessages();
                TbMessagesSent ms = new TbMessagesSent();

                m.SenderId = from; ms.SenderId = from;
                m.ContactId = to; ms.ContactId = to;
                m.Subject = subject; ms.Subject = subject;
                m.MsgDate = DateTime.Now; ms.MsgDate = DateTime.Now;
                m.Body = body; ms.Body = body;

                if (string.IsNullOrEmpty(attachment))
                {
                    m.Attachment = false; ms.Attachment = false;
                }
                else
                {
                    m.Attachment = true; ms.Attachment = true;
                }

                m.MessageState = 0; ms.MessageState = 0;
                m.AttachmentFile = attachment; ms.AttachmentFile = attachment;
                m.FlagLevel = 0; ms.FlagLevel = 0;
                m.ImportanceLevel = 0; ms.ImportanceLevel = 0;
                m.OriginalMsg = original; ms.OriginalMsg = original;

                // Add the new object to the the table.
                context.TbMessages.Add (m); context.TbMessagesSent.Add(ms);

                // submit and save the new message to both tables
                context.SaveChanges();
            }
        }

        /// <summary>
        /// create a message 
        /// </summary>
        /// <param name="to"></param>
        /// <param name="from"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="attachment"></param>
        /// <param name="source"></param>
        /// <param name="original"></param>
        public void CreateMessage(string to, string from, string subject, string body, string attachment, string source, string original)
        {
			using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
			{

                //create a new message object
                TbMessages m = new TbMessages();
                TbMessagesSent ms = new TbMessagesSent();

                m.SenderId = Convert.ToInt32(from); ms.SenderId = Convert.ToInt32(from);
                m.ContactId = Convert.ToInt32(to); ms.ContactId = Convert.ToInt32(to);
                m.Subject = subject; ms.Subject = subject;
                m.MsgDate = DateTime.Now; ms.MsgDate = DateTime.Now;
                m.Body = body; ms.Body = body;

                if (string.IsNullOrEmpty(attachment))
                {
                    m.Attachment = false; ms.Attachment = false;
                }
                else
                {
                    m.Attachment = true; ms.Attachment = true;
                }

                m.MessageState = 0; ms.MessageState = 0;
                m.AttachmentFile = attachment; ms.AttachmentFile = attachment;
                m.FlagLevel = 0; ms.FlagLevel = 0;
                m.ImportanceLevel = 0; ms.ImportanceLevel = 0;
                m.OriginalMsg = original; ms.OriginalMsg = original;
                m.Source = source; ms.Source = source;

                // Add the new object to the the table.
                context.TbMessages.Add(m); context.TbMessagesSent.Add(ms);

                // submit and save the new message to both tables
                context.SaveChanges();
            }           
        }
              
        /// <summary>
        /// toggle notification state
        /// </summary>
        /// <param name="status"></param>
        /// <param name="notificationID"></param>
        public void ToggleNotificationState(bool status, int notificationID)
        {
			using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
			{
                var getNotification = (from n in context.TbNotifications where (n.NotificationId == notificationID) select n).First();

                getNotification.Status = status;
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Delete notification for member id
        /// </summary>
        /// <param name="notificationID"></param>
        /// <param name="memberID"></param>
        public void DeleteNotification(int notificationID, int memberID)
        {
			using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
			{
                var getNotification = (from n in context.TbMemberNotifications where (n.NotificationId == notificationID && n.MemberId == memberID) select n).First();

                context.Remove(getNotification);
                context.SaveChanges();
            }           
        }

        /// <summary>
        /// Toggle message state 
        /// </summary>
        /// <param name="status"></param>
        /// <param name="msgID"></param>
        /// <param name="folder"></param>
        public void ToggleMessageState(MessageStatus status, int msgID, string folder)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {
                switch (status)
                {
                    case MessageStatus.UnRead:
                        PerformMessageStatus(folder, 0, msgID, context);
                        break;
                    case MessageStatus.Read:
                        PerformMessageStatus(folder, 1, msgID, context);
                        break;
                    case MessageStatus.Forwarded:
                        PerformMessageStatus(folder, 2, msgID, context);
                        break;
                    case MessageStatus.RepliedTo:
                        PerformMessageStatus(folder, 3, msgID, context);
                        break;
                }
            }
        }

        /// <summary>
        /// Perform message status
        /// </summary>
        /// <param name="folder"></param>
        /// <param name="status"></param>
        /// <param name="msgID"></param>
        /// <param name="context"></param>
        private void PerformMessageStatus(string folder, int status, int msgID, DB_9B0E5C_linkedglobeContext context)
        {
            if (folder == "Inbox")
            {
                var msg = (from m in context.TbMessages where (m.MessageId == msgID) select m).First();
                msg.MessageState = status;
            }
            else if (folder == "Junk")
            {
                var msg = (from m in context.TbMessagesJunk where (m.MessageId == msgID) select m).First();
                msg.MessageState = status;
            }
            else if (folder == "Sent")
            {
                var msg = (from m in context.TbMessagesSent where (m.MessageId == msgID) select m).First();
                msg.MessageState = status;

            }
            else if (folder == "Deleted")
            {
                var msg = (from m in context.TbMessagesDeleted where (m.MessageId == msgID) select m).First();
                msg.MessageState = status;
            }
            context.SaveChanges();
        }

        /// <summary>
        /// Get notification by id 
        /// </summary>
        /// <param name="nid"></param>
        /// <returns></returns>
        public IQueryable<TbNotifications> GetNotificationByID(int nid)
        {
			using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
			{
                var getNotification = (from n in context.TbNotifications where (n.NotificationId == nid) select n);
                return getNotification;
            }
        }

        /// <summary>
        /// Get message info by message ID
        /// </summary>
        /// <param name="msgID"></param>
        /// <param name="folder"></param>
        /// <returns></returns>
        public List<MessageInfoModel> GetMessageInfoByID(int msgID, string folder)
        {
			using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
			{
                List<MessageInfoModel> lst = null;
                if (folder == "Inbox")
                {
                    lst = (from msg in context.TbMessages join tmp in context.TbMemberProfile on  msg.SenderId equals tmp.MemberId  where msg.MessageId == msgID select new MessageInfoModel()
                           {
                              MessageID =msg.MessageId.ToString() ,
                              SentDate  = msg.MsgDate.ToString(),
                              From = tmp.FirstName + " " + tmp.LastName,
                              SenderPicture = string.IsNullOrEmpty(tmp.PicturePath) ? "default.png" : tmp.PicturePath, 
                              Body = msg.Body,
                              Subject = msg.Subject,
                              AttachmentFile  = msg.AttachmentFile,
                              OrginalMsg = msg.OriginalMsg 
                            }
                          ).ToList();
                }
                else if (folder == "Junk")
                {
					lst = (from msg in context.TbMessagesJunk
						   join tmp in context.TbMemberProfile on msg.SenderId equals tmp.MemberId
						   where msg.MessageId == msgID
						   select new MessageInfoModel()
						   {
							   MessageID = msg.MessageId.ToString(),
							   SentDate = msg.MsgDate.ToString(),
							   From = tmp.FirstName + " " + tmp.LastName,
							   SenderPicture = string.IsNullOrEmpty(tmp.PicturePath) ? "default.png" : tmp.PicturePath,
							   Body = msg.Body,
							   Subject = msg.Subject,
							   AttachmentFile = msg.AttachmentFile,
							   OrginalMsg = msg.OriginalMsg
						   }
							).ToList();
                }
				else if (folder == "Sent")
				{
					lst = (from msg in context.TbMessagesSent 
						   join tmp in context.TbMemberProfile on msg.SenderId equals tmp.MemberId
						   where msg.MessageId == msgID
						   select new MessageInfoModel()
						   {
							   MessageID = msg.MessageId.ToString(),
							   SentDate = msg.MsgDate.ToString(),
							   From = tmp.FirstName + " " + tmp.LastName,
							   SenderPicture = string.IsNullOrEmpty(tmp.PicturePath) ? "default.png" : tmp.PicturePath,
							   Body = msg.Body,
							   Subject = msg.Subject,
							   AttachmentFile = msg.AttachmentFile,
							   OrginalMsg = msg.OriginalMsg
						   }
							).ToList();
				}
				else if (folder == "Deleted")
				{
					lst = (from msg in context.TbMessagesDeleted
						   join tmp in context.TbMemberProfile on msg.SenderId equals tmp.MemberId
						   where msg.MessageId == msgID
						   select new MessageInfoModel()
						   {
							   MessageID = msg.MessageId.ToString(),
							   SentDate = msg.MsgDate.ToString(),
							   From = tmp.FirstName + " " + tmp.LastName,
							   SenderPicture = string.IsNullOrEmpty(tmp.PicturePath) ? "default.png" : tmp.PicturePath,
							   Body = msg.Body,
							   Subject = msg.Subject,
							   AttachmentFile = msg.AttachmentFile,
							   OrginalMsg = msg.OriginalMsg
						   }
							).ToList();
				}
                return lst;
            }
        }

        /// <summary>
        /// Delete moved message id
        /// </summary>
        /// <param name="msgID"></param>
        /// <param name="mt"></param>
        /// <param name="folder"></param>
        public void DeleteMoveMessage(int msgID, MessageMoveType mt, string folder)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {
                int mtype = (int)mt;
                int fType = 0;

                if (folder.ToLower() == "inbox")
                    fType = (int)MessageFolder.Inbox;
                else if (folder.ToLower() == "junk")
                    fType = (int)MessageFolder.Junk;
                else if (folder.ToLower() == "sent")
                    fType = (int)MessageFolder.Sent;
                else if (folder.ToLower() == "deleted")
                    fType = (int)MessageFolder.Deleted;

                var pId = new SqlParameter ("@MsgID", msgID);
                var pMtype = new SqlParameter("@Movetype", mtype);
                var pFtype = new SqlParameter("@Folder", fType);

                context.Database.ExecuteSqlCommand ("EXEC spDeleteMoveMessage @MsgID, @Movetype, @Folder", pId, pMtype, pFtype);
            }
        }

        /// <summary>
        /// Delete message id
        /// </summary>
        /// <param name="msgID"></param>
        public void DeleteMessage(int msgID)
        {
			using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
			{
                var msg = (from m in context.TbMessages where (m.MessageId == msgID) select m).First();
                //TbMessagesDeleted mdel = new TbMessagesDeleted();

                //insert into tbMessagesDeleteds
                //mdel.SenderId = msg.SenderId;
                //mdel.ContactId = msg.ContactId;
                //mdel.Subject = msg.Subject;
                //mdel.Body = msg.Body;
                //mdel.MsgDate = msg.MsgDate;
                //mdel.Attachment = msg.Attachment;
                //mdel.MessageState = msg.MessageState;
                //mdel.FlagLevel = msg.FlagLevel;
                //mdel.ImportanceLevel = msg.ImportanceLevel;
                //mdel.AttachmentFile = msg.AttachmentFile;
                //mdel.Source = msg.Source;
                //mdel.OriginalMsg = msg.OriginalMsg;
                //context.TbMessagesDeleted.Add(mdel);

                //delete tbmessage
                context.Remove(msg);

                //save changes to context
                context.SaveChanges();
            }           
        }

        /// <summary>
        /// Search for messages
        /// </summary>
        /// <param name="memberID"></param>
        /// <param name="searchKey"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<SearchMessagesModel> SearchMessages(int memberID, string searchKey, string type)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {
                var lP = (from p in context.TbMemberProfile where p.MemberId == memberID select p.MemberId).ToList()[0].ToString();

                List<SearchMessagesModel> msgList = (from msg in context.TbMessages
                                                      join mpf in context.TbMemberProfile on msg.SenderId equals mpf.MemberId
                                                      where (mpf.FirstName.Contains(searchKey) || mpf.LastName.Contains(searchKey)
                                                             || msg.Subject.Contains(searchKey) || msg.Body.Contains(searchKey))
                                                       && msg.ContactId == memberID
                                                      orderby msg.MsgDate descending
                                                      select new SearchMessagesModel()
                                                      {
                                                          Attachement = msg.Attachment.ToString(),
                                                          body = (msg.Body.Length > 35) ? msg.Body.Substring(0, Math.Min(msg.Body.Length, 33)) + "..." : msg.Body,
                                                          contactName = mpf.FirstName + " " + mpf.LastName,
                                                          contactImage = string.IsNullOrEmpty((from p in context.TbMemberProfile where p.MemberId == msg.ContactId  select p.MemberId).ToList()[0].ToString()) ? "default.png": (from p in context.TbMemberProfile where p.MemberId == msg.ContactId select p.MemberId).ToList()[0].ToString(), 
                                                          senderImage = string.IsNullOrEmpty(mpf.PicturePath) ? "default.png" : mpf.PicturePath,// mpf.PicturePath,
                                                          contactID = memberID.ToString(),
                                                          flagLevel = msg.FlagLevel.ToString(),
                                                          importanceLevel = msg.ImportanceLevel.ToString(),
                                                          messageID  = msg.MessageId.ToString(),
                                                          messageState = msg.MessageState.ToString() ,
                                                          senderID = mpf.FirstName + " " + mpf.LastName,
                                                          subject = msg.Subject,
                                                          msgDate = msg.MsgDate.ToString(),
                                                          fromID = msg.SenderId.ToString() ,
                                                          firstName =mpf.FirstName,
                                                          fullBody = msg.Body

                                                      }).ToList();
                return msgList;
            }

        }

        /// <summary>
        /// Empty messages folder
        /// </summary>
        /// <param name="mID"></param>
        /// <param name="folder"></param>
        public void EmptyMessageFolders(int mID, string folder)
        {
			using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
			{
                if (folder == "Inbox")
                {
                    var msg = (from m in context.TbMessages where m.ContactId == mID select m).First();
                    context.Remove(msg);
                }
                else if (folder == "Junk")
                {
                    var msg = (from m in context.TbMessagesJunk where m.ContactId == mID select m).First();
                    context.Remove(msg);
                }
                else if (folder == "Sent")
                {
                    var msg = (from m in context.TbMessagesJunk where m.SenderId == mID select m).First();
                    context.Remove(msg);
                }
                else if (folder == "Deleted")
                {
                    var msg = (from m in context.TbMessagesJunk where m.ContactId == mID select m).First();
                    context.Remove(msg);
                }
                context.SaveChanges();
            }           
        }

        #endregion

    }
}