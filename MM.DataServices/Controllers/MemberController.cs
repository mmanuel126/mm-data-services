using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MM.DataServices.Models;
using MM.DataServices.Members;
using MM.DataServices.Commons;
using Microsoft.AspNetCore.Cors;
using MM.DataServices.Security;
using System.IO;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;

namespace MM.DataServices.Controllers
{
    [Route("services/[controller]/[action]")]
    public class MemberController : ControllerBase
    {
        MemberDataManager mbrMgr;
        CommonDataManager commonMgr;
        LoggingDataManager loginMgr;

        private IHostingEnvironment _hostingEnvironment;

        public MemberController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            mbrMgr = new MemberDataManager();
            commonMgr = new CommonDataManager();
            loginMgr = new LoggingDataManager();
        }


        /// <summary>
        /// Authenticates the user. returns string with member id, emailm, and picture path seperated by ~
        /// </summary>
        /// <returns>The user.</returns>
        /// <param name="email">login user email.</param>
        /// <param name="pwd"> user password.</param>
        /// <param name="rememberMe">Remember me value used for next loging.</param>
        /// <param name="screen">which screen login came from</param>
        [HttpGet]
        public String AuthenticateUser([FromQuery] String email, [FromQuery] String pwd, [FromQuery] String rememberMe, [FromQuery] String screen)
        {
            return mbrMgr.AuthenticateUser(email, pwd, rememberMe, screen);
        }

        /// <summary>
        /// Registers the user to use app.
        /// </summary>
        /// <returns>The user to lg.</returns>
        /// <param name="fName">First name.</param>
        /// <param name="lName">Last name.</param>
        /// <param name="email">user Email.</param>
        /// <param name="pwd">user Pwd.</param>
        /// <param name="day">birth Day.</param>
        /// <param name="month">birth Month.</param>
        /// <param name="year">birth Year.</param>
        /// <param name="gender">Gender, male or female.</param>
        [HttpGet]
        public String RegisterUserToLG([FromQuery] String fName, [FromQuery] String lName, [FromQuery] String email, [FromQuery] String pwd, [FromQuery] String day, [FromQuery] String month, [FromQuery] String year, [FromQuery] String gender)
        {
            return mbrMgr.RegisterUserToLG(fName,lName,email,pwd,day,month, year,gender);
        }

        /// <summary>
        /// Validates the new registered user.
        /// </summary>
        /// <returns>The new registered user.</returns>
        /// <param name="email">Email.</param>
        /// <param name="code">Code.</param>
        [HttpGet]
        public List<ValidateNewRegisteredUserModel> ValidateNewRegisteredUser([FromQuery] string email, [FromQuery] string code)
        {
            return loginMgr.ValidateNewRegisteredUser(email, Convert.ToInt32 (code));
        }

        /// <summary>
        /// Gets the list of member contacts.
        /// </summary>
        /// <returns>The member contacts.</returns>
        /// <param name="memberID">Member identifier.</param>
        /// <param name="show">Show.</param>
        [HttpGet]
        public List<MemberContactModel> GetMemberContacts([FromQuery] int memberID, [FromQuery]String show)
        {
            List<MemberContactModel> lst = mbrMgr.GetMemberContacts(memberID, show).ToList();
            return lst;
        }

        /// <summary>
        /// Saves the posts.
        /// </summary>
        /// <returns>The posts.</returns>
        /// <param name="authorization">Authorization.</param>
        /// <param name="body">Body.</param>
        [Authorize]
        [HttpPost]
        public string SavePosts([FromHeader] string authorization, [FromBody] PostsModel body )
        {
            MemberDataManager c = new MemberDataManager();
            if (body.postID == 0)
                c.CreateMemberPost(body.memberID, body.postMsg);
            else
                c.CreatePostComment(body.memberID, body.postID, body.postMsg);
            return "success";
        }

        /// <summary>
        /// LGRs the ecent post responses.
        /// </summary>
        /// <returns>The ecent post responses.</returns>
        /// <param name="authorization">Authorization.</param>
        /// <param name="postID">Post identifier.</param>
        [Authorize]
        [HttpGet]
        public List<RecentPostChildModel> getRecentPostResponses([FromHeader] string authorization, [FromQuery] int postID)
        {
            List<RecentPostChildModel> lst = mbrMgr.GetMemberPostResponses(postID);
            return lst;
        }

        /// <summary>
        /// LGRs the ecent posts.
        /// </summary>
        /// <returns>The ecent posts.</returns>
        /// <param name="authorization">Authorization.</param>
        /// <param name="memberID">Member identifier.</param>
        [Authorize]
        [HttpGet]
        public List<MemberPostsModel> getRecentPosts([FromHeader] string authorization,  [FromHeader] int memberID)
        {
            List<MemberPostsModel> lst = mbrMgr.GetMemberPosts(memberID);
            return lst;
        }

        /// <summary>
        /// LGRs the ecent news.
        /// </summary>
        /// <returns>The ecent news.</returns>
        /// <param name="authorization">Authorization.</param>
        [Authorize]
        [HttpGet]
       
        public List<TbRecentNews> getRecentNews([FromHeader] string authorization)
        {
            return mbrMgr.LGRecentNews();
        }

        /// <summary>
        /// Gets the member general information.
        /// </summary>
        /// <returns>The member general info.</returns>
        /// <param name="memberID">Member identifier.</param>
        [HttpGet]
        public List<TbMemberProfile> GetMemberGeneralInfo([FromQuery]int memberID)
        {
            return mbrMgr.GetMemberGeneralInfo(memberID);
        }

