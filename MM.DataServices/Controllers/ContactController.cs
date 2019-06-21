using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MM.DataServices.Models;
using MM.DataServices.Contacts;

namespace MM.DataServices.Controllers
{
    [Route("services/[controller]/[action]")]
    public class ContactController : Controller
    {
        private readonly ContactDataManager contactMgr;

        public ContactController()
        {
            contactMgr = new ContactDataManager();
        }

        /// <summary>
        /// Gets a list of member contacts by the given member ID and show type.
        /// </summary>
        /// <returns>The member contacts.</returns>
        /// <param name="memberID">Member identifier.</param>
        /// <param name="show">Show could be "requests" or "RecentlyAdded".</param>
        [HttpGet]
        public List<MemberContactModel> GetMemberContacts([FromQuery] int memberID, [FromQuery] string show)
        {
            List<MemberContactModel> lst = contactMgr.GetMemberContacts(memberID, show).ToList();
            return lst;
        }


        /// <summary>
        /// Gets the list of member contact suggestions for a member ID.
        /// </summary>
        /// <returns>The member contact suggestions.</returns>
        /// <param name="memberID">Member identifier.</param>
        [HttpGet]
        public List<MemberContactModel> GetMemberContactSuggestions([FromQuery] int memberID)
        {
            List<MemberContactModel> lst = contactMgr.GetMemberContactSuggestions(memberID).ToList();
            return lst;
        }

        /// <summary>
        /// Sends the request to contact.
        /// </summary>
        /// <param name="memberID">Member identifier.</param>
        /// <param name="contactID">Contact identifier.</param>
        [HttpPut]
        public void  SendRequestContact(string memberID, string contactID)
        {
            contactMgr.SendRequestContact( memberID,  contactID);
        }


        /// <summary>
        /// Searchs and return list of contacts for a given member ID and search Text.
        /// </summary>
        /// <returns>The member contacts.</returns>
        /// <param name="memberID">Member identifier.</param>
        /// <param name="searchText">Search text.</param>
        [HttpGet]
        public List<MemberContactModel> SearchMemberContacts([FromQuery] int memberID, [FromQuery] string searchText)
        {
            List<MemberContactModel> lst = contactMgr.SearchMemberContacts(memberID, searchText);
            return lst;
        }

        /// <summary>
        /// Gets the member network invite contact list.
        /// </summary>
        /// <returns>The member network invite contact list.</returns>
        /// <param name="memberID">Member identifier.</param>
        /// <param name="networkID">Network identifier.</param>
        [HttpGet]
        public List<MemberContactModel> GetMemberNetworkInviteContactList([FromQuery] int memberID, [FromQuery] int networkID)
        {
            List<MemberContactModel> lst = contactMgr.GetMemberNetworkInviteContactList(memberID, networkID).ToList();
            return lst;
        }

        /// <summary>
        /// Gets the requests list.
        /// </summary>
        /// <returns>The requests list.</returns>
        /// <param name="memberID">Member identifier.</param>
        [HttpGet]
        public List<MemberContactModel> GetRequestsList([FromQuery] int memberID)
        {
            List<MemberContactModel> lst = contactMgr.GetRequestsList(memberID).ToList();
            return lst;
        }

        /// <summary>
        /// Gets members list by search type.
        /// </summary>
        /// <returns>The members by search type.</returns>
        /// <param name="userID">User identifier.</param>
        /// <param name="searchType">Search type.</param>
        /// <param name="searchText">Search text.</param>
        [HttpGet]
        public List<MemberContactModel> GetMembersBySearchType([FromQuery] int userID, [FromQuery] string searchType, [FromQuery] string searchText)
        {
            List<MemberContactModel> lst = contactMgr.GetMembersBySearchType(userID, searchType, searchText).ToList();
            return lst;
        }

        /// <summary>
        /// Gets the search contacts.
        /// </summary>
        /// <returns>The search contacts.</returns>
        /// <param name="userID">User identifier.</param>
        /// <param name="searchText">Search text.</param>
        [HttpGet]
        public List<MemberContactModel> GetSearchContacts([FromQuery] int userID, [FromQuery] string searchText)
        {
            List<MemberContactModel> lst = contactMgr.GetSearchContacts(userID, searchText).ToList();
            return lst;
        }

        /// <summary>
        /// Gets the member phone book.
        /// </summary>
        /// <returns>The member phone book.</returns>
        /// <param name="memberID">Member identifier.</param>
        [HttpGet]
        public List<MemberPhoneBookModel> GetMemberPhoneBook([FromQuery] int memberID)
        {
            List<MemberPhoneBookModel> lst = contactMgr.GetMemberPhoneBook(memberID).ToList();
            return lst;
        }

        /// <summary>
        /// Gets the member browsed contacts.
        /// </summary>
        /// <returns>The member browsed contacts.</returns>
        /// <param name="memberID">Member identifier.</param>
        /// <param name="categoryID">Category identifier.</param>
        /// <param name="subCategory">Sub category.</param>
        [HttpGet]
        public List<MemberContactModel> GetMemberBrowsedContacts([FromQuery] int memberID, [FromQuery] int categoryID, [FromQuery] string subCategory)
        {
            List<MemberContactModel> lst = contactMgr.GetMemberBrowsedContacts(memberID, categoryID, subCategory).ToList();
            return lst;
        }

