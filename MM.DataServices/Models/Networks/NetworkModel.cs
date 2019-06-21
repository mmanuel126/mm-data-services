using System;
namespace MM.DataServices.Models
{
	public class MemberNetworkResult
	{
		public string entityID { get; set; }
		public string entityName { get; set; }
		public string picturePath { get; set; }
		public string firstName { get; set; }
		public string lastName { get; set; }
		public string cityState { get; set; }
		public string id { get; set; }
		public string name { get; set; }
	}

    public class NetworkInfoModel
    {
        public string networkID { get; set; }
        public string networkName { get; set; }
        public string networkDesc { get; set; }
        public string categoryID { get; set; }
        public string networkImage { get; set; }
        public string memberCount { get; set; }
        public string createdDate { get; set; }
        public string networkOwner { get; set; }
		public string categoryTypeID { get; set; }
		public string recentNews { get; set; }
        public string office { get; set; }
		public string email { get; set; }
		public string webSite { get; set; }
		public string street { get; set; }
		public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string inActive { get; set; }
        public string categoryDesc { get; set; }
        public string categoryTypeDesc { get; set; }
        public string access { get; set; }
        public string IsAlreadyMemberID { get; set; }
	}

    public class NetworkMemberModel {
        public string memberID { get; set; }
        public string memberName { get; set; }
        public string picturePath { get; set; }
        public string networkID { get; set; }
        public string IsOwner { get; set; }
        public string IsAdmin { get; set; }
        public string joinedDate { get; set; }
        public string access { get; set; }
        public string titleDesc { get; set; }
		public string inviteID { get; set; }
    }

    public class RecentNetworkActivitiesResult {
		public string activityID { get; set; }
		public string description { get; set; }
		public string activityDate { get; set; }
		public string imageFile { get; set; }
    }

	public class NetworkPostsModel
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

	public class NetworkChildPostsModel
	{
		public string postResponseID { get; set; }
        public string postID { get; set; }
		public string description { get; set; }
		public string responseDate { get; set; }
		public string memberID { get; set; }
        public string picturePath { get; set; }
        public string memberName { get; set; }
        public string firstName { get; set; }
	}

	public class NetworkPhotosModel
	{
		public string countID { get; set; }
		public string photoID { get; set; }
		public string memberID { get; set; }
		public string memberName { get; set; }
		public string photoName { get; set; }
		public string photoDesc { get; set; }
        public string fileName { get; set; }
		public string Params { get; set; }
        public string CreatedDate { get; set; }
	}

	public class NetworkEventModel
	{
		public string eventID { get; set; }
		public string eventImg { get; set; }
		public string planningWhat { get; set; }
		public string location { get; set; }
		public string eventDate { get; set; }
		public string RSVP { get; set; }
		public string eventParams { get; set; }
		public string showCancel { get; set; }		
	}

	public class NetworkTopicsModel
	{
		public string topicID { get; set; }
		public string topicDesc { get; set; }
		public string memberName { get; set; }
		public string createdDate { get; set; }
		public string memberID { get; set; }
		public string topicPostCnt { get; set; }
		public string latestPostMemberID { get; set; }
		public string latestPostMemberName { get; set; }
        public string latestPostDate { get; set; }
	}

}