        /// <summary>
        /// Gets the member general info v2.
        /// </summary>
        /// <returns>The member general info v2.</returns>
        /// <param name="memberID">Member identifier.</param>
        [HttpGet]
        public List<MemberProfileGenInfoModel> GetMemberGeneralInfoV2([FromQuery]int memberID)
        {
            return mbrMgr.GetMemberGeneralInfoV2 (memberID);
        }

        /// <summary>
        /// Gets list of member dates.
        /// </summary>
        /// <returns>The member dates.</returns>
        /// <param name="memberID">Member identifier.</param>
        [HttpGet]
        public List<MemberDatesModel> GetMemberDates([FromQuery]int memberID)
        {
            return mbrMgr.GetMemberDates(memberID);
        }

        /// <summary>
        /// Gets member interest description.
        /// </summary>
        /// <returns>The interest description.</returns>
        /// <param name="interestID">Interest identifier.</param>
        [HttpGet]
        public string GetInterestDescription([FromQuery] int interestID)
        {
            return mbrMgr.GetInterestDescription(interestID);
        }

        /// <summary>
        /// Gets member personal information.
        /// </summary>
        /// <returns>The member personal info.</returns>
        /// <param name="memberID">Member identifier.</param>
        [HttpGet]
        public List<TbMemberProfilePersonalInfo> GetMemberPersonalInfo([FromQuery] int memberID)
        {            
            List<TbMemberProfilePersonalInfo> lst = mbrMgr.GetMemberPersonalInfo(memberID);
            return lst;
        }

        /// <summary>
        /// Gets member contact information.
        /// </summary>
        /// <returns>The member contact info.</returns>
        /// <param name="memberID">Member identifier.</param>
        [HttpGet]
        public List<TbMemberProfileContactInfo> GetMemberContactInfo([FromQuery] int memberID)
        {
            List<TbMemberProfileContactInfo> lst = mbrMgr.GetMemberContactInfo(memberID);
            return lst;
        }

        /// <summary>
        /// Gets member education information.
        /// </summary>
        /// <returns>The member education info.</returns>
        /// <param name="memberID">Member identifier.</param>
        [HttpGet]
        public List<MemberProfileEducationModel> GetMemberEducationInfo([FromQuery] int memberID)
        {
            List<MemberProfileEducationModel> lst = mbrMgr.GetMemberEducationInfo(memberID);
            return lst;          
        }
        /// <summary>
        /// Gets the member employment info.
        /// </summary>
        /// <returns>The member employment info.</returns>
        /// <param name="memberID">Member identifier.</param>
        [HttpGet]
        public List<MemberProfileEmploymentModel> GetMemberEmploymentInfo([FromQuery] int memberID)
        {
            List<MemberProfileEmploymentModel> lst = mbrMgr.GetMemberEmploymentInfo(memberID);
            return lst;
        }

        /// <summary>
        /// Gets thd list of member's albums.
        /// </summary>
        /// <returns>The member albums.</returns>
        /// <param name="memberID">Member identifier.</param>
        [HttpGet]
        public List<MemberAlbumsModel> GetMemberAlbums([FromQuery] int memberID)
        {
            List<MemberAlbumsModel> lst = mbrMgr.GetMemberAlbums(memberID);
            return lst;
        }

        /// <summary>
        /// returns list of member photos for an album.
        /// </summary>
        /// <returns>The member album photos.</returns>
        /// <param name="albumID">Album identifier.</param>
        [HttpGet]
        public List<AlbumPhotosModel> GetMemberAlbumPhotos([FromQuery] int albumID)
        {
            List<AlbumPhotosModel> lst = mbrMgr.GetMemberAlbumPhotos(albumID);
            return lst;
        }

        /// <summary>
        /// Saves or update the member general info.
        /// </summary>
        /// <param name="memberID">Member identifier.</param>
        /// <param name="body">input data of the MemberProfileGenInfo Model.</param>
        [HttpPost]
        public void SaveMemberGeneralInfo([FromQuery] int memberID, [FromBody] MemberProfileGenInfoModel body)
        {

            bool showGender = false;
            if (body.ShowSexInProfile == "1")
                showGender = true;

            bool showDOB = false;
            if (body.ShowDOBType == "1")
                showDOB = true;

            bool partnership = false;
            if (body.LookingForPartnership == "1")
                partnership = true;

            bool employment = false;
            if (body.LookingForEmployment == "1")
                employment = true;

            bool recruitment = false;
            if (body.LookingForRecruitment == "1")
                recruitment = true;

            bool networking = false;
            if (body.LookingForNetworking == "1")
                networking = true;

            mbrMgr.SaveMemberGeneralInfo(memberID, body.FirstName, body.MiddleName, body.LastName, body.TitleDesc, body.Sector, body.Industry,
                                         int.Parse(body.InterestedInType), int.Parse(body.CurrentStatus), body.Sex, showGender, body.DOBMonth,
                                             body.DOBDay, body.DOBYear, showDOB, partnership,
                                             employment, recruitment, networking);

        }


        /// <summary>
        /// Saves or update the member personal info.
        /// </summary>
        /// <param name="memberID">Member identifier.</param>
        /// <param name="activities">Activities.</param>
        /// <param name="interests">Interests.</param>
        /// <param name="specialSkills">Special skills.</param>
        /// <param name="aboutMe">About me.</param>
        [HttpPost]
        public void SaveMemberPersonalInfo(
                     [FromQuery] int memberID,
                     [FromQuery] string activities,
                     [FromQuery] string interests,
                     [FromQuery] string specialSkills,
                     [FromQuery] string aboutMe)
        {
           
                mbrMgr.SaveMemberPersonalInfo(memberID, activities, interests, specialSkills, aboutMe);
        }

