using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MM.DataServices.Models;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;

namespace MM.DataServices.Events
{
    /// <summary>
    /// Describes the functionalities to access data for events
    /// </summary>
    public class EventDataManager
    {        

        #region public routines...

        public EventDataManager()
        {
        }

        /// <summary>
        /// get event times
        /// </summary>
        /// <returns></returns>
        public List<EventTimesModel> GetEventTimes()
        {
			using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
			{
                var lst = (from e in context.TbEventTimes orderby e.TimeId 
                           select new EventTimesModel() 
                {
                    timeID = e.TimeId.ToString() ,
                    description = e.Description 
                }).ToList();
                return (lst);
            }           
        }

        /// <summary>
        /// Create an event
        /// </summary>
        /// <param name="networkID"></param>
        /// <param name="memberID"></param>
        /// <param name="startDt"></param>
        /// <param name="startTime"></param>
        /// <param name="endDt"></param>
        /// <param name="endTime"></param>
        /// <param name="eventName"></param>
        /// <param name="eventInfo"></param>
        /// <param name="location"></param>
        /// <param name="street"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="zip"></param>
        /// <param name="inviteAllGrpMembers"></param>
        /// <param name="anyoneCanViewRSVP"></param>
        /// <param name="anyoneCanViewGuestList"></param>
        /// <returns></returns>
        public int CreateEvent(int networkID, int memberID, string startDt, string startTime,
                                        string endDt, string endTime, string eventName, string eventInfo,
                                        string location, string street, string city, string state,
                                        string zip, int inviteAllGrpMembers, int anyoneCanViewRSVP, int anyoneCanViewGuestList)
        {

            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {
                //create event
                TbEvents ev = new TbEvents();
                ev.NetworkId = networkID;
                ev.MemberId = memberID;
                ev.StartDate = DateTime.Parse(startDt);
                ev.StartTime = startTime;
                ev.EndDate = DateTime.Parse(endDt);
                ev.EndTime = endTime;
                ev.PlanningWhat = eventName;
                ev.MoreInfo = eventInfo;
                ev.Location = location;
                ev.Street = street;
                ev.City = city;
                ev.State = state;
                ev.Zip = zip;
                if (inviteAllGrpMembers > 0)
                    ev.InviteAllGroupMembers = true;
                else
                    ev.InviteAllGroupMembers = false;

                if (anyoneCanViewRSVP > 0)
                    ev.AnyoneCanViewRsvp = true;
                else
                    ev.AnyoneCanViewRsvp = false;

                if (anyoneCanViewGuestList > 0)
                    ev.ShowGuestList = true;
                else
                    ev.ShowGuestList = false;

                context.TbEvents.Add(ev);
                context.SaveChanges();

                int id = ev.EventId;

                if (id > 0)
                {

                    TbEventInvites ei = new TbEventInvites();
                    ei.EventId = id;
                    ei.MemberId = memberID;
                    ei.Rsvpstatus = "Attending";
                    ei.Email = "";
                    context.TbEventInvites.Add(ei);
                    context.SaveChanges();

                    if (networkID != 0)
                    {
                        if (inviteAllGrpMembers == 1)
                        {
                            List<TbNetworkMembers> netMembers = (from nm in context.TbNetworkMembers where nm.NetworkId == networkID select nm).ToList();
                            foreach (var n in netMembers)
                            {
                                if (n.MemberId != 0)
                                {
                                    if (memberID != n.MemberId)
                                    {
                                        TbEventInvites e = new TbEventInvites();
                                        e.EventId = id;
                                        e.MemberId = n.MemberId;
                                        e.Rsvpstatus = "Not Yet Replied";
                                        e.Email = "";
                                        context.TbEventInvites.Add(e);
                                        context.SaveChanges();
                                    }
                                }

                            }
                        }
                    }
                    return id;
                }
                else
                    return 0;
            }
        }

