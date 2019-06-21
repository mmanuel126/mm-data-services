using System;
namespace MM.DataServices.Models
{
    public class SearchMessagesModel    {
        public string Attachement { get; set; }
        public string body { get; set; }
        public string contactName { get; set; }
        public string contactImage { get; set; }
        public string senderImage { get; set; }
        public string contactID { get; set; }
        public string flagLevel { get; set; }
        public string importanceLevel { get; set; }
        public string messageID { get; set; }
        public string messageState { get; set; }
        public string senderID { get; set; }
        public string subject { get; set; }
        public string msgDate { get; set; }
        public string fromID { get; set; }
        public string firstName { get; set; }
        public string fullBody { get; set; }
    }

    public class MessageInfoModel {
		public string MessageID { get; set; }
		public string SentDate { get; set; }
		public string From { get; set; }
		public string SenderPicture { get; set; }
		public string Body { get; set; }
		public string Subject { get; set; }
		public string AttachmentFile { get; set; }
        public string OrginalMsg { get; set; }
    }
}