        /// <summary>
        /// Saves or update the member contact information.
        /// </summary>
        /// <param name="memberID">Member identifier.</param>
        /// <param name="body">model input data.</param>
        [HttpPost]
        public void SaveMemberContactInfo([FromQuery] int memberID, [FromBody] MemberProfileContactInfoModel body)
        {

            //bool showEmail = (body.ShowEmailToMembers == "true") ? true : false;
            //bool showHomePhone = (body.ShowHomePhone == "true") ? true : false;
            //bool showCellPhone = (body.ShowCellPhone == "true") ? true : false;
            //bool showAddress = (body.ShowAddress == "true") ? true : false;
            //bool showLinks = (body.ShowLinks == "true") ? true : false;

            mbrMgr.SaveMemberContactInfo(memberID, body.Email, body.ShowEmailToMembers, body.OtherEmail, body.IMDisplayName, int.Parse(body.IMServiceType),
                                         body.HomePhone, body.ShowHomePhone, body.CellPhone, body.ShowCellPhone, body.OtherPhone,
                                         body.Address, body.ShowAddress, body.CityTown, body.State, body.ZipCode, body.WebsiteLink, "", body.ShowLinks);

        }

        /// <summary>
        /// Saves or updates the member education info.
        /// </summary>
        /// <param name="memberID">Member identifier.</param>
        /// <param name="highSchool">High school.</param>
        /// <param name="highSchoolClassYear">High school class year.</param>
        /// <param name="college1">College1.</param>
        /// <param name="college1ClassYear">College1 class year.</param>
        /// <param name="college1Major">College1 major.</param>
        /// <param name="college1DegreeType">College1 degree type.</param>
        /// <param name="college1Societies">College1 societies.</param>
        /// <param name="college2">College2.</param>
        /// <param name="college2ClassYear">College2 class year.</param>
        /// <param name="college2Major">College2 major.</param>
        /// <param name="college2DegreeType">College2 degree type.</param>
        /// <param name="college2Societies">College2 societies.</param>
        [HttpPost]
        public void SaveMemberEducationInfo(int memberID,
                                    [FromQuery] string highSchool,
                                    [FromQuery] string highSchoolClassYear,
                                    [FromQuery] string college1,
                                    [FromQuery] string college1ClassYear,
                                    [FromQuery] string college1Major,
                                    [FromQuery] int college1DegreeType,
                                    [FromQuery] string college1Societies,
                                    [FromQuery] string college2,
                                    [FromQuery] string college2ClassYear,
                                    [FromQuery] string college2Major,
                                    [FromQuery] int college2DegreeType,
                                    [FromQuery] string college2Societies)
        {
                mbrMgr.SaveMemberEducationInfo(memberID, highSchool, highSchoolClassYear, college1, college1ClassYear, college1Major,
                                                 college1DegreeType, college1Societies, college2, college2ClassYear, college2Major, college2DegreeType, college2Societies);
        }

        /// <summary>
        /// Saves or update the member employment info.
        /// </summary>
        /// <param name="memberID">Member identifier.</param>
        /// <param name="employer">Employer.</param>
        /// <param name="emp1Position">Emp1 position.</param>
        /// <param name="emp1JobDesc">Emp1 job desc.</param>
        /// <param name="emp1City">Emp1 city.</param>
        /// <param name="emp1State">Emp1 state.</param>
        /// <param name="emp1StartMonth">Emp1 start month.</param>
        /// <param name="emp1StartYear">Emp1 start year.</param>
        /// <param name="emp1EndMonth">Emp1 end month.</param>
        /// <param name="emp1EndYear">Emp1 end year.</param>
        /// <param name="employer2">Employer2.</param>
        /// <param name="emp2Position">Emp2 position.</param>
        /// <param name="emp2JobDesc">Emp2 job desc.</param>
        /// <param name="emp2City">Emp2 city.</param>
        /// <param name="emp2State">Emp2 state.</param>
        /// <param name="emp2StartMonth">Emp2 start month.</param>
        /// <param name="emp2StartYear">Emp2 start year.</param>
        /// <param name="emp2EndMonth">Emp2 end month.</param>
        /// <param name="emp2EndYear">Emp2 end year.</param>
        /// <param name="employer3">Employer3.</param>
        /// <param name="emp3Position">Emp3 position.</param>
        /// <param name="emp3JobDesc">Emp3 job desc.</param>
        /// <param name="emp3City">Emp3 city.</param>
        /// <param name="emp3State">Emp3 state.</param>
        /// <param name="emp3StartMonth">Emp3 start month.</param>
        /// <param name="emp3StartYear">Emp3 start year.</param>
        /// <param name="emp3EndMonth">Emp3 end month.</param>
        /// <param name="emp3EndYear">Emp3 end year.</param>
        [HttpPost]
        public void SaveMemberEmploymentInfo(int memberID,
                              [FromQuery] string employer,
                              [FromQuery] string emp1Position,
                              [FromQuery] string emp1JobDesc,
                              [FromQuery] string emp1City,
                              [FromQuery] string emp1State,
                              [FromQuery] string emp1StartMonth,
                              [FromQuery] string emp1StartYear,
                              [FromQuery] string emp1EndMonth,
                              [FromQuery] string emp1EndYear,

                              [FromQuery] string employer2,
                              [FromQuery] string emp2Position,
                              [FromQuery] string emp2JobDesc,
                              [FromQuery] string emp2City,
                              [FromQuery] string emp2State,
                              [FromQuery] string emp2StartMonth,
                              [FromQuery] string emp2StartYear,
                              [FromQuery] string emp2EndMonth,
                              [FromQuery] string emp2EndYear,

                              [FromQuery] string employer3,
                              [FromQuery] string emp3Position,
                              [FromQuery] string emp3JobDesc,
                              [FromQuery] string emp3City,
                              [FromQuery] string emp3State,
                              [FromQuery] string emp3StartMonth,
                              [FromQuery] string emp3StartYear,
                              [FromQuery] string emp3EndMonth,
                              [FromQuery] string emp3EndYear)
        {
                mbrMgr.SaveMemberEmploymentInfo(memberID, employer, emp1Position, emp1JobDesc, emp1City, emp1State, emp1StartMonth, emp1StartYear, emp1EndMonth, emp1EndYear,
                                                    employer2, emp2Position, emp2JobDesc, emp2City, emp2State, emp2StartMonth, emp2StartYear, emp2EndMonth, emp2EndYear,
                                                    employer3, emp3Position, emp3JobDesc, emp3City, emp3State, emp3StartMonth, emp3StartYear, emp3EndMonth, emp3EndYear);
        }


