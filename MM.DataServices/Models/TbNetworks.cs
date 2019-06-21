using System;
using System.Collections.Generic;

namespace MM.DataServices.Models
{
    public partial class TbNetworks
    {
        public TbNetworks()
        {
            TbEvents = new HashSet<TbEvents>();
            TbNetworkDiscussionTopics = new HashSet<TbNetworkDiscussionTopics>();
            TbNetworkMemberInvites = new HashSet<TbNetworkMemberInvites>();
            TbNetworkMembers = new HashSet<TbNetworkMembers>();
            TbNetworkPhotos = new HashSet<TbNetworkPhotos>();
            TbNetworkPostResponses = new HashSet<TbNetworkPostResponses>();
            TbNetworkPosts = new HashSet<TbNetworkPosts>();
            TbNetworkRecentActivities = new HashSet<TbNetworkRecentActivities>();
            TbNetworkRequests = new HashSet<TbNetworkRequests>();
            TbNetworkVideos = new HashSet<TbNetworkVideos>();
        }

        public int NetworkId { get; set; }
        public string NetworkName { get; set; }
        public string Description { get; set; }
        public int? CategoryId { get; set; }
        public int? CategoryTypeId { get; set; }
        public string RecentNews { get; set; }
        public string Office { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public bool? InActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Image { get; set; }

        public TbNetworkCategory Category { get; set; }
        public TbNetworkCategoryType CategoryType { get; set; }
        public TbNetworkSettings TbNetworkSettings { get; set; }
        public ICollection<TbEvents> TbEvents { get; set; }
        public ICollection<TbNetworkDiscussionTopics> TbNetworkDiscussionTopics { get; set; }
        public ICollection<TbNetworkMemberInvites> TbNetworkMemberInvites { get; set; }
        public ICollection<TbNetworkMembers> TbNetworkMembers { get; set; }
        public ICollection<TbNetworkPhotos> TbNetworkPhotos { get; set; }
        public ICollection<TbNetworkPostResponses> TbNetworkPostResponses { get; set; }
        public ICollection<TbNetworkPosts> TbNetworkPosts { get; set; }
        public ICollection<TbNetworkRecentActivities> TbNetworkRecentActivities { get; set; }
        public ICollection<TbNetworkRequests> TbNetworkRequests { get; set; }
        public ICollection<TbNetworkVideos> TbNetworkVideos { get; set; }
    }
}