        /// <summary>
        /// Searchs members by a gven type and member ID.
        /// </summary>
        /// <returns>The member by type.</returns>
        /// <param name="userID">User identifier.</param>
        /// <param name="searchType">Search type.</param>
        /// <param name="searchString">Search string.</param>
        [HttpGet]
        public List<MemberByTypeModel> SearchMemberByType([FromQuery] int userID, [FromQuery] int searchType, [FromQuery] string searchString)
        {
            List<MemberByTypeModel> lst = contactMgr.SearchMemberByType(userID, searchType, searchString).ToList();
            return lst;
        }

        /// <summary>
        /// member accepts request from contact 
        /// </summary>
        /// <param name="memberID">Member identifier.</param>
        /// <param name="contactID">Contact identifier.</param>
        [HttpPut]
        public void AcceptRequest([FromQuery] int memberID, [FromQuery] int contactID)
        {
            contactMgr.AcceptRequest(memberID, contactID);
        }

        /// <summary>
        /// Member rejects the request from contact.
        /// </summary>
        /// <param name="memberID">Member identifier.</param>
        /// <param name="contactID">Contact identifier.</param>
        [HttpPut]
        public void RejectRequest([FromQuery] int memberID, [FromQuery] int contactID)
        {
            contactMgr.RejectRequest(memberID, contactID);
        }

        /// <summary>
        /// Deletes the contact.
        /// </summary>
        /// <param name="memberID">Member identifier.</param>
        /// <param name="contactID">Contact identifier.</param>
        [HttpDelete]
        public void DeleteContact([FromQuery] int memberID, [FromQuery] int contactID)
        {
            contactMgr.DeleteContact(memberID, contactID);
        }

        /// <summary>
        /// Gets the entity list by search type.
        /// </summary>
        /// <returns>The entity by search type.</returns>
        /// <param name="memberID">Member identifier.</param>
        /// <param name="searchText">Search text.</param>
        /// <param name="searchType">Search type.</param>
        [HttpGet]
        public List<EntityModel> GetEntityBySearchType([FromQuery] int memberID, [FromQuery] string searchText, [FromQuery] string searchType)
        {
            List<EntityModel> lst = contactMgr.GetEntityBySearchType(memberID, searchText, searchType).ToList();
            return lst;
        }

        /// <summary>
        /// Get the searched contacts by search criteria member id and search text.
        /// </summary>
        /// <returns>The search results.</returns>
        /// <param name="memberID">Member identifier.</param>
        /// <param name="searchText">Search text.</param>
        [HttpGet]
        public List<ContactSearchModel> ContactSearchResults([FromQuery] int memberID, [FromQuery] string searchText)
        {
            List<ContactSearchModel> lst = contactMgr.ContactSearchResults(memberID, searchText).ToList();
            return lst;
        }

        /// <summary>
        /// /gets lsit of people by member id and searched text.
        /// </summary>
        /// <returns>The search results.</returns>
        /// <param name="memberID">Member identifier.</param>
        /// <param name="searchText">Search text.</param>
        [HttpGet]
        public List<ContactSearchModel> PeopleSearchResults([FromQuery] int memberID, [FromQuery] string searchText)
        {
            List<ContactSearchModel> lst = contactMgr.PeopleSearchResults(memberID, searchText).ToList();
            return lst;
        }

        /// <summary>
        /// Search list of Networks by member ID and search text.
        /// </summary>
        /// <returns>The search results.</returns>
        /// <param name="memberID">Member identifier.</param>
        /// <param name="searchText">Search text.</param>
        [HttpGet]
        public List<NetworkSearchModel> NetworkSearchResults([FromQuery] int memberID, [FromQuery] string searchText)
        {
            List<NetworkSearchModel> lst = contactMgr.NetworkSearchResults(memberID, searchText).ToList();
            return lst;
        }

        /// <summary>
        /// returns list of events by member ID and search text.
        /// </summary>
        /// <returns>The search results.</returns>
        /// <param name="memberID">Member identifier.</param>
        /// <param name="searchText">Search text.</param>
        [HttpGet]
        public List<EventSearchModel> EventSearchResults([FromQuery]int memberID, [FromQuery] string searchText)
        {
            List<EventSearchModel> lst = contactMgr.EventSearchResults(memberID, searchText).ToList();
            return lst;
        }

        /// <summary>
        /// reuturns the list of Contacts by search text.
        /// </summary>
        /// <returns>The results.</returns>
        /// <param name="memberID">Member identifier.</param>
        /// <param name="searchText">Search text.</param>
        [HttpGet]
        public List<SearchModel> SearchResults([FromQuery] int memberID, [FromQuery] string searchText)
        {
            List<SearchModel> lst = contactMgr.SearchResults(memberID, searchText).ToList();
            return lst;
        }
    }
}