        /// <summary>
        /// Sends the friend request.
        /// </summary>
        /// <param name="memberID">Member identifier.</param>
        /// <param name="email">Email.</param>
        [HttpPost]
        public void SendFriendRequest([FromQuery] int memberID, [FromQuery] string email)
        {
            mbrMgr.SendFriendRequest(memberID, email);
        }

        /// <summary>
        /// checks if contact request was sent to member id.
        /// </summary>
        /// <returns><c>true</c>, if contact request sent was ised, <c>false</c> otherwise.</returns>
        /// <param name="memberID">Member identifier.</param>
        /// <param name="toMemberiD">To memberi d.</param>
        [HttpGet]
        public bool IsContactRequestSent([FromQuery] int memberID, [FromQuery] int toMemberiD)
        {
            bool b = mbrMgr.isContactRequestSent(memberID, toMemberiD);
            return b;
        }

        /// <summary>
        /// checks if member exists for an email".
        /// </summary>
        /// <returns><c>true</c>, if member was ised, <c>false</c> otherwise.</returns>
        /// <param name="email">Email.</param>
        [HttpGet]
        public bool IsMember([FromQuery] string email)
        {
            bool b = mbrMgr.IsMember(email);
            return b;
        }

        /// <summary>
        /// checks if member is a contact by contact's email.
        /// </summary>
        /// <returns><c>true</c>, if friend by email was ised, <c>false</c> otherwise.</returns>
        /// <param name="memberID">Member identifier.</param>
        /// <param name="email">Email.</param>
        [HttpGet]
        public bool IsFriendByEmail([FromQuery] int memberID, [FromQuery] string email)
        {
            bool b = mbrMgr.IsFriend(memberID, email);
            return b;
        }

        /// <summary>
        /// checks if member is a contact by contact id
        /// </summary>
        /// <returns><c>true</c>, if friend by contact identifier was ised, <c>false</c> otherwise.</returns>
        /// <param name="memberID">Member identifier.</param>
        /// <param name="contactID">Contact identifier.</param>
        [HttpGet]
        public bool IsFriendByContactID([FromQuery] int memberID, [FromQuery] int contactID)
        {
                bool b = mbrMgr.IsFriend(memberID, contactID);
                return b;
        }

        /// <summary>
        /// Saves the member basic profile info.
        /// </summary>
        /// <param name="email">Email.</param>
        /// <param name="highSchool">High school.</param>
        /// <param name="highSchoolYear">High school year.</param>
        /// <param name="college">College.</param>
        /// <param name="collegeYear">College year.</param>
        /// <param name="company">Company.</param>
        [HttpPost]
        public void SaveBasicProfileInfo(string email,
                                    [FromQuery] string highSchool,
                                    [FromQuery] string highSchoolYear,
                                    [FromQuery] string college,
                                    [FromQuery] string collegeYear,
                                    [FromQuery] string company)
        { 
                mbrMgr.SaveBasicProfileInfo(email, highSchool, highSchoolYear, college, collegeYear, company);
        }

        /// <summary>
        /// Gets the member info by email.
        /// </summary>
        /// <returns>The member info by email.</returns>
        /// <param name="email">Email.</param>
        [HttpGet]
        public List<MemberInfoByEmailModel> GetMemberInfoByEmail([FromQuery] string email)
        {
                List<MemberInfoByEmailModel> lst = mbrMgr.GetMemberInfoByEmail(email);
                return lst;
        }

        /// <summary>
        /// Gets the recent activities.
        /// </summary>
        /// <returns>The recent activities.</returns>
        /// <param name="memberID">Member identifier.</param>
        [HttpGet]
        public List<RecentActivitiesModel> GetRecentActivities([FromQuery] int memberID)
        {
                List<RecentActivitiesModel> lst = mbrMgr.GetRecentActivities(memberID);
                return lst;
        }

        /// <summary>
        /// Gets the member posts.
        /// </summary>
        /// <returns>The member posts.</returns>
        /// <param name="memberID">Member identifier.</param>
        [Authorize]
        [HttpGet]
        public List<MemberPostsModel> GetMemberPosts([FromQuery] int memberID)
        {
            List<MemberPostsModel> lst = mbrMgr.GetMemberPosts(memberID);
            return lst;
        }

