using System;
namespace MM.DataServices.Models
{
    public class MemberContactModel
    {
        public string friendName { get; set; }
        public string firstName { get; set; }
        public string location { get; set; }
        public string picturePath { get; set; }
        public string contactID { get; set; }
        public string showType { get; set; }
        public string status { get; set; }
        public string titleDesc { get; set; }
        public string Params { get; set; }
        public string paramsAV { get; set; }
        public string email { get; set; }
        public string labelText { get; set; }
        public string nameAndID { get; set; }
    }

    public class MemberPhoneBookModel {
        public string friendName { get; set; }
        public string homePhone { get; set; }
        public string cellPhone { get; set; }
        public string picturePath { get; set; }
        public string contactID { get; set; }
    }

	public class MemberByTypeModel
	{
		public string MemberID { get; set; }
		public string Name { get; set; }
		public string PicturePath { get; set; }
		public string TypeVal { get; set; }
        public string IsFriend { get; set; }
        public string IsSamePerson { get; set; }
	}

    public class EntityModel {
        public string entityID { get; set; }
        public string entityName { get; set; }
        public string picturePath { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string cityState { get; set; }
        public string id { get; set; }
        public string name { get; set; }
    }

	public class ContactSearchModel
	{
		public string entityID { get; set; }
		public string entityName { get; set; }		
		public string picturePath { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
		public string cityState { get; set; }
		public string labelText { get; set; }
		public string email { get; set; }
		public string nameAndID { get; set; }
		public string Params { get; set; }
		public string paramsAV { get; set; }
		public string description { get; set; }
		public string memberCount { get; set; }
		public string createdDate { get; set; }
        public string location { get; set; }
        public string eventDate { get; set; }
        public string rsvp { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }

	}

	public class NetworkSearchModel
	{
		public string entityID { get; set; }
		public string entityName { get; set; }
		public string picturePath { get; set; }		
		public string labelText { get; set; }
		public string email { get; set; }
		public string nameAndID { get; set; }
		public string Params { get; set; }
		public string paramsAV { get; set; }
		public string description { get; set; }
		public string memberCount { get; set; }
		public string createdDate { get; set; }
		public string cityState { get; set; }
		public string eventDate { get; set; }
		public string rsvp { get; set; }
		public string startDate { get; set; }
		public string endDate { get; set; }
        public string location { get; set; }
	}

	public class EventSearchModel
	{
		public string entityID { get; set; }
		public string entityName { get; set; }
		public string picturePath { get; set; }
		public string location { get; set; }
		public string eventDate { get; set; }
		public string rsvp { get; set; }
		public string Params { get; set; }		
		public string description { get; set; }
		public string memberCount { get; set; }
		public string createdDate { get; set; }
		public string cityState { get; set; }
		public string email { get; set; }
        public string NameAndID { get; set; }
		public string eventParams { get; set; }
		public string startDate { get; set; }
		public string endDate { get; set; }
        public string labelText { get; set; }
		public string ShowCancel { get; set; }
        public string ParamsAV { get; set; }
	}

	public class SearchModel
	{
		public int entityID { get; set; }
		public string entityName { get; set; }
		public string picturePath { get; set; }
		public string location { get; set; }
		public string eventDate { get; set; }
		public string rsvp { get; set; }
		public string Params { get; set; }
		public string description { get; set; }
		public string memberCount { get; set; }
		public DateTime createdDate { get; set; }
		public string cityState { get; set; }
		public string email { get; set; }
		public string NameAndID { get; set; }
		//public string eventParams { get; set; }
		public DateTime startDate { get; set; }
		public DateTime endDate { get; set; }
		public string labelText { get; set; }
		public string ShowCancel { get; set; }
		public string ParamsAV { get; set; }
        public string sType { get; set; }
	}
}
