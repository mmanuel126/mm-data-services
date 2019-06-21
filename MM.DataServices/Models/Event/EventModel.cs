using System;
namespace MM.DataServices.Models
{
    public class EventPostModel
    {
        public string postID { get; set; }
		public string title { get; set; }
        public string description { get; set; }
        public string postDate { get; set; }
        public string attachFile { get; set; }
        public string memberID { get; set; }
        public string picturePath { get; set; }
        public string memberName { get; set; }
        public string firstName { get; set; }
    }

    public class EventInfoModel
	{
		public string inviteID { get; set; }
		public string email { get; set; }
		public string RSVPStatus { get; set; }
		public string eventID { get; set; }
		public string eventID1 { get; set; }
		public string networkID { get; set; }
		public string memberID { get; set; }
		public string startDate { get; set; }
		public string startTime { get; set; }

		public string startEndTime { get; set; }
		public string endDate { get; set; }
		public string endTime { get; set; }
		public string endEndTime { get; set; }
		public string planningWhat { get; set; }
		public string location { get; set; }
		public string street { get; set; }
		public string city { get; set; }
		public string state { get; set; }

		public string zip { get; set; }
        public string moreInfo { get; set; }
		public string inviteAllGroupMembers { get; set; }
		public string anyoneCanViewRSVP { get; set; }
		public string showGuestList { get; set; }
		public string eventImg { get; set; }
		public string createdDate { get; set; }
		public string memberName { get; set; }
		public string networkName { get; set; }
	}


    public class EventGuestsModel {
		public string inviteID { get; set; }
		public string memberID { get; set; }
		public string memberName { get; set; }
		public string email { get; set; }
        public string RSVPstatus { get; set; }
        public string imageName { get; set; }
    }


	public class EventTimesModel
	{
		public string timeID { get; set; }
		public string description { get; set; }		
	}

	public class EventGuessListByTypeModel
	{
		public string eventID { get; set; }
		public string type { get; set; }
	}

    public class MemberEventsModel {
        public string eventID { get; set; }
        public string cnt { get; set; }
        public string planningWhat { get; set; }
        public string location { get; set; }
        public string eventDate { get; set; }
        public string RSVP { get; set; }
        public string eventParams { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; } 
        public string showCancel { get; set; }
        public string eventImg { get; set; }
    }

    public class ContactsModel
    {
        public string memberID { get; set; }
        public string memberName { get; set; }
        public string imageName { get; set; }
    }


}