        /// <summary>
        /// Gets the member post responses.
        /// </summary>
        /// <returns>The member post responses.</returns>
        /// <param name="postID">Post identifier.</param>
        [Authorize]
        [HttpGet]
        public List<RecentPostChildModel> GetMemberPostResponses([FromQuery] int postID)
        {           
                List<RecentPostChildModel> lst = mbrMgr.GetMemberPostResponses(postID);
                return lst;
        }

     
        //[HttpGet]
        //public void UpdateProfilePicture([FromQuery] int memberID, [FromQuery] string fileName)
        //{
        //        mbrMgr.UpdateProfilePicture(memberID, fileName);
        //}

        /// <summary>
        /// Creates the member post.
        /// </summary>
        /// <param name="memberID">Member identifier.</param>
        /// <param name="postMsg">Post message.</param>
        [HttpPost]
        public void CreateMemberPost([FromQuery] int memberID, [FromQuery] string postMsg)
        {
                mbrMgr.CreateMemberPost(memberID, postMsg);
        }

        /// <summary>
        /// Creates the post comment.
        /// </summary>
        /// <param name="memberID">Member identifier.</param>
        /// <param name="postID">Post identifier.</param>
        /// <param name="postMsg">Post message.</param>
        [HttpGet]
        public void CreatePostComment([FromQuery] int memberID, [FromQuery] int postID, [FromQuery] string postMsg)
        {
            mbrMgr.CreatePostComment(memberID, postID, postMsg);
        }

        /// <summary>
        /// Gets all photos for album.
        /// </summary>
        /// <returns>The album photos.</returns>
        /// <param name="albumID">Album identifier.</param>
        [HttpGet]
        public List<AlbumPhotosModel> GetAlbumPhotos([FromQuery] int albumID)
        {
            List<AlbumPhotosModel> lst = mbrMgr.GetAlbumPhotos(albumID);
            return lst;
        }

        /// <summary>
        /// Creates the album.
        /// </summary>
        /// <param name="memberID">Member identifier.</param>
        /// <param name="albumName">Album name.</param>
        /// <param name="desc">Desc.</param>
        /// <param name="privacy">Privacy.</param>
        [HttpPost]
        public void CreateAlbum([FromQuery] int memberID, [FromQuery] string albumName, [FromQuery] string desc, [FromQuery] int privacy)
        {
            mbrMgr.CreateAlbum(memberID, albumName, desc, privacy);
        }

        /// <summary>
        /// Gets the album info.
        /// </summary>
        /// <returns>The abum info.</returns>
        /// <param name="albumID">Album identifier.</param>
        [HttpGet]
        public List<TbAlbums> GetAbumInfo([FromQuery] int albumID)
        {
            List<TbAlbums> lst = mbrMgr.GetAbumInfo(albumID);
            return lst;
        }

        /// <summary>
        /// Updates the album.
        /// </summary>
        /// <param name="albumID">Album identifier.</param>
        /// <param name="memberID">Member identifier.</param>
        /// <param name="albumName">Album name.</param>
        /// <param name="desc">Desc.</param>
        /// <param name="privacy">Privacy.</param>
        [HttpGet]
        public void UpdateAlbum([FromQuery] int albumID, [FromQuery] int memberID, [FromQuery] string albumName, [FromQuery] string desc, [FromQuery] int privacy)
        {
                mbrMgr.UpdateAlbum(albumID, memberID, albumName, desc, privacy);
        }

        /// <summary>
        /// Creates the album photo.
        /// </summary>
        /// <returns>The album photo.</returns>
        /// <param name="albumID">Album identifier.</param>
        /// <param name="ext">Ext.</param>
        [HttpPost]
        public int CreateAlbumPhoto([FromQuery] int albumID, [FromQuery] string ext)
        {
                int result = mbrMgr.CreateAlbumPhoto(albumID, ext);
                return result;
        }

        /// <summary>
        /// Removes the album identifier.
        /// </summary>
        /// <param name="albumID">Album identifier.</param>
        [HttpDelete]
        public void RemoveAlbumID([FromQuery] int albumID)
        {
            mbrMgr.RemoveAlbumID(albumID);
        }

        /// <summary>
        /// Removes the photo identifier.
        /// </summary>
        /// <param name="photoID">Photo identifier.</param>
        [HttpGet]
        public void RemovePhotoID([FromQuery] int photoID)
        {
            mbrMgr.RemovePhotoID(photoID);
        }

        /// <summary>
        /// Updates the photo title, etc..
        /// </summary>
        /// <param name="photoID">Photo identifier.</param>
        /// <param name="title">Title.</param>
        /// <param name="photoDesc">Photo desc.</param>
        [HttpPut]
        public void UpdatePhoto([FromQuery] int photoID, [FromQuery] string title, [FromQuery] string photoDesc)
        {
                mbrMgr.UpdatePhoto(photoID, title, photoDesc);
        }

        /// <summary>
        /// Gets the total albums.
        /// </summary>
        /// <returns>The total albums.</returns>
        /// <param name="memberID">Member identifier.</param>
        [HttpGet]
        public int GetTotalAlbums([FromQuery] int memberID)
        {
                return mbrMgr.GetTotalAlbums(memberID);
        }

