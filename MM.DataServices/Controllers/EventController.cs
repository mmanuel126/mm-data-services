using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MM.DataServices.Models;
using MM.DataServices.Events;

namespace MM.DataServices.Controllers
{
    [Route("services/[controller]/[action]")]
    public class EventController : Controller
    {
        EventDataManager eventMgr;

        public EventController()
        {
            eventMgr = new EventDataManager();
        }

        /// <summary>
        /// Gets the list of event times.
        /// </summary>
        /// <returns>The event times.</returns>
        [HttpGet]
        public List<EventTimesModel> GetEventTimes()
        {
            List<EventTimesModel> lst = eventMgr.GetEventTimes();
            return (lst);
        }

        /// <summary>
        /// Creates an event.
        /// </summary>
        /// <returns>The event.</returns>
        /// <param name="networkID">Network identifier.</param>
        /// <param name="memberID">Member identifier.</param>
        /// <param name="startDt">Start date.</param>
        /// <param name="startTime">Start time.</param>
        /// <param name="endDt">End date.</param>
        /// <param name="endTime">End time.</param>
        /// <param name="eventName">Event name.</param>
        /// <param name="eventInfo">Event information.</param>
        /// <param name="location">Location of the event.</param>
        /// <param name="street">Street where event will occur.</param>
        /// <param name="city">City of where event will occur.</param>
        /// <param name="state">State of where event will occur.</param>
        /// <param name="zip">Zip code of where event will occur.</param>
        /// <param name="inviteAllGrpMembers">value of whether to invite all group members.</param>
        /// <param name="anyoneCanViewRSVP">value of whether anyone can view rsvp.</param>
        /// <param name="anyoneCanViewGuestList">value of whether anyone can view guest list.</param>
        [HttpPost]
        public int CreateEvent([FromQuery] int networkID, [FromQuery]int memberID, [FromQuery] string startDt, [FromQuery] string startTime,
                                        [FromQuery] string endDt, [FromQuery] string endTime, [FromQuery] string eventName, [FromQuery] string eventInfo,
                                        [FromQuery] string location, [FromQuery] string street, [FromQuery] string city, [FromQuery] string state,
                                        [FromQuery] string zip, [FromQuery]int inviteAllGrpMembers, [FromQuery] int anyoneCanViewRSVP, [FromQuery] int anyoneCanViewGuestList)
        {
            int eID = eventMgr.CreateEvent(networkID, memberID, startDt, startTime, endDt, endTime, eventName,
                                                                  eventInfo, location, street, city, state, zip, inviteAllGrpMembers, anyoneCanViewRSVP, anyoneCanViewGuestList);
            return (eID);
        }

        /// <summary>
        /// Updates an event.
        /// </summary>
        /// <param name="eventID">Event identifier.</param>
        /// <param name="startDt">Start date.</param>
        /// <param name="startTime">Start time.</param>
        /// <param name="endDt">End date.</param>
        /// <param name="endTime">End time.</param>
        /// <param name="eventName">Event name.</param>
        /// <param name="eventInfo">Event information.</param>
        /// <param name="location">the location of where event will occur</param>
        /// <param name="street">the street of where event will occur.</param>
        /// <param name="city">the city of where event will occur.</param>
        /// <param name="state">the state of where event will occur.</param>
        /// <param name="zip">the zip code of where event will occur.</param>
        /// <param name="inviteAllGrpMembers">value of whether to invite all group members.</param>
        /// <param name="anyoneCanViewRSVP">value of whether anyone can view rsvp.</param>
        /// <param name="anyoneCanViewGuestList">value of whether anyone can view guest list</param>
        [HttpPut]
        public void UpdateEvent([FromQuery] int eventID, [FromQuery] string startDt, [FromQuery] string startTime,
                                       [FromQuery] string endDt, [FromQuery] string endTime, [FromQuery] string eventName, [FromQuery] string eventInfo,
                                       [FromQuery] string location, [FromQuery] string street, [FromQuery] string city, [FromQuery] string state,
                                       [FromQuery] string zip, [FromQuery] int inviteAllGrpMembers, [FromQuery] int anyoneCanViewRSVP,
                                       [FromQuery] int anyoneCanViewGuestList)
        {
            eventMgr.UpdateEvent(eventID, startDt, startTime, endDt, endTime, eventName, eventInfo, location, street, city, state, zip, inviteAllGrpMembers, anyoneCanViewRSVP, anyoneCanViewGuestList);
        }

        /// <summary>
        /// Gets the event information.
        /// </summary>
        /// <returns>The event info.</returns>
        /// <param name="eventID">Event identifier.</param>
        [HttpGet]
        public List<EventInfoModel> GetEventInfo([FromQuery] int eventID)
        {
            List<EventInfoModel> lst = eventMgr.GetEventInfo(eventID);
            return lst;
        }