        /// <summary>
        /// Update event 
        /// </summary>
        /// <param name="eventID"></param>
        /// <param name="startDt"></param>
        /// <param name="startTime"></param>
        /// <param name="endDt"></param>
        /// <param name="endTime"></param>
        /// <param name="eventName"></param>
        /// <param name="eventInfo"></param>
        /// <param name="location"></param>
        /// <param name="street"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="zip"></param>
        /// <param name="inviteAllGrpMembers"></param>
        /// <param name="anyoneCanViewRSVP"></param>
        /// <param name="anyoneCanViewGuestList"></param>
        public void UpdateEvent(int eventID, string startDt, string startTime,
                                        string endDt, string endTime, string eventName, string eventInfo,
                                        string location, string street, string city, string state,
                                        string zip, int inviteAllGrpMembers, int anyoneCanViewRSVP, int anyoneCanViewGuestList)
        {
			using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
			{             
				var e = (from n in context.TbEvents where n.EventId == eventID select n).First();

                e.StartDate = DateTime.Parse(startDt);
                e.StartTime = startTime;
                e.EndDate = DateTime.Parse(endDt);
                e.EndTime = endTime;
                e.PlanningWhat = eventName;
                e.MoreInfo = eventInfo;
                e.Location = location;
                e.Street = street;
                e.City = city;
                e.State = state;
                e.Zip = zip;

				if (inviteAllGrpMembers > 0)
					e.InviteAllGroupMembers = true;
				else
					e.InviteAllGroupMembers = false;

				if (anyoneCanViewRSVP > 0)
					e.AnyoneCanViewRsvp = true;
				else
					e.AnyoneCanViewRsvp = false;

				if (anyoneCanViewGuestList > 0)
					e.ShowGuestList = true;
				else
					e.ShowGuestList = false;                
               context.SaveChanges(); 
            }
        }


        /// <summary>
        /// get event info
        /// </summary>
        /// <param name="eventID"></param>
        /// <returns></returns>
        public List<EventInfoModel> GetEventInfo(int eventID)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {
                var lst = (from e in context.TbEvents
                           join i in context.TbEventInvites
                            on e.EventId equals i.EventId
                           join mn in context.TbMemberProfile
                            on e.MemberId equals mn.MemberId
                           join n in context.TbNetworks
                            on e.NetworkId equals n.NetworkId
                           where e.EventId == eventID
                           select new EventInfoModel()
                           {
                               eventID = e.EventId.ToString(),
                               networkID = e.NetworkId.ToString(),
                               memberID = e.MemberId.ToString(),
                               startDate = e.StartDate.ToString(),
                               startTime = e.StartTime,
                               startEndTime = e.StartEndTime,
                               endDate = e.EndDate.ToString(),
                               endTime = e.EndTime,
                               endEndTime = e.EndEndTime,
                               planningWhat = e.PlanningWhat,
                               location = e.Location,
                               street = e.Street,
                               city = e.City,
                               state = e.State,
                               zip = e.Zip,
                               moreInfo = e.MoreInfo,
                               inviteAllGroupMembers = e.InviteAllGroupMembers.ToString(),
                               anyoneCanViewRSVP = e.AnyoneCanViewRsvp.ToString(),
                               showGuestList = e.ShowGuestList.ToString(),
                               eventImg = string.IsNullOrEmpty(e.EventImg) ? "default.png" : e.EventImg,
                               createdDate = e.CreatedDate.ToString(),
                               memberName = mn.FirstName + " " + mn.LastName,
                               networkName = n.NetworkName
                           }).ToList();
                return lst;
            }
        }