        /// <summary>
        /// Gets the member work experience.
        /// </summary>
        /// <returns>The member work experience.</returns>
        /// <param name="memberID">Member identifier.</param>
        [HttpGet]
        public List<TbMemberProfileEmploymentInfoV2> GetMemberWorkExperience([FromQuery] int memberID)
        {     
                return mbrMgr.GetMemberWorkExperience(memberID);
        }

        /// <summary>
        /// Gets the member interests.
        /// </summary>
        /// <returns>The member interests.</returns>
        [HttpGet]
        public List<TbInterests> GetMemberInterests()
        { 
                return (mbrMgr.GetMemberInterests());
        }

        /// <summary>
        /// Adds the member school to db.
        /// </summary>
        /// <param name="memberID">Member identifier.</param>
        /// <param name="body">Body.</param>
        [HttpPost]
        public void AddMemberSchool([FromQuery] int memberID, [FromBody] MemberProfileEducationModel body)
        {      
                mbrMgr.AddMemberSchool(memberID, int.Parse(body.schoolID), int.Parse(body.schoolType), body.schoolName, body.yearClass, body.major, int.Parse(body.degree),body.Societies);
        }

        /// <summary>
        /// Updates the member school.
        /// </summary>
        /// <param name="memberID">Member identifier.</param>
        /// <param name="body">Body.</param>
        [HttpPut]
        public void UpdateMemberSchool([FromQuery] int memberID, [FromBody] MemberProfileEducationModel body)
        {      
            mbrMgr.UpdateMemberSchool(memberID, int.Parse ( body.schoolID), int.Parse (body.schoolType), body.yearClass, body.major, int.Parse(body.degree), body.Societies);
        }

        /// <summary>
        /// Removes the member school.
        /// </summary>
        /// <param name="memberID">Member identifier.</param>
        /// <param name="instID">Inst identifier.</param>
        /// <param name="instType">Inst type.</param>
        [HttpDelete]
        public void RemoveMemberSchool([FromQuery] int memberID, [FromQuery] int instID, [FromQuery] int instType)
        {
                mbrMgr.RemoveMemberSchool(memberID, instID, instType);
        }

        /// <summary>
        /// Add member work experience.
        /// </summary>
        /// <param name="memberID">Member identifier.</param>
        /// <param name="body">Body.</param>
        [HttpPost]
        public void AddWorkExperience([FromQuery] int memberID, [FromBody] MemberProfileEmploymentModel body)
        {
            mbrMgr.AddWorkExperience(memberID, int.Parse (body.companyID), body.companyName, body.title, body.JobDesc, body.City, body.State, body.StartMonth, body.StartYear, body.EndMonth,body.EndYear);
        }

        /// <summary>
        /// Updates the member work experience.
        /// </summary>
        /// <param name="memberId">Member identifier.</param>
        /// <param name="body">Body.</param>
        [HttpPut]
        public void UpdateMemberWorkExperience([FromQuery] int memberId,  [FromBody] MemberProfileEmploymentModel body)
        {
            mbrMgr.UpdateMemberWorkExperience(int.Parse (body.EmpInfoID), memberId, int.Parse (body.companyID) , body.title, body.JobDesc, body.City, body.State, body.StartMonth, body.StartYear, body.EndMonth, body.EndYear);
        }

        /// <summary>
        /// Removes the member work experience.
        /// </summary>
        /// <param name="empInfoID">Emp info identifier.</param>
        /// <param name="memberID">Member identifier.</param>
        /// <param name="compID">Comp identifier.</param>
        [HttpDelete]
        public void RemoveMemberWorkExperience([FromQuery] int empInfoID, [FromQuery] int memberID, [FromQuery] int compID)
        {
                mbrMgr.RemoveMemberWorkExperience(empInfoID, memberID, compID);
        }

        /// <summary>
        /// Updates the resume settings.
        /// </summary>
        /// <param name="memberID">Member identifier.</param>
        /// <param name="showResume">If set to <c>true</c> show resume.</param>
        /// <param name="ShowSpecialSkills">If set to <c>true</c> show special skills.</param>
        /// <param name="ShowAbout">If set to <c>true</c> show about.</param>
        /// <param name="ShowInterests">If set to <c>true</c> show interests.</param>
        /// <param name="ShowActivities">If set to <c>true</c> show activities.</param>
        [HttpPut]
        public void UpdateResumeSettings([FromQuery] int memberID, [FromQuery] bool showResume, [FromQuery] bool ShowSpecialSkills,
            [FromQuery] bool ShowAbout, [FromQuery] bool ShowInterests, [FromQuery] bool ShowActivities)
        {
                mbrMgr.UpdateResumeSettings(memberID, showResume, ShowSpecialSkills, ShowAbout, ShowInterests, ShowActivities);
        }

        /// <summary>
        /// Gets the resume settings.
        /// </summary>
        /// <returns>The resume settings.</returns>
        /// <param name="memberID">Member identifier.</param>
        [HttpGet]
        public List<TbResumeSettings> GetResumeSettings([FromQuery] int memberID)
        {
                return mbrMgr.GetResumeSettings(memberID);
        }

        /// <summary>
        /// checks to see if the member is active.
        /// </summary>
        /// <returns><c>true</c>, if member active was ised, <c>false</c> otherwise.</returns>
        /// <param name="memberID">Member identifier.</param>
        [HttpGet]
        public bool IsMemberActive([FromQuery] int memberID)
        {
                return mbrMgr.IsMemberActive(memberID);
        }