        /// <summary>
        /// Gets the event guest list by identifier.
        /// </summary>
        /// <returns>The event guest list by identifier.</returns>
        /// <param name="eventID">Event identifier.</param>
        [HttpGet]
        public List<EventGuestsModel> GetEventGuestListById([FromQuery] int eventID)
        {
            List<EventGuestsModel> lst = eventMgr.GetEventGuestList(eventID);
            return lst;
        }

        /// <summary>
        /// Gets the event guest list by type and identifier.
        /// </summary>
        /// <returns>The event guest list by type and identifier.</returns>
        /// <param name="eventID">Event identifier.</param>
        /// <param name="type">Type.</param>
        [HttpGet]
        public List<EventGuestsModel> GetEventGuestListByTypeAndId([FromQuery] int eventID, [FromQuery]  string type)
        {
            List<EventGuestsModel> lst = eventMgr.GetEventGuestList(eventID, type);
            return lst;
        }

        /// <summary>
        /// Gets the contacts list.
        /// </summary>
        /// <returns>The contacts list.</returns>
        /// <param name="memberID">Member identifier.</param>
        /// <param name="eventID">Event identifier.</param>
        [HttpGet]
        public List<ContactsModel> GetContactsList([FromQuery] int memberID, [FromQuery] int eventID)
        {
            List<ContactsModel> lst = eventMgr.GetContactsList(memberID, eventID);
            return lst;
        }

        /// <summary>
        /// Invites the member to event.
        /// </summary>
        /// <param name="networkID">Network identifier.</param>
        /// <param name="eventID">Event identifier.</param>
        /// <param name="memberID">Member identifier.</param>
        /// <param name="email">Email.</param>
        [HttpPost]
        public void InviteMemberToEvent([FromQuery] int networkID, [FromQuery] int eventID, [FromQuery] int memberID, [FromQuery] string email)
        {
            eventMgr.InviteMemberToEvent(networkID, eventID, memberID, email);
        }

        /// <summary>
        /// Creates the event post.
        /// </summary>
        /// <param name="eventID">Event identifier.</param>
        /// <param name="memberID">Member identifier.</param>
        /// <param name="post">Post.</param>
        [HttpPost]
        public void CreateEventPost([FromQuery] int eventID, [FromQuery] int memberID, [FromQuery] string post)
        {
            eventMgr.CreateEventPost(eventID, memberID, post);
        }

        /// <summary>
        /// Gets the event posts.
        /// </summary>
        /// <returns>The event posts.</returns>
        /// <param name="eventID">Event identifier.</param>
        [HttpGet]
        public List<EventPostModel> GetEventPosts([FromQuery] int eventID)
        {
            List<EventPostModel> lst = eventMgr.GetEventPosts(eventID);
            return (lst);
        }

        /// <summary>
        /// Updates the RSVPS Status.
        /// </summary>
        /// <param name="eventID">Event identifier.</param>
        /// <param name="memberID">Member identifier.</param>
        /// <param name="status">Status.</param>
        [HttpPut]
        public void UpdateRSVPSStatus([FromQuery]int eventID, [FromQuery]int memberID, [FromQuery]string status)
        {
                eventMgr.UpdateRSVPSStatus(eventID, memberID, status);
        }

        /// <summary>
        /// Updates the event image.
        /// </summary>
        /// <param name="eventID">Event identifier.</param>
        /// <param name="fileName">File name.</param>
        [HttpPut]
        public void UpdateEventImage([FromQuery] int eventID, [FromQuery] string fileName)
        {
                eventMgr.UpdateEventImage(eventID, fileName);
        }

        /// <summary>
        /// Gets the member events.
        /// </summary>
        /// <returns>The member events.</returns>
        /// <param name="memberID">Member identifier.</param>
        /// <param name="show">Show.</param>
        [HttpGet]
        public List<MemberEventsModel> GetMemberEvents([FromQuery]int memberID, [FromQuery] string show)
        {
            List<MemberEventsModel> lst = eventMgr.GetMemberEvents(memberID, show);
            return lst;
        }

        /// <summary>
        /// Gets the total event invites.
        /// </summary>
        /// <returns>The total event invites.</returns>
        /// <param name="memberID">Member identifier.</param>
        [HttpGet]
        public int? GetTotalEventInvites([FromQuery] int memberID)
        {
            int? total = eventMgr.GetTotalEventInvites(memberID);
            return total;
        }

        /// <summary>
        /// Cancels the event.
        /// </summary>
        /// <param name="eventID">Event identifier.</param>
        [HttpDelete]
        public void CancelEvent([FromQuery] int eventID)
        {
            eventMgr.CancelEvent(eventID);
        }

        /// <summary>
        /// Checks the member event access.
        /// </summary>
        /// <returns><c>true</c>, if member event access was checked, <c>false</c> otherwise.</returns>
        /// <param name="eventID">Event identifier.</param>
        /// <param name="memID">Mem identifier.</param>
        [HttpGet]
        public bool CheckMemberEventAccess([FromQuery] int eventID, [FromQuery]int memID)
        {
            bool res = eventMgr.CheckMemberEventAccess(eventID, memID);
            return res;
        }


    }
}