        /// <summary>
        /// get event guest list
        /// </summary>
        /// <param name="eventID"></param>
        /// <returns></returns>
        public List<EventGuestsModel> GetEventGuestList(int eventID)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {
                var lst = (from m in context.TbMemberProfile
                           join i in context.TbEventInvites
                            on m.MemberId equals i.MemberId
                           where i.EventId == eventID
                           select new EventGuestsModel()
                           {
                               inviteID = i.InviteId.ToString(),
                               memberID = i.MemberId.ToString(),
                               memberName = m.FirstName + " " + m.LastName,
                               email = i.Email,
                               RSVPstatus = i.Rsvpstatus.ToString(),
                               imageName = string.IsNullOrEmpty(m.PicturePath) ? "default.png" : m.PicturePath
                           }).ToList();
                return lst;
            }
        }

        /// <summary>
        /// Get event guest list by type
        /// </summary>
        /// <param name="eventID"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<EventGuestsModel> GetEventGuestList(int eventID, string type)
        {
			using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
			{
				context.Database.OpenConnection();
				DbCommand cmd = context.Database.GetDbConnection().CreateCommand();
				cmd.CommandText = "spGetEventGuestListByType";
				cmd.CommandType = CommandType.StoredProcedure;

				DbParameter param1 = cmd.CreateParameter();
				param1.ParameterName = "@EventID";
				param1.Value = eventID;

				DbParameter param2 = cmd.CreateParameter();
				param2.ParameterName = "@Type";
				param2.Value = type;

				cmd.Parameters.Add(param1);
				cmd.Parameters.Add(param2);


				List<EventGuestsModel> lst = new List<EventGuestsModel>();
				using (var reader = cmd.ExecuteReader())
				{
                    EventGuestsModel e = new EventGuestsModel();
					while (reader.Read())
					{
						e.inviteID = reader["InviteID"].ToString();
						e.memberID = reader["MemberID"].ToString();
						e.memberName = reader["MemberName"].ToString();
                        e.email  = reader["email"].ToString();
						e.RSVPstatus  = reader["RSVPStatus"].ToString();
                        e.imageName = string.IsNullOrEmpty(reader["ImageName"].ToString() )?"default.png":reader["ImageName"].ToString() ; 
						lst.Add(e);
					}
				}
                return lst;
            }           
        }

        /// <summary>
        /// Get contacts list
        /// </summary>
        /// <param name="memberID"></param>
        /// <param name="eventID"></param>
        /// <returns></returns>
        public List<ContactsModel> GetContactsList(int memberID, int eventID)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {
                context.Database.OpenConnection();
                DbCommand cmd = context.Database.GetDbConnection().CreateCommand();
                cmd.CommandText = "spGetContactsList";
                cmd.CommandType = CommandType.StoredProcedure;

                DbParameter param1 = cmd.CreateParameter();
                param1.ParameterName = "@MemberID";
                param1.Value = memberID;

                DbParameter param2 = cmd.CreateParameter();
                param2.ParameterName = "@EventID";
                param2.Value = eventID;

                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);

                List<ContactsModel> lst = new List<ContactsModel>();
                using (var reader = cmd.ExecuteReader())
                {
                    ContactsModel e = new ContactsModel();
                    while (reader.Read())
                    {
                        e.memberID = reader["MemberID"].ToString();
                        e.memberName = reader["MemberName"].ToString();
                        e.imageName = reader["ImageName"].ToString();
                        lst.Add(e);
                    }
                }
                return (lst);
            }
        }

        /// <summary>
        /// invite member to event
        /// </summary>
        /// <param name="networkID"></param>
        /// <param name="eventID"></param>
        /// <param name="memberID"></param>
        /// <param name="email"></param>
        public void InviteMemberToEvent(int networkID, int eventID, int memberID, string email)
        {
			using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
			{
                var pNetID = new SqlParameter("@NetworkID", networkID);
                var pEvID = new SqlParameter("@EventID", eventID);
                var pMemID = new SqlParameter("@MemberID", memberID);
                var pEmail = new SqlParameter("@NetworkID", email);


                context.Database.ExecuteSqlCommand ("EXEC spInviteMemberToEvent @NetworkID, @EventID, @MemberID, @Email",
                                                   pNetID,pEvID, pMemID, pEmail);
            }           
        }

        /// <summary>
        /// create event post
        /// </summary>
        /// <param name="eventID"></param>
        /// <param name="memberID"></param>
        /// <param name="post"></param>
        public void CreateEventPost(int eventID, int memberID, string post)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {                
                var pEvID = new SqlParameter("@EventID", eventID);
                var pMemID = new SqlParameter("@MemberID", memberID);
                var pPost = new SqlParameter("@Post", post);
                context.Database.ExecuteSqlCommand("EXEC spCreateEventPost @EventID, @MemberID, @Post",
                                                  pEvID,pMemID,pPost);
            }
        }

        /// <summary>
        /// Get events for event id
        /// </summary>
        /// <param name="eventID"></param>
        /// <returns></returns>
        public List<EventPostModel> GetEventPosts(int eventID)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {
                var lst = (from p in context.TbEventPosts
                           join mn in context.TbMemberProfile on p.MemberId equals mn.MemberId
                           where p.EventId == eventID
                           orderby p.PostDate descending
                           select new EventPostModel()
                           {
                               postID = p.PostId.ToString(),
                               title = p.Title,
                               description = p.Description,
                               postDate = p.PostDate.ToString(),
                               attachFile = p.AttachFile,
                               memberID = p.MemberId.ToString(),
                               picturePath = string.IsNullOrEmpty(mn.PicturePath) ? "default.png" : mn.PicturePath,
                               memberName = mn.FirstName + " " + mn.LastName,
                               firstName = mn.FirstName

                           }).ToList();
                return (lst);
            }
        }

        /// <summary>
        /// Update RSVP Status
        /// </summary>
        /// <param name="eventID"></param>
        /// <param name="memberID"></param>
        /// <param name="status"></param>
        public void UpdateRSVPSStatus(int eventID, int memberID, string status)
        {
			using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
			{
				var pEvID = new SqlParameter("@EventID", eventID);
				var pMemID = new SqlParameter("@MemberID", memberID);
				var pStatus = new SqlParameter("@Status", status);

				context.Database.ExecuteSqlCommand("EXEC spUpdateRSVPSStatus @EventID, @MemberID, @Status",
												  pEvID, pMemID, pStatus);
            }
        }

        /// <summary>
        /// Update event image for event id
        /// </summary>
        /// <param name="eventID"></param>
        /// <param name="fileName"></param>
        public void UpdateEventImage(int eventID, string fileName)
        {
			using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
			{
				var ev = (from e in context.TbEvents where e.EventId == eventID select e).First();
                ev.EventImg = fileName;
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Gets the member events.
        /// </summary>
        /// <returns>The member events.</returns>
        /// <param name="memberID">Member identifier.</param>
        /// <param name="show">Show.</param>
        public List<MemberEventsModel> GetMemberEvents(int memberID, string show)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {
                context.Database.OpenConnection();
                DbCommand cmd = context.Database.GetDbConnection().CreateCommand();
                cmd.CommandText = "spGetMemberEvents";
                cmd.CommandType = CommandType.StoredProcedure;

				DbParameter param1 = cmd.CreateParameter();
				param1.ParameterName = "@MemberID";
				param1.Value = memberID;

				DbParameter param2 = cmd.CreateParameter();
				param2.ParameterName = "@type";
                if (show == null)
                    param2.Value = "";
                else
                    param2.Value = show;

				cmd.Parameters.Add(param1);
				cmd.Parameters.Add(param2);


                List<MemberEventsModel> lst = new List<MemberEventsModel>() ;

                using (var reader = cmd.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        MemberEventsModel e = new MemberEventsModel();
                        e.eventID = reader["EventID"].ToString(); 
                        e.cnt = reader["cnt"].ToString();
                        e.planningWhat = reader["planningwhat"].ToString();
                        e.location = reader["location"].ToString();
                        e.eventDate = reader["eventdate"].ToString();
                        e.RSVP = reader["RSVP"].ToString();
                        e.eventParams  = reader["EventParams"].ToString();
                        e.startDate = reader["startdate"].ToString();
                        e.endDate = reader["enddate"].ToString();
                        e.showCancel = reader["ShowCancel"].ToString();
                        e.eventImg = reader["eventimg"].ToString();
						lst.Add(e);                        					
					}                   
                }
                return (lst);
            }
        }

        /// <summary>
        /// Get totlal event invites for member id
        /// </summary>
        /// <param name="memberID"></param>
        /// <returns></returns>
        public int? GetTotalEventInvites(int memberID)
        {
			using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
			{

				var ev = (from e in context.TbEvents join i in context.TbEventInvites on e.EventId equals i.EventId where i.MemberId == memberID
                          && e.StartDate  >= DateTime.Now  select e).ToList();                          			
                return (ev.Count() );
            }
        }

        /// <summary>
        /// cancel event given an event id
        /// </summary>
        /// <param name="eventID"></param>
        public void CancelEvent(int eventID)
        {
			using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
			{
                var pEvID = new SqlParameter("@EventID", eventID);
				context.Database.ExecuteSqlCommand ("EXEC spCancelEvent @EventID", pEvID);
            }           
        }

        /// <summary>
        /// Checks the member event access.
        /// </summary>
        /// <returns><c>true</c>, if member event access was checked, <c>false</c> otherwise.</returns>
        /// <param name="eventID">Event identifier.</param>
        /// <param name="memID">Mem identifier.</param>
        public bool CheckMemberEventAccess(int eventID, int memID)
        {
			using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
			{
                var ev = (from e in context.TbEvents where e.EventId == eventID select e).First();

                if (ev.MemberId == memID)
                    return true;
                else
                {
                    if (ev.NetworkId != null || ev.NetworkId != 0)
                    {
                        var nw = (from n in context.TbNetworkMembers where n.MemberId == memID select n).First();
                        if ((nw.IsAdmin == true) || (nw.IsOwner == true))
                            return true;
                        else
                            return false;
                    }
                    else
                        return false;
                }               
            }           
        }

        #endregion
    }
}
