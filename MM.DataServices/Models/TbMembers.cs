using System;
using System.Collections.Generic;

namespace MM.DataServices.Models
{
    public partial class TbMembers
    {
        public TbMembers()
        {
            TbAlbums = new HashSet<TbAlbums>();
            TbChatMessagesToUser = new HashSet<TbChatMessages>();
            TbChatMessagesUser = new HashSet<TbChatMessages>();
            TbContactRequestsFromMember = new HashSet<TbContactRequests>();
            TbContactRequestsToMember = new HashSet<TbContactRequests>();
            TbContactsContact = new HashSet<TbContacts>();
            TbContactsMember = new HashSet<TbContacts>();
            TbDiscussionTopicPosts = new HashSet<TbDiscussionTopicPosts>();
            TbEventInvites = new HashSet<TbEventInvites>();
            TbEvents = new HashSet<TbEvents>();
            TbLinks = new HashSet<TbLinks>();
            TbLoggedInUser = new HashSet<TbLoggedInUser>();
            TbMemberPostResponses = new HashSet<TbMemberPostResponses>();
            TbMemberPosts = new HashSet<TbMemberPosts>();
            TbMembersPrivacySettings = new HashSet<TbMembersPrivacySettings>();
            TbMembersRecentActivities = new HashSet<TbMembersRecentActivities>();
            TbMembersRegistered = new HashSet<TbMembersRegistered>();
            TbMessagesContact = new HashSet<TbMessages>();
            TbMessagesDeletedContact = new HashSet<TbMessagesDeleted>();
            TbMessagesDeletedSender = new HashSet<TbMessagesDeleted>();
            TbMessagesJunkContact = new HashSet<TbMessagesJunk>();
            TbMessagesJunkSender = new HashSet<TbMessagesJunk>();
            TbMessagesRepliesContact = new HashSet<TbMessagesReplies>();
            TbMessagesRepliesSender = new HashSet<TbMessagesReplies>();
            TbMessagesSender = new HashSet<TbMessages>();
            TbMessagesSentContact = new HashSet<TbMessagesSent>();
            TbMessagesSentSender = new HashSet<TbMessagesSent>();
            TbNetworkDiscussionTopics = new HashSet<TbNetworkDiscussionTopics>();
            TbNetworkMemberInvites = new HashSet<TbNetworkMemberInvites>();
            TbNetworkMembers = new HashSet<TbNetworkMembers>();
            TbNetworkPhotos = new HashSet<TbNetworkPhotos>();
            TbNetworkPostResponses = new HashSet<TbNetworkPostResponses>();
            TbNetworkPosts = new HashSet<TbNetworkPosts>();
            TbNetworkRecentActivities = new HashSet<TbNetworkRecentActivities>();
            TbNetworkRequests = new HashSet<TbNetworkRequests>();
            TbNetworkVideos = new HashSet<TbNetworkVideos>();
            TbNotificationSettings = new HashSet<TbNotificationSettings>();
            TbSuggestions = new HashSet<TbSuggestions>();
            TbVideos = new HashSet<TbVideos>();
        }

        public int MemberId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? Status { get; set; }
        public int? SecurityQuestion { get; set; }
        public string SecurityAnswer { get; set; }
        public int? DeactivateReason { get; set; }
        public string DeactivateExplanation { get; set; }
        public bool? FutureEmails { get; set; }
        public int? ChatStatus { get; set; }
        public bool? LogOn { get; set; }

        public TbMemberProfile TbMemberProfile { get; set; }
        public TbMemberProfileContactInfo TbMemberProfileContactInfo { get; set; }
        public TbMemberProfileEducation TbMemberProfileEducation { get; set; }
        public TbMemberProfileEmploymentInfo TbMemberProfileEmploymentInfo { get; set; }
        public TbMemberProfilePersonalInfo TbMemberProfilePersonalInfo { get; set; }
        public ICollection<TbAlbums> TbAlbums { get; set; }
        public ICollection<TbChatMessages> TbChatMessagesToUser { get; set; }
        public ICollection<TbChatMessages> TbChatMessagesUser { get; set; }
        public ICollection<TbContactRequests> TbContactRequestsFromMember { get; set; }
        public ICollection<TbContactRequests> TbContactRequestsToMember { get; set; }
        public ICollection<TbContacts> TbContactsContact { get; set; }
        public ICollection<TbContacts> TbContactsMember { get; set; }
        public ICollection<TbDiscussionTopicPosts> TbDiscussionTopicPosts { get; set; }
        public ICollection<TbEventInvites> TbEventInvites { get; set; }
        public ICollection<TbEvents> TbEvents { get; set; }
        public ICollection<TbLinks> TbLinks { get; set; }
        public ICollection<TbLoggedInUser> TbLoggedInUser { get; set; }
        public ICollection<TbMemberPostResponses> TbMemberPostResponses { get; set; }
        public ICollection<TbMemberPosts> TbMemberPosts { get; set; }
        public ICollection<TbMembersPrivacySettings> TbMembersPrivacySettings { get; set; }
        public ICollection<TbMembersRecentActivities> TbMembersRecentActivities { get; set; }
        public ICollection<TbMembersRegistered> TbMembersRegistered { get; set; }
        public ICollection<TbMessages> TbMessagesContact { get; set; }
        public ICollection<TbMessagesDeleted> TbMessagesDeletedContact { get; set; }
        public ICollection<TbMessagesDeleted> TbMessagesDeletedSender { get; set; }
        public ICollection<TbMessagesJunk> TbMessagesJunkContact { get; set; }
        public ICollection<TbMessagesJunk> TbMessagesJunkSender { get; set; }
        public ICollection<TbMessagesReplies> TbMessagesRepliesContact { get; set; }
        public ICollection<TbMessagesReplies> TbMessagesRepliesSender { get; set; }
        public ICollection<TbMessages> TbMessagesSender { get; set; }
        public ICollection<TbMessagesSent> TbMessagesSentContact { get; set; }
        public ICollection<TbMessagesSent> TbMessagesSentSender { get; set; }
        public ICollection<TbNetworkDiscussionTopics> TbNetworkDiscussionTopics { get; set; }
        public ICollection<TbNetworkMemberInvites> TbNetworkMemberInvites { get; set; }
        public ICollection<TbNetworkMembers> TbNetworkMembers { get; set; }
        public ICollection<TbNetworkPhotos> TbNetworkPhotos { get; set; }
        public ICollection<TbNetworkPostResponses> TbNetworkPostResponses { get; set; }
        public ICollection<TbNetworkPosts> TbNetworkPosts { get; set; }
        public ICollection<TbNetworkRecentActivities> TbNetworkRecentActivities { get; set; }
        public ICollection<TbNetworkRequests> TbNetworkRequests { get; set; }
        public ICollection<TbNetworkVideos> TbNetworkVideos { get; set; }
        public ICollection<TbNotificationSettings> TbNotificationSettings { get; set; }
        public ICollection<TbSuggestions> TbSuggestions { get; set; }
        public ICollection<TbVideos> TbVideos { get; set; }
    }
}