        /// <summary>
        /// Gets the member email.
        /// </summary>
        /// <returns>The member email.</returns>
        /// <param name="memberID">Member identifier.</param>
        [HttpGet]
        public List<TbMembers> GetMemberEmail([FromQuery] int memberID)
        {         
                return (mbrMgr.GetMemberEmail(memberID));
        }

        /// <summary>
        /// Adds the member acitivity.
        /// </summary>
        /// <param name="memberID">Member identifier.</param>
        /// <param name="activity">Activity.</param>
        [HttpPost]
        public void AddMemberAcitivity([FromQuery] int memberID, [FromQuery] string activity)
        {
                mbrMgr.AddMemberAcitivity(memberID, activity);
        }

        /// <summary>
        /// Gets the member photo count.
        /// </summary>
        /// <returns>The member photo count.</returns>
        /// <param name="memberID">Member identifier.</param>
        [HttpGet]
        public int GetMemberPhotoCount([FromQuery] int memberID)
        {      
                return mbrMgr.GetMemberPhotoCount(memberID);
        }

        /// <summary>
        /// Gets the member profile photo count.
        /// </summary>
        /// <returns>The member profile photo count.</returns>
        /// <param name="memberID">Member identifier.</param>
        [HttpGet]
        public int GetMemberProfilePhotoCount([FromQuery] int memberID)
        {
                return mbrMgr.GetMemberProfilePictureCount(memberID);
        }

        /// <summary>
        /// Gets the registered members.
        /// </summary>
        /// <returns>The registered members.</returns>
        /// <param name="status">Status.</param>
        [HttpGet]
        public List<RegisteredMembersModel> GetRegisteredMembers([FromQuery] int status)
        {       
                return mbrMgr.GetRegisteredMembers(status);
        }

        /// <summary>
        /// Sends the advertisement info.
        /// </summary>
        /// <returns>The advertisement info.</returns>
        /// <param name="firstName">First name.</param>
        /// <param name="lastName">Last name.</param>
        /// <param name="company">Company.</param>
        /// <param name="email">Email.</param>
        /// <param name="phone">Phone.</param>
        /// <param name="country">Country.</param>
        /// <param name="title">Title.</param>
        [HttpPost]
        public string SendAdvertisementInfo ([FromQuery] string firstName,
                                         [FromQuery] string lastName,
                                         [FromQuery] string company,
                                         [FromQuery] string email,
                                         [FromQuery] string phone,
                                         [FromQuery] string country,
                                         [FromQuery] string title)
        {
            string staffContactEmail = "marc_manuel@hotmail.com";
            string noReplyEmail = "staff@linkedglobe.com";
            string issue = company + " wants to do business with LG as far as advertisement.";
            string txtDesc = firstName + " " + lastName + " from company " + company + " wants has sent you the following information with business interests: <br/>";
            txtDesc = txtDesc + " - Phone: " + phone + "<br/> - Email: " + email + "<br/> - Country: " + country + "<br/> - Title: " + title;
            string strHTML = HTMLContactUsBodyText("LG Administrator", email, "LG Advertisement Interest", issue, "");

           commonMgr.SendGenEmailToUser(firstName, noReplyEmail, staffContactEmail, "", "", "LG Advertisement Interest" + " (" + issue + ")", strHTML);

            return  "success";
        }

        /// <summary>
        /// Resets the password.
        /// </summary>
        /// <returns>The password.</returns>
        /// <param name="email">Email.</param>
        [HttpPut]
        public string ResetPassword([FromQuery] string email)
        {
            LoggingDataManager s = new LoggingDataManager();
            List<CodeAndNameForgotPwdModel> lst = s.GetCodeAndNameForgotPwd(email);
            if (lst.Count != 0)
            {
                CodeAndNameForgotPwdModel ds = lst[0];
                string code = ds.codeID.ToString();
                string firstName = ds.firstName.ToString();
                SendEmail(email, code, firstName);
                return "success";
            }
            else {
                return "fail";
            }
        }

        private void SendEmail (string email, string code, string firstName)
        {
            string fromEmail = "Staff@LinkedGlobe.com";
            string toEmail = email;
            string subject = "LinkedGlobe Password Reset Confirmation";
            string body = HTMLBodyText(email, firstName, code);
            commonMgr.SendMail(firstName, fromEmail, toEmail, subject, body, true);
        }

        private static string HTMLBodyText(string email, string name, string code)
        {
            string str = "";

            str = str + "<table width='100%' style='text-align: center;'>";
            str = str + "<tr>";
            str = str + "<td style='font-weight: bold; font-size: 12px; height: 25px; text-align: left; background-color: #4a6792;";
            str = str + "vertical-align: middle; color: White;'>";
            str = str + "&nbsp;LinkedGlobe";
            str = str + "</td>";
            str = str + "</tr>";
            str = str + "<tr><td>&nbsp;</td></tr>";
            str = str + "<tr>";
            str = str + "<td style='font-size: 12px; text-align: left; width: 100%; font-family: Trebuchet MS,Trebuchet,Verdana,Helvetica,Arial,sans-seri'>";
            str = str + "<p>Hi " + name + ",<p/>";
            str = str + "</td>";
            str = str + "</tr>";
            str = str + "<tr>";
            str = str + "<td style='font-size: 12px; text-align: left; width: 100%; font-family: Trebuchet MS,Trebuchet,Verdana,Helvetica,Arial,sans-seri'>";
            str = str + "<p>You recently requested a new password. <br/>";
            str = str + "<p />";
            str = str + "<p>Here is your reset code, which you can enter on the password reset page:<br/><b>";
            str = str + code + "</b><p />";
            str = str + "<p>You can also reset your password by following the link below:<br/>";
            str = str + "<a href ='http://marcman.xyz/reset?email=" + email + "&c=" + code + "'>" + "http://linkedglobe.com/reset?email=" + email + "&c=" + code + "</a><p />";
            str = str + "<p />";
            str = str + "<p>If you did not request to reset your password, please disregard this message.<br>";
            //str = str + "if you have any questions, go to <a href='http://www.linkedglobe.com?page=40'>http://www.linkedglobe.com/help.aspx?page=40</a>.";
            str = str + "<p/>";
            str = str + "Thanks.<br />";
            str = str + "The LinkedGlobe Staff<br />";
            str = str + "</p>";
            str = str + "<p></p><p>";
            str = str + "</td>";
            str = str + "</tr>";
            str = str + "</table>";

            return str;
        }

