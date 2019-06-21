using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MM.DataServices.Models;
using MM.DataServices.Networking;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MM.DataServices.Controllers
{
    [Route("services/[controller]/[action]")]
    public class NetworkController : Controller
    {
        private readonly NetworkDataManager netMgr;

        public NetworkController()
        {
            netMgr = new NetworkDataManager();
        }

        /// <summary>
        /// Creates the network.
        /// </summary>
        /// <returns>The network.</returns>
        /// <param name="memberID">Member identifier.</param>
        /// <param name="networkName">Network name.</param>
        /// <param name="desc">Desc.</param>
        /// <param name="category">Category.</param>
        /// <param name="type">Type.</param>
        /// <param name="news">News.</param>
        /// <param name="office">Office.</param>
        /// <param name="email">Email.</param>
        /// <param name="webSite">Web site.</param>
        /// <param name="street">Street.</param>
        /// <param name="city">City.</param>
        /// <param name="state">State.</param>
        /// <param name="zip">Zip.</param>
        [HttpPost]
        public int CreateNetwork([FromQuery] int memberID, [FromQuery] string networkName,
                                        [FromQuery] string desc,
                                        [FromQuery] int category,
                                        [FromQuery] int type,
                                        [FromQuery] string news,
                                        [FromQuery] string office,
                                        [FromQuery] string email,
                                        [FromQuery] string webSite,
                                        [FromQuery] string street,
                                        [FromQuery] string city,
                                        [FromQuery] string state,
                                        [FromQuery] string zip)
        {

            int id = netMgr.CreateNetwork(memberID, networkName, desc, category, type, news, office, email, webSite, street, city, state, zip);
            return (id);
        }

        /// <summary>
        /// Updates the network.
        /// </summary>
        /// <param name="networkID">Network identifier.</param>
        /// <param name="networkName">Network name.</param>
        /// <param name="desc">Desc.</param>
        /// <param name="category">Category.</param>
        /// <param name="type">Type.</param>
        /// <param name="news">News.</param>
        /// <param name="office">Office.</param>
        /// <param name="email">Email.</param>
        /// <param name="webSite">Web site.</param>
        /// <param name="street">Street.</param>
        /// <param name="city">City.</param>
        /// <param name="state">State.</param>
        /// <param name="zip">Zip.</param>
        [HttpPut]
        public void UpdateNetwork([FromQuery] int networkID, [FromQuery] string networkName,
                                        [FromQuery] string desc,
                                        [FromQuery] int category,
                                        [FromQuery] int type,
                                        [FromQuery] string news,
                                        [FromQuery] string office,
                                        [FromQuery] string email,
                                        [FromQuery] string webSite,
                                        [FromQuery] string street,
                                        [FromQuery] string city,
                                        [FromQuery] string state,
                                        [FromQuery] string zip)
        {

            netMgr.UpdateNetwork(networkID, networkName, desc, category, type, news, office, email, webSite, street, city, state, zip);
        }

        /// <summary>
        /// Gets the list of networks for member.
        /// </summary>
        /// <returns>The member networks.</returns>
        /// <param name="memberID">Member identifier.</param>
        [HttpGet]
        public List<NetworkInfoModel> GetMemberNetworks([FromQuery] int memberID)
        {
            List<NetworkInfoModel> lst = netMgr.GetMemberNetworks(memberID);
            return lst;
        }

        /// <summary>
        /// Gets the network categories.
        /// </summary>
        /// <returns>The network categories.</returns>
        [HttpGet]
        public List<TbNetworkCategory> GetNetworkCategories()
        {
            List<TbNetworkCategory> lst = netMgr.GetNetworkCategories();
            return lst;
        }

        /// <summary>
        /// Gets the network category types.
        /// </summary>
        /// <returns>The network category types.</returns>
        /// <param name="categoryID">Category identifier.</param>
        [HttpGet]
        public List<TbNetworkCategoryType> GetNetworkCategoryTypes([FromQuery] int categoryID)
        {
            List<TbNetworkCategoryType> lst = netMgr.GetNetworkCategoryTypes(categoryID);
            return lst;
        }

        /// <summary>
        /// Gets the network basic info.
        /// </summary>
        /// <returns>The network basic info.</returns>
        /// <param name="networkID">Network identifier.</param>
        [HttpGet]
        public List<NetworkInfoModel> GetNetworkBasicInfo([FromQuery]int networkID)
        {
            List<NetworkInfoModel> lst = netMgr.GetNetworkBasicInfo(networkID);
            return lst;
        }

        /// <summary>
        /// Gets list networks by cat type.
        /// </summary>
        /// <returns>The networks by cat type.</returns>
        /// <param name="memberID">Member identifier.</param>
        /// <param name="category">Category.</param>
        /// <param name="subCategory">Sub category.</param>
        [HttpGet]
        public List<NetworkInfoModel> GetNetworksByCatType([FromQuery]int memberID, [FromQuery] int category, [FromQuery] int subCategory)
        {
            List<NetworkInfoModel> lst = netMgr.GetNetworksByCatType(memberID, category, subCategory);
            return lst;
        }

        /// <summary>
        /// Gets the network settings.
        /// </summary>
        /// <returns>The network settings.</returns>
        /// <param name="networkID">Network identifier.</param>
        [HttpGet]
        public List<TbNetworkSettings> GetNetworkSettings([FromQuery] int networkID)
        {
            List<TbNetworkSettings> lst = netMgr.GetNetworkSettings(networkID);
            return (lst);
        }

        /// <summary>
        /// Gets the network administrators.
        /// </summary>
        /// <returns>The network admins.</returns>
        /// <param name="networkID">Network identifier.</param>
        [HttpGet]
        public List<NetworkMemberModel> GetNetworkAdmins([FromQuery]int networkID)
        {
            List<NetworkMemberModel> lst = netMgr.GetNetworkAdmins(networkID);
            return (lst);
        }

        /// <summary>
        /// Gets the network members.
        /// </summary>
        /// <returns>The network members.</returns>
        /// <param name="networkID">Network identifier.</param>
        /// <param name="listType">List type.</param>
        [HttpGet]
        public List<NetworkMemberModel> GetNetworkMembers([FromQuery] int networkID, [FromQuery] string listType)
        {
            List<NetworkMemberModel> lst = netMgr.GetNetworkMembers(networkID, listType);
            return (lst);
        }

        /// <summary>
        /// Gets the contacts not in network.
        /// </summary>
        /// <returns>The contacts not in network.</returns>
        /// <param name="memberID">Member identifier.</param>
        /// <param name="networkID">Network identifier.</param>
        [HttpGet]
        public List<NetworkMemberModel> GetContactsNotInNetwork([FromQuery] int memberID, [FromQuery] int networkID)
        {
            List<NetworkMemberModel> lst = netMgr.GetContactsNotInNetwork(memberID, networkID);
            return (lst);
        }

        /// <summary>
        /// Adds the network members.
        /// </summary>
        /// <param name="memberID">Member identifier.</param>
        /// <param name="networkID">Network identifier.</param>
        [HttpPost]
        public void AddNetworkMembers([FromQuery] int memberID, [FromQuery] int networkID)
        {
            netMgr.AddNetworkMembers(memberID, networkID);
        }

        /// <summary>
        /// Ignores the join network.
        /// </summary>
        /// <param name="memberID">Member identifier.</param>
        /// <param name="networkID">Network identifier.</param>
        [HttpPut]
        public void IgnoreJoinNetwork([FromQuery] int memberID, [FromQuery]int networkID)
        {
                netMgr.IgnoreJoinNetwork(memberID, networkID);
        }

        /// <summary>
        /// Updates the network settings.
        /// </summary>
        /// <param name="networkID">Network identifier.</param>
        /// <param name="access">Access.</param>
        /// <param name="nonAdminCanWrite">If set to <c>true</c> non admin can write.</param>
        /// <param name="showNetworkEvents">If set to <c>true</c> show network events.</param>
        /// <param name="enableDiscussionBoard">If set to <c>true</c> enable discussion board.</param>
        /// <param name="enablePhotos">If set to <c>true</c> enable photos.</param>
        /// <param name="enableVideos">If set to <c>true</c> enable videos.</param>
        /// <param name="enableLinks">If set to <c>true</c> enable links.</param>
        /// <param name="onlyAllowAdminsToUploadPhotos">If set to <c>true</c> only allow admins to upload photos.</param>
        /// <param name="onlyAllowAdminsToUploadVideos">If set to <c>true</c> only allow admins to upload videos.</param>
        /// <param name="onlyAllowAdminsToPostLinks">If set to <c>true</c> only allow admins to post links.</param>
        [HttpPut]
        public void UpdateNetworkSettings([FromQuery] int networkID, [FromQuery] int access, [FromQuery] bool nonAdminCanWrite,
                                               [FromQuery] bool showNetworkEvents,
                                               [FromQuery] bool enableDiscussionBoard,
                                               [FromQuery] bool enablePhotos,
                                               [FromQuery] bool enableVideos,
                                               [FromQuery] bool enableLinks,
                                               [FromQuery] bool onlyAllowAdminsToUploadPhotos,
                                               [FromQuery] bool onlyAllowAdminsToUploadVideos,
                                               [FromQuery] bool onlyAllowAdminsToPostLinks)
        {
                netMgr.UpdateNetworkSettings(networkID, access, nonAdminCanWrite, showNetworkEvents, enableDiscussionBoard, enablePhotos,
                    enableVideos, enableLinks, onlyAllowAdminsToUploadPhotos, onlyAllowAdminsToUploadVideos, onlyAllowAdminsToPostLinks);
        }

        [HttpPost]
        public void InviteMemberToJoinNetwork([FromQuery] int networkID, [FromQuery] int memberID)
        {
            netMgr.InviteMemberToJoinNetwork(networkID, memberID);
        }

        /// <summary>
        /// Invites to join network using email.
        /// </summary>
        /// <returns>The email to join network.</returns>
        /// <param name="NetworkID">Network identifier.</param>
        /// <param name="email">Email.</param>
        [HttpPost]
        public int InviteEmailToJoinNetwork([FromQuery] int NetworkID, [FromQuery] string email)
        {
            int res = netMgr.InviteEmailToJoinNetwork(NetworkID, email);
            return res;
        }

        /// <summary>
        /// checks if email is a network member
        /// </summary>
        /// <returns><c>true</c>, if network member was ised, <c>false</c> otherwise.</returns>
        /// <param name="networkID">Network identifier.</param>
        /// <param name="email">Email.</param>
        [HttpGet]
        public bool IsNetworkMember([FromQuery] int networkID, [FromQuery] string email)
        {
            bool b = netMgr.IsNetworkMember(networkID, email);
            return b;
        }

        /// <summary>
        /// checks if member a network requestor to join
        /// </summary>
        /// <returns><c>true</c>, if member net work requestor was ised, <c>false</c> otherwise.</returns>
        /// <param name="networkID">Network identifier.</param>
        /// <param name="memberID">Member identifier.</param>
        [HttpGet]
        public bool IsMemberNetWorkRequestor([FromQuery] int networkID, [FromQuery] int memberID)
        {
            bool b = netMgr.IsMemberNetWorkRequestor(networkID, memberID);
            return b;
        }

        /// <summary>
        /// Gets the recent network activities.
        /// </summary>
        /// <returns>The recent network activities.</returns>
        /// <param name="networkID">Network identifier.</param>
        [HttpGet]
        public List<RecentNetworkActivitiesResult> GetRecentNetworkActivities([FromQuery] int networkID)
        {
            List<RecentNetworkActivitiesResult> lst = netMgr.GetRecentNetworkActivities(networkID).ToList();
            return lst;
        }

        /// <summary>
        /// Gets the network posts.
        /// </summary>
        /// <returns>The network posts.</returns>
        /// <param name="networkID">Network identifier.</param>
        [HttpGet]
        public List<NetworkPostsModel> GetNetworkPosts([FromQuery]int networkID)
        {
            List<NetworkPostsModel> lst = netMgr.GetNetworkPosts(networkID).ToList();
            return (lst);
        }

        /// <summary>
        /// Gets the network post responses.
        /// </summary>
        /// <returns>The network post responses.</returns>
        /// <param name="postID">Post identifier.</param>
        [HttpGet]
        public List<NetworkChildPostsModel> GetNetworkPostResponses([FromQuery] int postID)
        {
            List<NetworkChildPostsModel> lst = netMgr.GetNetworkPostResponses(postID).ToList();
            return (lst);
        }

        /// <summary>
        /// Updates the profile picture.
        /// </summary>
        /// <param name="networkID">Network identifier.</param>
        /// <param name="fileName">File name.</param>
        [HttpPut]
        public void UpdateProfilePicture([FromQuery] int networkID, [FromQuery] string fileName)
        {
            netMgr.UpdateProfilePicture(networkID, fileName);
        }

        /// <summary>
        /// Creates the network post.
        /// </summary>
        /// <param name="networkID">Network identifier.</param>
        /// <param name="memberID">Member identifier.</param>
        /// <param name="postMsg">Post message.</param>
        [HttpPost]
        public void CreateNetworkPost([FromQuery] int networkID, [FromQuery] int memberID, [FromQuery] string postMsg)
        {
            netMgr.CreateNetworkPost(networkID, memberID, postMsg);
        }

        /// <summary>
        /// Creates the post comment.
        /// </summary>
        /// <param name="networkID">Network identifier.</param>
        /// <param name="memberID">Member identifier.</param>
        /// <param name="postID">Post identifier.</param>
        /// <param name="postMsg">Post message.</param>
        [HttpPost]
        public void CreatePostComment([FromQuery] int networkID, [FromQuery] int memberID, [FromQuery] int postID, [FromQuery] string postMsg)
        {
            netMgr.CreatePostComment(networkID, memberID, postID, postMsg);
        }

        /// <summary>
        /// Creates the post comment by topic identifier.
        /// </summary>
        /// <param name="memberID">Member identifier.</param>
        /// <param name="topicID">Topic identifier.</param>
        /// <param name="postMsg">Post message.</param>
        [HttpPost]
        public void CreatePostCommentByTopicID([FromQuery] int memberID, [FromQuery] int topicID, [FromQuery] string postMsg)
        {
            netMgr.CreatePostComment(memberID, topicID, postMsg);
        }

        /// <summary>
        /// Gets the network info.
        /// </summary>
        /// <returns>The network info.</returns>
        /// <param name="networkID">Network identifier.</param>
        [HttpGet]
        public List<NetworkInfoModel> GetNetworkInfo([FromQuery]int networkID)
        {
            List<NetworkInfoModel> lst = netMgr.GetNetworkBasicInfo(networkID).ToList();
            return (lst);
        }

        /// <summary>
        /// Creates the photo.
        /// </summary>
        /// <returns>The photo.</returns>
        /// <param name="networkID">Network identifier.</param>
        /// <param name="memberID">Member identifier.</param>
        /// <param name="title">Title.</param>
        /// <param name="desc">Desc.</param>
        /// <param name="ext">Ext.</param>
        [HttpPost]
        public int CreatePhoto([FromQuery] int networkID, [FromQuery] int memberID, [FromQuery] string title, [FromQuery] string desc, [FromQuery] string ext)
        {
            int res = netMgr.CreatePhoto(networkID, memberID, title, desc, ext);
            return res;
        }

        /// <summary>
        /// Gets the network photos.
        /// </summary>
        /// <returns>The network photos.</returns>
        /// <param name="networkID">Network identifier.</param>
        [HttpGet]
        public List<NetworkPhotosModel> GetNetworkPhotos([FromQuery] int networkID)
        {
            List<NetworkPhotosModel> lst = netMgr.GetNetworkPhotos(networkID).ToList();
            return (lst);
        }

        /// <summary>
        /// Removes the photo.
        /// </summary>
        /// <param name="photoID">Photo identifier.</param>
        [HttpDelete]
        public void RemovePhoto([FromQuery] int photoID)
        {
            netMgr.RemovePhoto(photoID);
        }

        /// <summary>
        /// Updates the network photo.
        /// </summary>
        /// <param name="photoID">Photo identifier.</param>
        /// <param name="title">Title.</param>
        /// <param name="desc">Desc.</param>
        [HttpPut]
        public void UpdateNetworkPhoto([FromQuery] int photoID, [FromQuery] string title, [FromQuery] string desc)
        {
            netMgr.UpdateNetworkPhoto(photoID, title, desc);
        }

        /// <summary>
        /// Gets the network events.
        /// </summary>
        /// <returns>The network events.</returns>
        /// <param name="networkID">Network identifier.</param>
        /// <param name="memberID">Member identifier.</param>
        [HttpGet]
        public List<NetworkEventModel> GetNetworkEvents([FromQuery] int networkID, [FromQuery] int memberID)
        {
            List<NetworkEventModel> lst = netMgr.GetNetworkEvents(networkID, memberID).ToList();
            return (lst);
        }

        /// <summary>
        /// Creates the topic.
        /// </summary>
        /// <param name="networkID">Network identifier.</param>
        /// <param name="memberID">Member identifier.</param>
        /// <param name="topicName">Topic name.</param>
        /// <param name="post">Post.</param>
        [HttpGet]
        public void CreateTopic([FromQuery] int networkID, [FromQuery] int memberID, [FromQuery] string topicName, [FromQuery] string post)
        {
            netMgr.CreateTopic(networkID, memberID, topicName, post);
        }

        /// <summary>
        /// Gets the network discussion topics.
        /// </summary>
        /// <returns>The network discussion topics.</returns>
        /// <param name="networkID">Network identifier.</param>
        [HttpGet]
        public List<NetworkTopicsModel> GetNetworkDiscussionTopics([FromQuery] int networkID)
        {
            List<NetworkTopicsModel> lst = netMgr.GetNetworkDiscussionTopics(networkID).ToList();
            return (lst);
        }

        /// <summary>
        /// Gets the list of posts for a topic.
        /// </summary>
        /// <returns>The topic posts.</returns>
        /// <param name="topicID">Topic identifier.</param>
        [HttpGet]
        public List<NetworkPostsModel> GetTopicPosts([FromQuery] int topicID)
        {
            List<NetworkPostsModel> lst = netMgr.GetTopicPosts(topicID).ToList();
            return (lst);
        }

        /// <summary>
        /// Updates the network image.
        /// </summary>
        /// <param name="networkID">Network identifier.</param>
        /// <param name="filename">Filename.</param>
        [HttpPut]
        public void UpdateNetworkImage([FromQuery] int networkID, [FromQuery] string filename)
        {
            netMgr.UpdateNetworkImage(networkID, filename);
        }

        /// <summary>
        /// Gets the total network invites.
        /// </summary>
        /// <returns>The total network invites.</returns>
        /// <param name="memberID">Member identifier.</param>
        [HttpGet]
        public int? GetTotalNetworkInvites([FromQuery] int memberID)
        {
            int? res = netMgr.GetTotalNetworkInvites(memberID);
            return res;
        }

        /// <summary>
        /// Gets the member network invites.
        /// </summary>
        /// <returns>The member network invites.</returns>
        /// <param name="memberID">Member identifier.</param>
        [HttpGet]
        public List<NetworkInfoModel> GetMemberNetworkInvites([FromQuery] int memberID)
        {
            List<NetworkInfoModel> lst = netMgr.GetMemberNetworkInvites(memberID).ToList();
            return (lst);
        }

        /// <summary>
        /// Deletes the network topic.
        /// </summary>
        /// <param name="topicID">Topic identifier.</param>
        [HttpDelete]
        public void DeleteNetworkTopic([FromQuery] int topicID)
        {
            netMgr.DeleteNetworkTopic(topicID);
        }

        /// <summary>
        /// Adds the network admin.
        /// </summary>
        /// <param name="networkID">Network identifier.</param>
        /// <param name="memberID">Member identifier.</param>
        [HttpPost]
        public void AddNetworkAdmin([FromQuery] int networkID, [FromQuery] int memberID)
        {
            netMgr.AddNetworkAdmin(networkID, memberID);
        }

        /// <summary>
        /// Permanently  remove the rejected request.
        /// </summary>
        /// <param name="memberID">Member identifier.</param>
        /// <param name="networkID">Network identifier.</param>
        [HttpDelete]
        public void PermanentlyRemoveRejectedRequest([FromQuery] int memberID, [FromQuery] int networkID)
        {
            netMgr.PermanentlyRemoveRejectedRequest(memberID, networkID);
        }

        /// <summary>
        /// Deactivates the member from network.
        /// </summary>
        /// <param name="memberID">Member identifier.</param>
        /// <param name="networkID">Network identifier.</param>
        [HttpPut]
        public void DeactivateMemberFromNetwork([FromQuery] int memberID, [FromQuery] int networkID)
        {
            netMgr.DeactivateMemberFromNetwork(memberID, networkID);
        }

        /// <summary>
        /// Deletes a network invite.
        /// </summary>
        /// <param name="memberID">Member identifier.</param>
        /// <param name="networkID">Network identifier.</param>
        /// <param name="email">Email.</param>
        [HttpDelete]
        public void DeleteInvite([FromQuery] int memberID, [FromQuery] int networkID, [FromQuery] string email)
        {
            netMgr.DeleteInvite(memberID, networkID, email);
        }

        /// <summary>
        /// Gets the network topic member creator.
        /// </summary>
        /// <returns>The network topic member creator.</returns>
        /// <param name="topicID">Topic identifier.</param>
        [HttpGet]
        public int GetNetworkTopicMemberCreator([FromQuery] int topicID)
        {
            return (netMgr.GetNetworkTopicMemberCreator(topicID));
        }

        /// <summary>
        /// Searchs the TOP x network results.
        /// </summary>
        /// <returns>The TOP x network results.</returns>
        /// <param name="tryValue">Try value.</param>
        [HttpGet]
        public List<NetworkInfoModel> SearchTOPxNetworkResults([FromQuery] string tryValue)
        {
                return (netMgr.SearchTop8NetworkResults(tryValue));  
        }

        /// <summary>
        /// Gets the list of networks by try value and member.
        /// </summary>
        /// <returns>The networks by key name.</returns>
        /// <param name="memberID">Member identifier.</param>
        /// <param name="tryValue">Try value.</param>
        [HttpGet]
        public List<NetworkInfoModel> GetNetworksByKeyName([FromQuery] int memberID, [FromQuery] string tryValue)
        {
            return (netMgr.GetNetworksByKeyName(memberID, tryValue));
        }

        /// <summary>
        /// Adds the member to network request.
        /// </summary>
        /// <param name="networkID">Network identifier.</param>
        /// <param name="memberID">Member identifier.</param>
        /// <param name="status">Status.</param>
        [HttpPost]
        public void AddMemberToNetworkRequest([FromQuery] int networkID, [FromQuery] int memberID, [FromQuery] int status)
        {
            netMgr.AddMemberToNetworkRequest(networkID, memberID, status);
        }

        /// <summary>
        /// Demotes the admin of an admin.
        /// </summary>
        /// <param name="memberID">Member identifier.</param>
        /// <param name="networkID">Network identifier.</param>
        [HttpPut]
        public void DemoteAdmin([FromQuery]int memberID, [FromQuery] int networkID)
        {
            netMgr.DemoteAdmin(memberID, networkID);
        }

        /// <summary>
        /// Deletes the network invite.
        /// </summary>
        /// <param name="networkID">Network identifier.</param>
        /// <param name="memberID">Member identifier.</param>
        [HttpDelete]
        public void DeleteNetworkInvite([FromQuery] int networkID, [FromQuery] string memberID)
        {
            netMgr.DeleteNetworkInvite(memberID, networkID);
        }
    }
}