        /// <summary>
        /// Is the reset code expired, yes or no.
        /// </summary>
        /// <returns>The reset code expired.</returns>
        /// <param name="code">Code.</param>
        [HttpGet]
        public string IsResetCodeExpired([FromQuery] string code)
        {
            string strCode = code.Trim();
            LoggingDataManager s = new LoggingDataManager();
            List<TbForgotPwdCodes> lst =s.CheckCodeExpired(Convert.ToInt32(strCode));
            if (lst.Count == 0)
            {
                return "yes";
            }
            else
            {
                return "no";
            }
        }


        /// <summary>
        /// Changes the password.
        /// </summary>
        /// <returns>The password.</returns>
        /// <param name="pwd">Pwd.</param>
        /// <param name="email">Email.</param>
        /// <param name="code">Code.</param>
        [HttpGet] 
        public string ChangePassword([FromQuery] string pwd,
                                       [FromQuery] string email,
                                       [FromQuery] string code )
        {
            string mykey = "r0b1nr0y";
            pwd = EncryptStrings.Encrypt(pwd, mykey);

            LoggingDataManager s = new LoggingDataManager();
            if (code != "")
            {
                s.SetCodeToExpire(Convert.ToInt32(code));
            }
            s.ChangePassword(email, pwd);

            var memberList = s.ValidateUser(email, pwd);
            if (memberList.Count != 0)
            {
                return memberList[0].memberID.ToString() + ":" + memberList[0].email.ToString();
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// Uploads the profile photo.
        /// </summary>
        /// <returns>The profile photo.</returns>
        /// <param name="memberId">Member identifier.</param>
        [HttpPost]
        public string UploadProfilePhoto([FromQuery] string memberId)
        {
            var file = Request.Form.Files[0];
            var ext = file.FileName.Split(".")[1];

            string folderName = "images/members/"; 
            string webRootPath = _hostingEnvironment.WebRootPath;
            string newPath = Path.Combine(webRootPath, folderName);
            if (!Directory.Exists(newPath))
            {
               Directory.CreateDirectory(newPath);
            }
         
            if (file.Length > 0)
            {
                string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                fileName = memberId + "." + ext;
                string fullPath = Path.Combine(newPath, fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }

            return "success";
        }

        /// <summary>
        /// Updates the profile picture.
        /// </summary>
        /// <param name="memberId">Member identifier.</param>
        /// <param name="fileName">File name.</param>
        [HttpPut]
        public void UpdateProfilePicture([FromQuery] string memberId, [FromQuery] string fileName)
        {
            mbrMgr.UpdateProfilePicture(Convert.ToInt32(memberId), fileName);
        }

        private string HTMLContactUsBodyText(string name, string strUserEmail, string subject, string issueType, string desc)
        {
            string str = "";

            str = str + "<table width='100%' style='text-align: center;'>";
            str = str + "<tr>";
            str = str + "<td style='font-weight: bold; font-size: 12px; height: 25px; text-align: left; background-color: #4a6792;";
            str = str + "vertical-align: middle; color: White;'>";
            str = str + "&nbsp;LinkedGlobe";
            str = str + "</td>";
            str = str + "</tr>";
            str = str + "<tr><td>&nbsp;</td></tr>";
            str = str + "<tr>";
            str = str + "<td style='font-size: 12px; text-align: left; width: 100%; font-family: Trebuchet MS,Trebuchet,Verdana,Helvetica,Arial,sans-seri'>";
            str = str + "<p>Hi " + name + ",<p/>";
            str = str + "</td>";
            str = str + "</tr>";
            str = str + "<tr>";
            str = str + "<td style='font-size: 12px; text-align: left; width: 100%; font-family: Trebuchet MS,Trebuchet,Verdana,Helvetica,Arial,sans-seri'>";
            str = str + "<p>On behalf of LinkedGlobe user " + strUserEmail + ", the following message from ContactUs page was sent:" + "<br/>";
            str = str + "<p />";
            str = str + "<p><b>Email Address:</b> " + strUserEmail + " <br/>";
            str = str + "<b>Subject:</b> " + subject + " <br/>";
            str = str + "<b>Issue type:</b> " + issueType + " <br/>";
            str = str + "<b>Description:</b> " + desc + " <br/>";

            str = str + "<p/>";
            str = str + "Thanks.<br />";
            str = str + "The LinkedGlobe Staff<br />";
            str = str + "</p>";
            str = str + "<p></p><p>";
            str = str + "</td>";
            str = str + "</tr>";
            str = str + "</table>";

            return str;
        }


      


    }

    public class PostsModel
    {
       public int memberID { get; set; }
       public  int postID { get; set; }
       public  string postMsg { get; set; }
    }
}
