using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using MM.DataServices.Models;
using Microsoft.EntityFrameworkCore;
using MM.DataServices.Security;
using MM.DataServices.Contacts;
using MM.DataServices.Commons;
using MM.DataServices.Controllers;

namespace MM.DataServices.Members
{
    /// <summary>
    /// Describes the functionalities for accessing data for members
    /// </summary>
    public class MemberDataManager
    {
        #region private declerations ....

        private int _UserID = 0;
        private string _FirstName = "";
        private string _LastName = "";
        private string _Email = "";
        private string _Password = "";

        #endregion

        #region class properties...

        public int MemberID { get { return _UserID; } set { _UserID = value; } }
        public string FirstName { get { return _FirstName; } set { _FirstName = value; } }
        public string LastName { get { return _LastName; } set { _LastName = value; } }
        public string Email { get { return _Email; } set { _Email = value; } }
        public string Password { get { return _Password; } set { _Password = value; } }

        #endregion

        #region methods...

        CommonDataManager commonMgr;

        public MemberDataManager()
        {
            commonMgr = new CommonDataManager();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="pwd"></param>
        /// <param name="rememberMe"></param>
        /// <param name="screen"></param>
        /// <returns></returns>
        public String AuthenticateUser(String email, String pwd, String rememberMe, String screen)
        {
            //HttpCookie c;
            string strEmail = email;

            string key = "r0b1nr0y";
            string strPwd = EncryptStrings.Encrypt(pwd.Trim(), key);

            LoggingDataManager l = new LoggingDataManager();
            List<UserModel> memberList = l.ValidateUser(strEmail, strPwd);
            if (memberList.Count != 0)
                return memberList[0].memberID.ToString() + "~" + memberList[0].email.ToString() + "~" + memberList[0].picturepath;
            else
                return "";
        }


        public String RegisterUserToLG(String fName, String lName, String email, String pwd, String day, String month, String year, String gender)
        {
            LoggingDataManager l = new LoggingDataManager();

            List<TbMembers> lst = l.CheckEmailExists(email);
            if (lst.Count != 0)
            {
                return "ExistingEmail";
            }
            else
            {
                //.EncryptStrings en = new LG.CommonWCF.EncryptStrings();
                string key = "r0b1nr0y";
                string strPwd = EncryptStrings.Encrypt(pwd.Trim(), key);
                int code = l.CreateNewUser(fName, lName, email, strPwd, gender, month, day, year);
                SendEmail(email, code.ToString (), fName, lName);
                return "NewEmail";
            }
        }

        public UserModel FindByUniqueEmail(string email)
        {
            LoggingDataManager ld = new LoggingDataManager();
            var lst = ld.FindByUniqueEmail(email);
            return lst[0];
        }

        private void SendEmail(string email, string code, string firstName, string lastName)
        {
            string fromEmail = "Staff@LinkedGlobe.com";
            string toEmail = email;
            string fullName = firstName.Trim() + " " + lastName.Trim();

            string subject = "LinkedGlobe Account Confirmation‏";
            string body = HTMLEmailBodyText(email, fullName, code, firstName);
            commonMgr.SendMail("", fromEmail, toEmail, subject, body, true);
        }

        private string HTMLEmailBodyText(string email, string name, string code, string firstName)
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
            str = str + "<p>You recently registered for LinkedGlobe. To complete your registration, follow this link:<br/>";
            str = str + "<p />";
            str = str + "<p><a href ='http://www.marcman.xyz/complete-registration?code=" + code + "&email=" + email + "&fname=" + firstName + "'>http://www.marcman.com/complete-registration?code=1&email=" + email + "</a></p>";
            str = str + "<p/>";
            str = str + "<p>LinkedGlobe is an exciting new social networking site that helps you communicate and stay connected with all your contacts. Once you become ";
            str = str + "a member, you'll be able to share photos, plan events, post advertisements, and so much more.</p>";
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



        public List<MemberContactModel> GetMemberContacts(int memberID, String show)
        {
            ContactDataManager c = new ContactDataManager();
            List<MemberContactModel> lst = c.GetMemberContacts(memberID, show).ToList();
            return lst;
        }

        public string SavePosts(int memberID, int postID, String postMsg)
        {
            MemberDataManager c = new MemberDataManager();
            if (postID == 0)
                c.CreateMemberPost(memberID, postMsg);
            else
                c.CreatePostComment(memberID, postID, postMsg);
            return "success";
        }

        public List<RecentPostChildModel> LGRecentPostResponses(int postID)
        {
            MemberDataManager mbrMgr = new MemberDataManager();
            List<RecentPostChildModel> lst = mbrMgr.GetMemberPostResponses(postID);
            return lst;
        }

        public List<MemberPostsModel> LGRecentPosts(int memberID)
        {
            MemberDataManager mbrMgr = new MemberDataManager();
            List<MemberPostsModel> lst = mbrMgr.GetMemberPosts(memberID);
            return lst;
        }

        public List<TbRecentNews> LGRecentNews()
        {
            CommonDataManager c = new CommonDataManager();
            List<TbRecentNews> lst = c.GetRecentNews();


            //object json = JsonConvert.SerializeObject(lst.Select(m =>
            //      new
            //      {                     
            //          HeaderText = m.HeaderText,
            //          ID = m.ID,
            //          ImageUrl = m.ImageUrl,
            //          Name = m.Name,
            //          NavigateURL = m.NavigateURL,
            //          PostingDate =  m.PostingDate.ToString(),
            //          TextField = m.TextField                     
            //      }
            //  ));
            //var l = (lst.Select(m =>
            //      new
            //      {
            //          HeaderText = m.HeaderText,
            //          ID = m.Id,
            //          ImageUrl = m.ImageUrl,
            //          Name = m.Name,
            //          NavigateURL = m.NavigateUrl,
            //          PostingDate = m.PostingDate.ToString(),
            //          TextField = m.TextField
            //      }
            //  ));
            return lst;
        }

        /// <summary>
        /// Get member dates
        /// </summary>
        /// <param name="memberID"></param>
        /// <returns></returns>
        public List<MemberDatesModel> GetMemberDates(int memberID)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {
                List<MemberDatesModel> lst = (from m in context.TbMemberProfile
                                              where m.MemberId == memberID

                                              select new MemberDatesModel()
                                              {
                                                  JoinedDate = m.JoinedDate.ToString(),
                                                  picturePath = string.IsNullOrEmpty(m.PicturePath) ? "default.png" : m.PicturePath,
                                                  memberName = m.FirstName + " " + m.LastName,
                                                  currentCity = m.CurrentCity,
                                                  birthDate = m.Dobmonth + "/" + m.Dobday + "/" + m.Dobyear,
                                              }
                         ).ToList();
                return lst;
            }
        }


        /// <summary>
        /// Get member general information
        /// </summary>
        /// <param name="memberID"></param>
        /// <returns></returns>
        public List<MemberProfileGenInfoModel> GetMemberGeneralInfoV2(int memberID)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {
                var mp = (from m in context.TbMemberProfile
                          join r in context.TbInterests on m.InterestedInType equals r.InterestId into grp
                          from r in grp.DefaultIfEmpty()
                          where m.MemberId == memberID

                          select new MemberProfileGenInfoModel()
                          {

                              MemberID = m.MemberId.ToString(),
                              FirstName = m.FirstName,
                              MiddleName = m.MiddleName,
                              LastName = m.LastName,
                              Sex = m.Sex,
                              ShowSexInProfile = m.ShowSexInProfile.ToString(),
                              DOBMonth = m.Dobmonth,
                              DOBDay = m.Dobday,
                              DOBYear = m.Dobyear,
                              ShowDOBType = m.ShowDobtype.ToString(),
                              Hometown = m.Hometown,
                              HomeNeighborhood = m.HomeNeighborhood,
                              CurrentStatus = m.CurrentStatus.ToString(),
                              InterestedInType = m.InterestedInType.ToString(),
                              LookingForEmployment = m.LookingForEmployment.ToString(),
                              LookingForRecruitment = m.LookingForRecruitment.ToString(),
                              LookingForPartnership = m.LookingForPartnership.ToString(),
                              LookingForNetworking = m.LookingForNetworking.ToString(),
                              PoliticalView = m.PoliticalView,
                              ReligiousView = m.ReligiousView,
                              PicturePath = m.PicturePath,
                              JoinedDate = m.JoinedDate.ToString(),
                              CurrentCity = m.CurrentCity,
                              TitleDesc = m.TitleDesc,
                              Sector = m.Sector,
                              Industry = m.Industry,
                              InterestedDesc = r == null ? String.Empty : r.InterestDesc
                          }).ToList();

                return mp;
            }
        }

        /// <summary>
        /// Get member general information
        /// </summary>
        /// <param name="memberID"></param>
        /// <returns></returns>
        public List<TbMemberProfile> GetMemberGeneralInfo(int memberID)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {
                var mp = (from m in context.TbMemberProfile where m.MemberId == memberID select m).ToList();
                return mp;
            }
        }

        /// <summary>
        /// get interest description
        /// </summary>
        /// <param name="interestID"></param>
        /// <returns></returns>
        public string GetInterestDescription(int interestID)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {
                var mp = (from m in context.TbInterests where m.InterestId == interestID select m).ToList();

                if (mp.Count != 0)
                {
                    return mp[0].InterestDesc;
                }
                else
                    return "";
            }
        }

        /// <summary>
        /// Get member personal information
        /// </summary>
        /// <param name="memberID"></param>
        /// <returns></returns>
        public List<TbMemberProfilePersonalInfo> GetMemberPersonalInfo(int memberID)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {
                var mp = (from m in context.TbMemberProfilePersonalInfo where m.MemberId == memberID select m).ToList();
                return mp;
            }
        }

        /// <summary>
        /// Get member contact information
        /// </summary>
        /// <param name="memberID"></param>
        /// <returns></returns>
        public List<TbMemberProfileContactInfo> GetMemberContactInfo(int memberID)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {
                var mp = (from m in context.TbMemberProfileContactInfo where m.MemberId == memberID select m).ToList();
                return mp;
            }
        }

        /// <summary>
        ///  Get member education information
        /// </summary>
        /// <param name="memberID"></param>
        /// <returns></returns>
        public List<MemberProfileEducationModel> GetMemberEducationInfo(int memberID)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {
                var mp = (from m in context.TbMemberProfileEducationV2
                          join d in context.TbDegreeType on m.DegreeType equals d.DegreeTypeId
                          where m.MemberId == memberID
                          orderby m.ClassYear descending
                          select new MemberProfileEducationModel()
                          {
                              degree = d.DegreeTypeDesc,
                              degreeTypeID = d.DegreeTypeId.ToString(),
                              major = m.Major,
                              schoolAddress = GetSchoolAddress(m.SchoolType, m.SchoolId),
                              schoolID = m.SchoolId.ToString(),
                              schoolImage = GetSchoolWebSite(m.SchoolType, m.SchoolId),
                              schoolName = GetSchoolName(m.SchoolType, m.SchoolId),
                              yearClass = m.ClassYear,
                              schoolType = m.SchoolType.ToString()
                              
                          }).ToList();

               //select m).ToList();
                return mp;
            }
        }

        private string GetSchoolName(int schoolType, int schoolId)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {
                string name = "";
                if (schoolType == 1) //public
                {
                    var ma = (from m in context.TbPublicSchools where m.Lgid == schoolId select m).ToList();
                    name = ma[0].SchoolName;

                }
                else if (schoolType == 2) //private
                {
                    var ma = (from m in context.TbPrivateSchools where m.Lgid == schoolId select m).ToList();
                    name = ma[0].SchoolName;

                }
                else //college
                {
                    var ma = (from m in context.TbColleges where m.SchoolId == schoolId select m).ToList();
                    name = ma[0].Name;
                }
                return name;
            }
        }

        private string GetSchoolWebSite(int schoolType, int schoolId)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {
                string name = "";
                if (schoolType == 1) //public
                {
                    //var ma = (from m in context.TbPublicSchools where m.Lgid == schoolId select m).ToList();
                    name = "";

                }
                else if (schoolType == 2) //private
                {
                    //var ma = (from m in context.TbPrivateSchools where m.Lgid == schoolId select m).ToList();
                    name = "";

                }
                else //college
                {
                    var ma = (from m in context.TbColleges where m.SchoolId == schoolId select m).ToList();
                    name = ma[0].Website;
                }
                return name;
            }
        }

        private string GetSchoolAddress(int schoolType, int schoolId)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {
                string name = "";
                if (schoolType == 1) //public
                {
                    var ma = (from m in context.TbPublicSchools where m.Lgid == schoolId select m).ToList();
                    name = ma[0].City + ", " + ma[0].State;

                }
                else if (schoolType == 2) //private
                {
                    var ma = (from m in context.TbPrivateSchools where m.Lgid == schoolId select m).ToList();
                    name = ma[0].City + ", " + ma[0].State;

                }
                else //college
                {
                    var ma = (from m in context.TbColleges where m.SchoolId == schoolId select m).ToList();
                    name = ma[0].Address;
                }
                return name;
            }
        }

        /// <summary>
        /// Get member employment information
        /// </summary>
        /// <param name="memberID"></param>
        /// <returns></returns>
        public List<MemberProfileEmploymentModel> GetMemberEmploymentInfo(int memberID)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {
                var ma = (from m in context.TbMemberProfileEmploymentInfoV2
                          join s in context.TbCompanies on m.CompanyId equals s.Id
                          where m.MemberId == memberID orderby m.StartYear descending
                          select new MemberProfileEmploymentModel()
                          {
                              City = m.City,
                              companyAddress = m.City + ", " + m.State,
                              companyID = m.CompanyId.ToString(),
                              companyImage = s.Website,
                              companyName = m.CompanyName,
                              CurrentlyWorkedHere = m.CurrentlyWorkedHere.ToString(),
                              datesWorked = "",
                              Description = s.Description,
                              Email = "",
                              EmpInfoID = m.EmpInfoId.ToString(),
                              EndMonth = m.EndMonth,
                              EndYear = m.EndYear,
                              Industry = s.Industry,
                              IPOYear = s.Ipoyear,
                              JobDesc = m.JobDesc,
                              Sector = s.Sector,
                              StartMonth = m.StartMonth,
                              StartYear = m.StartYear,
                              State = m.State,
                              summaryQuote = s.SummaryQuote,
                              Symbol = s.Symbol,
                              title = m.Position,
                              website = s.Website
                            
                            }).ToList();
                return ma;
            }
        }

        /// <summary>
        /// get the list of albums fro memberID
        /// </summary>
        /// <param name="memberID"></param>
        /// <returns></returns>
        public List<MemberAlbumsModel> GetMemberAlbums(int memberID)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {
                List<MemberAlbumsModel> lst = (from m in context.TbAlbums
                                               where m.MemberId == memberID
                                               select new MemberAlbumsModel()
                                               {
                                                   albumID = m.AlbumId.ToString(),
                                                   albumName = m.AlbumName,
                                                   createdDate = m.CreatedDate.ToString(),
                                                   description = m.Description,
                                                   photoCount = (m.TbAlbumPhotos.Count() == 1) ? m.TbAlbumPhotos.Count().ToString() + " Photo" : m.TbAlbumPhotos.Count().ToString() + " Photos",
                                                   fileName = (string.IsNullOrEmpty(m.TbAlbumPhotos.First().FileName)) ? "default.png" : m.TbAlbumPhotos.First().FileName
                                               }

                          ).ToList();
                return lst;
            }
        }

        /// <summary>
        /// get album photos listing for albumid
        /// </summary>
        /// <param name="albumID"></param>
        /// <returns></returns>
        public List<AlbumPhotosModel> GetMemberAlbumPhotos(int albumID)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {
                List<AlbumPhotosModel> lst;

                if (albumID != 0)
                {
                    lst = (from p in context.TbAlbumPhotos
                           where p.AlbumId == albumID && p.Removed != true
                           orderby p.PhotoId ascending
                           select new AlbumPhotosModel()
                           {
                               photoID = p.PhotoId.ToString(),
                               fileName = p.FileName,
                               photodesc = p.PhotoDesc,
                               photoName = p.PhotoName,
                               memberID = "0",
                               memberName = ""
                           }
                         ).ToList();
                }
                else
                {
                    lst = (from p in context.TbAlbumPhotos
                           where p.Removed != true
                           orderby p.PhotoId ascending
                           select new AlbumPhotosModel()
                           {
                               photoID = p.PhotoId.ToString(),
                               fileName = p.FileName,
                               photodesc = p.PhotoDesc,
                               photoName = p.PhotoName,
                               memberID = "0",
                               memberName = ""
                           }
                         ).ToList();
                }
                return lst;
            }
        }


        /// <summary>
        /// save member general info
        /// </summary>
        /// <param name="memberID"></param>
        /// <param name="firstName"></param>
        /// <param name="middleName"></param>
        /// <param name="lastName"></param>
        /// <param name="title"></param>
        /// <param name="sector"></param>
        /// <param name="industry"></param>
        /// <param name="interest"></param>
        /// <param name="status"></param>
        /// <param name="gender"></param>
        /// <param name="showGender"></param>
        /// <param name="DOBMonth"></param>
        /// <param name="DOBDay"></param>
        /// <param name="DOBYear"></param>
        /// <param name="showDOB"></param>
        /// <param name="lookingForPartnership"></param>
        /// <param name="lookingForEmployment"></param>
        /// <param name="lookingForRecruitment"></param>
        /// <param name="lookingForNetworking"></param>
        public void SaveMemberGeneralInfo(int memberID, string firstName, string middleName, string lastName, string title, string sector, string industry, int interest, int status, string gender, bool showGender,
                      string DOBMonth, string DOBDay,
                      string DOBYear,
                      bool showDOB,
                      bool lookingForPartnership,
                      bool lookingForEmployment,
                      bool lookingForRecruitment,
                      bool lookingForNetworking)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {

                var mID = new SqlParameter("@MemberID", memberID);
                var pFirstName = new SqlParameter("@FirstName", firstName);
                var pMidName = new SqlParameter("@MiddleName", middleName);
                var pLastName = new SqlParameter("@LastName", lastName);

                var pTitle = new SqlParameter("@Title", title);
                var pSector = new SqlParameter("@Sector", sector);
                var pIndustry = new SqlParameter("@Industry", industry);
                var pInterest = new SqlParameter("@InterestIn", interest);
                var pStatus = new SqlParameter("@CurrentStatus", status);
                var pGender = new SqlParameter("@Gender", gender);
                var pShowGender = new SqlParameter("@ShowGender", showGender);
                var pDOBMonth = new SqlParameter("@DOBMonth", DOBMonth);
                var pDOBDay = new SqlParameter("@DOBDay", DOBDay);
                var pDOBYear = new SqlParameter("@DOBYear", DOBYear);
                var pShowDOB = new SqlParameter("@ShowDOB", showDOB);
                var pLookingForPartnership = new SqlParameter("@LookingForPartnership", lookingForPartnership);
                var pLookingForEmployment = new SqlParameter("@LookingForEmployment", lookingForEmployment);
                var pLookingForRecruitment = new SqlParameter("@LookingForRecruitment", lookingForRecruitment);
                var pLookingForNetworking = new SqlParameter("@LookingForNetworking", lookingForNetworking);

                context.Database.ExecuteSqlCommand("EXEC spSaveMemberGeneralInfo @MemberID, @FirstName, @MiddleName, @LastName, @Title, @Sector, @Industry, @InterestIn, @CurrentStatus, @Gender, @ShowGender, @DOBMonth, @DOBDay, @DOBYear,@ShowDOB,@lookingForPartnership, @lookingForEmployment, @lookingForRecruitment, @lookingForNetworking",
                                                mID, pFirstName, pMidName, pLastName, pTitle, pSector, pIndustry, pInterest, pStatus, pGender, pShowGender, pDOBMonth, pDOBDay, pDOBYear,
                                                pShowDOB, pLookingForPartnership, pLookingForEmployment, pLookingForRecruitment,
                                                pLookingForNetworking);
            }
        }


        /// <summary>
        /// Save member personal information
        /// </summary>
        /// <param name="memberID"></param>
        /// <param name="activities"></param>
        /// <param name="interests"></param>
        /// <param name="specialSkills"></param>
        /// <param name="aboutMe"></param>
        public void SaveMemberPersonalInfo(
                     int memberID,
                     string activities,
                     string interests,
                     string specialSkills,
                     string aboutMe)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {
                var mID = new SqlParameter("@MemberID", memberID);
                var pActivities = new SqlParameter("@Activities", activities);
                var pInterests = new SqlParameter("@Interests", interests);
                var pSpecialSkills = new SqlParameter("@SpecialSkills", specialSkills);
                var pAboutMe = new SqlParameter("@AboutMe", aboutMe);

                context.Database.ExecuteSqlCommand("EXEC spSaveMemberPersonalInfo @MemberID, @Activities, @Interests, @SpecialSkills, @AboutMe",
                                                   mID, pActivities, pInterests, pSpecialSkills, pAboutMe);
            }
        }


        /// <summary>
        /// Save member contact information
        /// </summary>
        /// <param name="memberID"></param>
        /// <param name="email"></param>
        /// <param name="showEmailToMembers"></param>
        /// <param name="otherEmail"></param>
        /// <param name="IMDisplayName"></param>
        /// <param name="IMServiceType"></param>
        /// <param name="homePhone"></param>
        /// <param name="showHomePhone"></param>
        /// <param name="cellPhone"></param>
        /// <param name="showCellPhone"></param>
        /// <param name="otherPhone"></param>
        /// <param name="address"></param>
        /// <param name="showAddress"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="zipCode"></param>
        /// <param name="webSiteLinks"></param>
        /// <param name="neighborhood"></param>
        /// <param name="showLinks"></param>
        public void SaveMemberContactInfo(int memberID,
                              string email,
                              bool showEmailToMembers,
                              string otherEmail,
                              string IMDisplayName,
                              int IMServiceType,
                              string homePhone,
                              bool showHomePhone,
                              string cellPhone,
                              bool showCellPhone,
                              string otherPhone,
                              string address,
                              bool showAddress,
                              string city,
                              string state,
                              string zipCode,
                              string webSiteLinks,
                              string neighborhood,
                              bool showLinks)
        {

            var mID = new SqlParameter("@MemberID", memberID);
            var pEmail = new SqlParameter("@Email", email);
            var pShowEmailToMembers = new SqlParameter("@ShowEmailToMembers", showEmailToMembers);
            var pOtherEmail = new SqlParameter("@OtherEmail", otherEmail);
            var pIMDisplayName = new SqlParameter("@IMDisplayName", IMDisplayName);
            var pIMServiceType = new SqlParameter("@IMServiceType", IMServiceType);
            var pHomePhone = new SqlParameter("@HomePhone", homePhone);
            var pShowHomePhone = new SqlParameter("@ShowHomePhone", showHomePhone);
            var pCellPhone = new SqlParameter("@CellPhone", cellPhone);
            var pShowCellPhone = new SqlParameter("@ShowCellPhone", showCellPhone);
            var pOtherPhone = new SqlParameter("@OtherPhone", otherPhone);
            var pAddress = new SqlParameter("@Address", address);
            var pShowAddress = new SqlParameter("@ShowAddress", showAddress);
            var pCity = new SqlParameter("@City", city);
            var pState = new SqlParameter("@State", state);
            var pZipCode = new SqlParameter("@ZipCode", zipCode);
            var pWebSiteLinks = new SqlParameter("@WebSiteLinks", webSiteLinks);
            var pNeighborhood = new SqlParameter("@Neighborhood", neighborhood);
            var pShowLinks = new SqlParameter("@ShowLinks", showLinks);

            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {

                context.Database.ExecuteSqlCommand("EXEC spSaveMemberContactInfo @MemberID, @Email, @ShowEmailToMembers, @OtherEmail,@IMDisplayName, @IMServiceType, @HomePhone, @ShowHomePhone, @CellPhone, @ShowCellPhone, @OtherPhone, @Address, @ShowAddress, @City,@State,@ZipCode,@WebSiteLinks,@Neighborhood, @ShowLinks",
                                                   mID, pEmail, pShowEmailToMembers, pOtherEmail, pIMDisplayName, pIMServiceType, pHomePhone,
                                                   pShowHomePhone, pCellPhone, pShowCellPhone, pOtherPhone, pAddress, pShowAddress, pCity,
                                                   pState, pZipCode, pWebSiteLinks, pNeighborhood, pShowLinks);
            }
        }


        /// <summary>
        /// Save member education information
        /// </summary>
        /// <param name="memberID"></param>
        /// <param name="highSchool"></param>
        /// <param name="highSchoolClassYear"></param>
        /// <param name="college1"></param>
        /// <param name="college1ClassYear"></param>
        /// <param name="college1Major"></param>
        /// <param name="college1DegreeType"></param>
        /// <param name="college1Societies"></param>
        /// <param name="college2"></param>
        /// <param name="college2ClassYear"></param>
        /// <param name="college2Major"></param>
        /// <param name="college2DegreeType"></param>
        /// <param name="college2Societies"></param>
        public void SaveMemberEducationInfo(int memberID,
                                    string highSchool,
                                    string highSchoolClassYear,
                                    string college1,
                                    string college1ClassYear,
                                    string college1Major,
                                    int college1DegreeType,
                                    string college1Societies,
                                    string college2,
                                    string college2ClassYear,
                                    string college2Major,
                                    int college2DegreeType,
                                    string college2Societies)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {

                var mID = new SqlParameter("@MemberID", memberID);
                var pHighSchool = new SqlParameter("@HighSchool", highSchool);
                var pHighSchoolClassYear = new SqlParameter("@HighSchoolClassYear", highSchoolClassYear);
                var pCollege1 = new SqlParameter("@College1", college1);
                var pCollege1ClassYear = new SqlParameter("@College1ClassYear", college1ClassYear);
                var pCollege1Major = new SqlParameter("@College1Major", college1Major);
                var pCollege1DegreeType = new SqlParameter("@College1DegreeType", college1DegreeType);
                var pCollege1Societies = new SqlParameter("@College1Societies", college1Societies);
                var pCollege2 = new SqlParameter("@College2", college2);
                var pCollege2ClassYear = new SqlParameter("@College2ClassYear", college2ClassYear);
                var pCollege2Major = new SqlParameter("@College2Major", college2Major);
                var pCollege2DegreeType = new SqlParameter("@College2DegreeType", college2DegreeType);
                var pCollege2Societies = new SqlParameter("@College2Societies", college2Societies);

                context.Database.ExecuteSqlCommand("EXEC spSaveMemberEducationInfo @MemberID,@HighSchool, @HighSchoolClassYear, @College2, @College2ClassYear, @College2Major, @College2DegreeType, @College2Societies,",
                                                   mID, pHighSchool, pHighSchoolClassYear, pCollege1, pCollege1ClassYear, pCollege1Major, pCollege1DegreeType,
                                                   pCollege1Societies, pCollege2, pCollege2ClassYear, pCollege2Major, pCollege2DegreeType, pCollege2Societies);

            }
        }


        /// <summary>
        /// save member employment information
        /// </summary>
        /// <param name="memberID"></param>
        /// <param name="employer"></param>
        /// <param name="emp1Position"></param>
        /// <param name="emp1JobDesc"></param>
        /// <param name="emp1City"></param>
        /// <param name="emp1State"></param>
        /// <param name="emp1StartMonth"></param>
        /// <param name="emp1StartYear"></param>
        /// <param name="emp1EndMonth"></param>
        /// <param name="emp1EndYear"></param>
        /// <param name="employer2"></param>
        /// <param name="emp2Position"></param>
        /// <param name="emp2JobDesc"></param>
        /// <param name="emp2City"></param>
        /// <param name="emp2State"></param>
        /// <param name="emp2StartMonth"></param>
        /// <param name="emp2StartYear"></param>
        /// <param name="emp2EndMonth"></param>
        /// <param name="emp2EndYear"></param>
        /// <param name="employer3"></param>
        /// <param name="emp3Position"></param>
        /// <param name="emp3JobDesc"></param>
        /// <param name="emp3City"></param>
        /// <param name="emp3State"></param>
        /// <param name="emp3StartMonth"></param>
        /// <param name="emp3StartYear"></param>
        /// <param name="emp3EndMonth"></param>
        /// <param name="emp3EndYear"></param>
        public void SaveMemberEmploymentInfo(int memberID,
                              string employer,
                              string emp1Position,
                              string emp1JobDesc,
                              string emp1City,
                              string emp1State,
                              string emp1StartMonth,
                              string emp1StartYear,
                              string emp1EndMonth,
                              string emp1EndYear,

                              string employer2,
                              string emp2Position,
                              string emp2JobDesc,
                              string emp2City,
                              string emp2State,
                              string emp2StartMonth,
                              string emp2StartYear,
                              string emp2EndMonth,
                              string emp2EndYear,

                              string employer3,
                              string emp3Position,
                              string emp3JobDesc,
                              string emp3City,
                              string emp3State,
                              string emp3StartMonth,
                              string emp3StartYear,
                              string emp3EndMonth,
                              string emp3EndYear)
        {

            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {

                var mID = new SqlParameter("@MemberID", memberID);

                var pEmployer = new SqlParameter("@Employer", employer);
                var pEmp1Position = new SqlParameter("@Emp1Position", emp1Position);
                var pEmp1JobDesc = new SqlParameter("@Emp1JobDesc", emp1JobDesc);
                var pEmp1City = new SqlParameter("@Emp1City", emp1City);
                var pEmp1State = new SqlParameter("@Emp1State", emp1State);
                var pEmp1StartMonth = new SqlParameter("@Emp1StartMonth", emp1StartMonth);
                var pEmp1EndMonth = new SqlParameter("@Emp1EndMonth", emp1EndMonth);
                var pEmp1StartYear = new SqlParameter("@Emp1StartYear", emp1StartYear);
                var pEmp1EndYear = new SqlParameter("@Emp1EndYear", emp1EndYear);

                var pEmployer2 = new SqlParameter("@Employer2", employer2);
                var pEmp2Position = new SqlParameter("@Emp2Position", emp2Position);
                var pEmp2JobDesc = new SqlParameter("@Emp2JobDesc", emp2JobDesc);
                var pEmp2City = new SqlParameter("@Emp2City", emp2City);
                var pEmp2State = new SqlParameter("@Emp2State", emp2State);
                var pEmp2StartMonth = new SqlParameter("@Emp2StartMonth", emp2StartMonth);
                var pEmp2EndMonth = new SqlParameter("@Emp2EndMonth", emp2EndMonth);
                var pEmp2StartYear = new SqlParameter("@Emp2StartYear", emp2StartYear);
                var pEmp2EndYear = new SqlParameter("@Emp2EndYear", emp2EndYear);

                var pEmployer3 = new SqlParameter("@Employer2", employer3);
                var pEmp3Position = new SqlParameter("@Emp3Position", emp3Position);
                var pEmp3JobDesc = new SqlParameter("@Emp3JobDesc", emp3JobDesc);
                var pEmp3City = new SqlParameter("@Emp3City", emp3City);
                var pEmp3State = new SqlParameter("@Emp3State", emp3State);
                var pEmp3StartMonth = new SqlParameter("@Emp3StartMonth", emp3StartMonth);
                var pEmp3EndMonth = new SqlParameter("@Emp3EndMonth", emp3EndMonth);
                var pEmp3StartYear = new SqlParameter("@Emp3StartYear", emp3StartYear);
                var pEmp3EndYear = new SqlParameter("@Emp3EndYear", emp3EndYear);

                context.Database.ExecuteSqlCommand("EXEC spSaveMemberEmploymentInfo @MemberID, @Employer, @Emp1Position, @Emp1JobDesc, @Emp1City, @Emp1State, @Emp1StartMonth, @Emp1StartYear, @Emp1EndMonth, @Emp1EndYear,@Employer2, @Emp2Position, @Emp2JobDesc, @Emp2City, @Emp2State, @Emp2StartMonth, @Emp2StartYear, @Emp2EndMonth, @Emp2EndYear,@Employer3, @Emp3Position, @Emp3JobDesc, @Emp3City, @Emp3State, @Emp3StartMonth, @Emp3StartYear, @Emp3EndMonth, @Emp3EndYear",
                                  mID, pEmployer, pEmp1Position, pEmp1JobDesc, pEmp1City, pEmp1State, pEmp1StartMonth, pEmp1StartYear, pEmp1EndMonth, pEmp1EndYear,
                                  pEmployer2, pEmp2Position, pEmp2JobDesc, pEmp2City, pEmp2State, pEmp2StartMonth, pEmp2StartYear, pEmp2EndMonth, pEmp2EndYear,
                                  pEmployer3, pEmp3Position, pEmp3JobDesc, pEmp3City, pEmp3State, pEmp3StartMonth, pEmp3StartYear, pEmp3EndMonth, pEmp3EndYear);
            }
        }

        /// <summary>
        /// Save contact or friend request
        /// </summary>
        /// <param name="memberID"></param>
        /// <param name="email"></param>
        public void SendFriendRequest(int memberID, string email)
        {
            var mID = new SqlParameter("@MemberID", memberID);
            var pEmail = new SqlParameter("@Email", email);

            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {
                context.Database.ExecuteSqlCommand("EXEC spSendFriendRequest @memberID, @Email", mID, pEmail);
            }
        }


        /// <summary>
        /// check to see if a contact request was sent for mebmer id
        /// </summary>
        /// <param name="memberID"></param>
        /// <param name="toMemberiD"></param>
        /// <returns></returns>
        public bool isContactRequestSent(int memberID, int toMemberiD)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {
                List<TbContactRequests> mbr = (from m in context.TbContactRequests where m.FromMemberId == memberID && m.ToMemberId == toMemberiD select m).ToList();
                if (mbr.Count == 0)
                    return false;
                else
                    return true;
            }
        }

        /// <summary>
        /// check to seem if email is alread a member of LG
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool IsMember(string email)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {
                List<TbMembers> mbr = (from m in context.TbMembers where m.Email == email select m).ToList();
                if (mbr.Count == 0)
                    return false;
                else
                    return true;
            }
        }

        /// <summary>
        /// Check to see if membeid or email is friend.
        /// </summary>
        /// <param name="memberID"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool IsFriend(int memberID, string email)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {
                var clist = (from m in context.TbMembers join c in context.TbContacts on m.MemberId equals c.ContactId where c.MemberId == memberID && m.Email == email select m).ToList();
                if (clist.Count == 0)
                    return false;
                else
                    return true;
            }
        }

        /// <summary>
        /// get member email and other info
        /// </summary>
        /// <param name="memberID"></param>
        /// <returns></returns>
        public List<TbMembers> GetMemberEmail(int memberID)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {
                var clist = (from m in context.TbMembers join p in context.TbMemberProfile on m.MemberId equals p.MemberId where p.MemberId == memberID select m).ToList();
                return clist;
            }

        }


        /// <summary>
        /// Check to see if membeid or email is friend.
        /// </summary>
        /// <param name="memberID"></param>
        /// <param name="contactID"></param>
        /// <returns></returns>
        public bool IsFriend(int memberID, int contactID)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {
                var clist = (from m in context.TbMembers join c in context.TbContacts on m.MemberId equals c.ContactId where c.MemberId == memberID && c.ContactId == contactID select m).ToList();
                if (clist.Count == 0)
                    return false;
                else
                    return true;
            }
        }


        /// <summary>
        /// Save member basic profile information
        /// </summary>
        /// <param name="email"></param>
        /// <param name="highSchool"></param>
        /// <param name="highSchoolYear"></param>
        /// <param name="college"></param>
        /// <param name="collegeYear"></param>
        /// <param name="company"></param>
        public void SaveBasicProfileInfo(string email,
                                    string highSchool,
                                    string highSchoolYear,
                                    string college,
                                    string collegeYear,
                                    string company)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {
                var pEmail = new SqlParameter("@Email", email);
                var pHighSchool = new SqlParameter("@HighSchool", highSchool);
                var pHighSchoolYear = new SqlParameter("@HighSchoolYear", highSchoolYear);
                var pCollege = new SqlParameter("@College", college);
                var pCollegeYear = new SqlParameter("CollegeYear", collegeYear);
                var pCompany = new SqlParameter("@Company", company);

                context.Database.ExecuteSqlCommand("EXEC spSaveBasicProfileInfo @Email, @HighSchool, @HighSchoolYear, @College, @CollegeYear, @Company",
                                                    pEmail, pHighSchool, pHighSchoolYear, pCollege, pCollegeYear, pCompany);
            }

        }

        /// <summary>
        /// Get member information by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public List<MemberInfoByEmailModel> GetMemberInfoByEmail(string email)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {
                List<MemberInfoByEmailModel> lst = (from m in context.TbMembers join mp in context.TbMemberProfile on m.MemberId equals mp.MemberId
                                                    where m.Email == email
                                                    select new MemberInfoByEmailModel()
                                                    {
                                                        friendID = m.MemberId.ToString(),
                                                        picturePath = (string.IsNullOrEmpty(mp.PicturePath)) ? "default.png" : mp.PicturePath,
                                                        email = m.Email,
                                                        name = mp.FirstName + " " + mp.LastName
                                                    }

                          ).ToList();
                return lst;
            }
        }

        /// <summary>
        /// Get recent activites for member id
        /// </summary>
        /// <param name="memberID"></param>
        /// <returns></returns>
        public List<RecentActivitiesModel> GetRecentActivities(int memberID)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {
                List<RecentActivitiesModel> lst = (from m in context.TbMembersRecentActivities
                                                   join mp in context.TbActivityType on m.ActivityTypeId equals mp.ActivityTypeId
                                                   where m.MemberId == memberID
                                                   select new RecentActivitiesModel()
                                                   {
                                                       activityID = m.ActivityId.ToString(),
                                                       description = m.Description,
                                                       activityDate = m.ActivityDate.ToString(),
                                                       imageFile = (string.IsNullOrEmpty(mp.ImageFile)) ? "default.png" : mp.ImageFile,
                                                   }
                          ).ToList();
                return lst;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="memberID"></param>
        /// <param name="activity"></param>
        public void AddMemberAcitivity(int memberID, string activity)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {
                TbMembersRecentActivities rs = new TbMembersRecentActivities();
                rs.MemberId = memberID;
                rs.Description = activity;
                context.TbMembersRecentActivities.Add(rs);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// get member posts for member id
        /// </summary>
        /// <param name="memberID"></param>
        /// <returns></returns>
        public List<MemberPostsModel> GetMemberPosts(int memberID)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext()) {

                var l = (from d in context.TbContacts where d.MemberId == memberID select d.ContactId).ToList();
                l.Add(memberID);

                List<MemberPostsModel> lst;
                lst = (from mn in context.TbMemberPosts
                       join mnn in context.TbMemberProfile on mn.MemberId equals mnn.MemberId
                       //where mn.MemberId == memberID
                       where l.Contains ((int) mn.MemberId)
                       orderby mn.PostDate  descending
                       select new MemberPostsModel() {
                           postID = mn.PostId.ToString(),
                           title = mn.Title,
                           description = mn.Description,
                           datePosted = mn.PostDate.ToString(),
                           attachFile = mn.AttachFile,
                           memberID = mn.MemberId.ToString(),
                           picturePath = mnn.PicturePath,
                           memberName = mnn.FirstName + " " + mnn.LastName,
                           firstName = mnn.FirstName,
                           childPostCnt = "0"
                       }
                       )
                       //.Take (15).Union(from mn in context.TbMemberPosts
                        //       join mnn in context.TbMemberProfile on mn.MemberId equals mnn.MemberId
                        //       where l.Contains((int)mn.MemberId)
                        //       orderby mn.PostDate descending
                        //       select new MemberPostsModel()
                        //       {
                        //           postID = mn.PostId.ToString(),
                        //           title = mn.Title,
                        //           description = mn.Description,
                        //           datePosted = mn.PostDate.ToString(),
                        //           attachFile = mn.AttachFile,
                        //           memberID = mn.MemberId.ToString(),
                        //           picturePath = mnn.PicturePath,
                        //           memberName = mnn.FirstName + " " + mnn.LastName,
                        //           firstName = mnn.FirstName,
                        //           childPostCnt = "0"
                        //       }
                        //)
                        .Take (18).ToList();
                return lst;
            }
        }

        /// <summary>
        /// get member child posts form post id
        /// </summary>
        /// <param name="postID"></param>
        /// <returns></returns>
        public List<RecentPostChildModel> GetMemberPostResponses(int postID)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {
                var clist = (from p in context.TbMemberPostResponses
                             join m in context.TbMemberProfile on p.MemberId equals m.MemberId
                             into matchGroup
                             where matchGroup.Count() > 0 && p.PostId == (int?)postID
                             orderby p.ResponseDate descending
                             select new
                             {
                                 postResponseID = p.PostResponseId,
                                 postID = p.PostId,
                                 description = p.Description,
                                 dateResponded = p.ResponseDate,
                                 memberID = p.MemberId,
                                 mg = matchGroup
                                 //memberName = matchGroup m.FirstName + ' ' + m.LastName,
                                 //firstName = "", //m.FirstName,
                                 //picturePath = "" //m.PicturePath
                             }).ToList();

                List<RecentPostChildModel> lst = new List<RecentPostChildModel>();
                if (clist != null)
                {
                    if (clist.Count() != 0)
                    {
                        foreach (var item in clist)
                        {
                            RecentPostChildModel mod = new RecentPostChildModel();
                            mod.postResponseID = item.postResponseID;
                            mod.postID = item.postID;
                            mod.description = item.description;
                            mod.dateResponded = item.dateResponded;
                            mod.memberID = item.memberID;
                            foreach (var mem in item.mg)
                            {
                                mod.memberName = mem.FirstName + ' ' + mem.LastName;
                                mod.firstName = mem.FirstName;
                                mod.picturePath = mem.PicturePath;
                                if (string.IsNullOrEmpty(mod.picturePath))
                                {
                                    mod.picturePath = "default.png";
                                }
                            }
                            lst.Add(mod);
                        }
                    }
                }
                return lst;
            }
        }


        /// <summary>
        /// Update profile picture for member id
        /// </summary>
        /// <param name="memberID"></param>
        /// <param name="fileName"></param>
        public void UpdateProfilePicture(int memberID, string fileName)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {

                //update tb meber profile with new profile picture
                var mbr = (from m in context.TbMemberProfile where m.MemberId == memberID select m).First();
                mbr.PicturePath = fileName;
                context.SaveChanges();

                ////remove the old default picture for the member 
                //var mq = (from q in context.TbMemberProfilePictures where q.MemberId == memberID && q.IsDefault == true select q).First();
                //mq.IsDefault = false;

                //context.SaveChanges();

                //// add new picture to member profile picture table and set it as new default
                //TbMemberProfilePictures mp = new TbMemberProfilePictures();
                //mp.IsDefault = true;
                //mp.FileName = fileName;
                //mp.MemberId = memberID;
                //context.TbMemberProfilePictures.Add(mp);

                //context.SaveChanges();
            }
        }

        /// <summary>
        /// Create member posts
        /// </summary>
        /// <param name="memberID"></param>
        /// <param name="postMsg"></param>
        public void CreateMemberPost(int memberID, string postMsg)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {
                var mID = new SqlParameter("@MemberID", memberID);
                var pPostMsg = new SqlParameter("@PostMsg", postMsg);
                context.Database.ExecuteSqlCommand("EXEC spCreateMemberPost @MemberID, @PostMsg", mID, pPostMsg);
            }
        }

        /// <summary>
        /// Create post comments
        /// </summary>
        /// <param name="memberID"></param>
        /// <param name="postID"></param>
        /// <param name="postMsg"></param>
        public void CreatePostComment(int memberID, int postID, string postMsg)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext()) {
                var mID = new SqlParameter("@MemberID", memberID);
                var pPostID = new SqlParameter("@PostID", postID);
                var pPostMsg = new SqlParameter("@PostMsg", postMsg);
                context.Database.ExecuteSqlCommand(" EXEC spCreatePostComment @MemberID, @PostID, @PostMsg", mID, pPostID, pPostMsg);
            }
        }



        /// <summary>
        /// get album photos
        /// </summary>
        /// <param name="albumID"></param>
        /// <returns></returns>
        public List<AlbumPhotosModel> GetAlbumPhotos(int albumID)
        {
            return GetMemberAlbumPhotos((albumID));
        }

        /// <summary>
        /// Creates the album.
        /// </summary>
        /// <param name="memberID">Member identifier.</param>
        /// <param name="albumName">Album name.</param>
        /// <param name="desc">Desc.</param>
        /// <param name="privacy">Privacy.</param>
        public void CreateAlbum(int memberID, string albumName, string desc, int privacy)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {
                var mID = new SqlParameter("@MemberID", memberID);
                var pAlbumName = new SqlParameter("@AlbumName", albumName);
                var pDesc = new SqlParameter("@AlbumDesc", albumName);
                var pPrivacy = new SqlParameter("@Privacy", albumName);

                context.Database.ExecuteSqlCommand("EXEC spCreateAlbum @MemberID, @AlbumName, @AlbumDesc, @Privacy",
                                                   mID, pAlbumName, pDesc, pPrivacy);
            }
        }

        /// <summary>
        /// get album information
        /// </summary>
        /// <param name="albumID"></param>
        /// <returns></returns>
        public List<TbAlbums> GetAbumInfo(int albumID)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext()) {
                var lst = (from a in context.TbAlbums where a.AlbumId == albumID select a).ToList();
                return lst;
            }
        }

        /// <summary>
        /// Update album
        /// </summary>
        /// <param name="albumID"></param>
        /// <param name="memberID"></param>
        /// <param name="albumName"></param>
        /// <param name="desc"></param>
        /// <param name="privacy"></param>
        public void UpdateAlbum(int albumID, int memberID, string albumName, string desc, int privacy)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext()) {

                var pAlbumID = new SqlParameter("@AlbumID", albumID);
                var pMemberID = new SqlParameter("@AMemberID", memberID);
                var pAlbumName = new SqlParameter("@AlbumName", albumName);
                var pDesc = new SqlParameter("@Desc", desc);
                var pPrivacy = new SqlParameter("@Privacy", privacy);

                context.Database.ExecuteSqlCommand("EXEC spUpdateAlbum @AlbumID, @MemberID, @AlbumName, @Desc, @Privacy",
                                                   pAlbumID, pMemberID, pAlbumName, pDesc, pPrivacy);
            }
        }

        /// <summary>
        /// Create album photo
        /// </summary>
        /// <param name="albumID"></param>
        /// <param name="ext"></param>
        /// <returns></returns>
        public int CreateAlbumPhoto(int albumID, string ext)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {

                var obj = new TbAlbumPhotos
                {
                    AlbumId = albumID
                };
                context.TbAlbumPhotos.Add(obj);
                context.SaveChanges();
                var id = obj.PhotoId;

                if (id > 0)
                {
                    obj.FileName = id.ToString() + ext;
                    return id;
                }
                else
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// Remove album id
        /// </summary>
        /// <param name="albumID"></param>
        public void RemoveAlbumID(int albumID)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext()) {
                var pAlbumID = new SqlParameter("@AlbumID", albumID);
                context.Database.ExecuteSqlCommand("EXEC spRemoveAlbum @AlbumID", pAlbumID);
            }
        }

        /// <summary>
        /// Remove photo id
        /// </summary>
        /// <param name="photoID"></param>
        public void RemovePhotoID(int photoID)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {
                var pPhotoID = new SqlParameter("@PhotoID", photoID);
                context.Database.ExecuteSqlCommand("EXEC spRemovePhoto @AlbumID", pPhotoID);
            }
        }

       /// <summary>
       /// Updates the photo.
       /// </summary>
       /// <param name="photoID">Photo identifier.</param>
       /// <param name="title">Title.</param>
       /// <param name="photoDesc">Photo desc.</param>
        public void UpdatePhoto(int photoID, string title, string photoDesc)
        {

            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {
                //update tb meber profile with new profile picture
                var p = (from ap in context.TbAlbumPhotos where ap.PhotoId == photoID select ap).First();
                p.PhotoName = title.Replace("'", "\'");
                p.PhotoDesc = photoDesc;
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Get total albums count for member id
        /// </summary>
        /// <param name="memberID"></param>
        /// <returns></returns>
        public int GetTotalAlbums(int memberID)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext()) {
                var t = (from m in context.TbAlbums where m.MemberId == memberID select m).ToList();
                return t.Count;
            }
        }

        /// <summary>
        /// Get member work experience
        /// </summary>
        /// <param name="memberID"></param>
        /// <returns></returns>
        public List<TbMemberProfileEmploymentInfoV2> GetMemberWorkExperience(int memberID)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext()) {
                var lst = (from e in context.TbMemberProfileEmploymentInfoV2 where e.MemberId == memberID select e).ToList();
                return lst;
            }
        }

        /// <summary>
        /// Get member's interests
        /// </summary>
        /// <returns></returns>
        public List<TbInterests> GetMemberInterests()
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext()) {
                List<TbInterests> intList = (from i in context.TbInterests orderby i.InterestDesc select i).ToList();
                return intList;
            }
        }

        /// <summary>
        /// Add member school attended
        /// </summary>
        /// <param name="memberID"></param>
        /// <param name="instID"></param>
        /// <param name="instType"></param>
        /// <param name="school"></param>
        /// <param name="classYear"></param>
        /// <param name="major"></param>
        /// <param name="degree"></param>
        /// <param name="societies"></param>
        public void AddMemberSchool(int memberID, int instID, int instType, string school, string classYear, string major, int degree, string societies)
        {

            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext()) {
                TbMemberProfileEducationV2 mp = new TbMemberProfileEducationV2();
                mp.MemberId = memberID;
                mp.SchoolId = instID;
                mp.SchoolType = instType;
                mp.SchoolName = "";
                mp.ClassYear = classYear;
                mp.Major = major;
                mp.DegreeType = degree;
                mp.Societies = societies;
                context.TbMemberProfileEducationV2.Add(mp);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// edit school attended.
        /// </summary>
        /// <param name="memberID"></param>
        /// <param name="instID"></param>
        /// <param name="instType"></param>
        /// <param name="classYear"></param>
        /// <param name="major"></param>
        /// <param name="degree"></param>
        /// <param name="societies"></param>
        public void UpdateMemberSchool(int memberID, int instID, int instType, string classYear, string major, int degree, string societies)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {

                //update tb meber profile with new profile picture
                var mbr = (from m in context.TbMemberProfileEducationV2 where m.MemberId == memberID && m.SchoolId == instID && m.SchoolType == instType select m).First();
                mbr.ClassYear = classYear;
                mbr.Major = major;
                mbr.DegreeType = degree;
                mbr.Societies = societies;
                context.SaveChanges();
            }
        }

        /// <summary>
        /// remove school attended.
        /// </summary>
        /// <param name="memberID"></param>
        /// <param name="instID"></param>
        /// <param name="instType"></param>
        public void RemoveMemberSchool(int memberID, int instID, int instType)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {
                var s = (from c in context.TbMemberProfileEducationV2 where c.SchoolId == instID && c.MemberId == memberID && c.SchoolType == instType select c).First();
                context.TbMemberProfileEducationV2.Remove(s);
                context.SaveChanges();
            }
        }

        public void AddWorkExperience(int memberID, int companyID, string companyName, string title, string jobDesc, string jobCity, string state, string startMonth, string startYear, string endMonth, string endYear)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext()) {

                TbMemberProfileEmploymentInfoV2 mp = new TbMemberProfileEmploymentInfoV2();
                mp.MemberId = memberID;
                mp.CompanyId = companyID;
                mp.CompanyName = companyName;
                mp.Position = title;
                mp.JobDesc = jobDesc;
                mp.City = jobCity;
                mp.State = state;
                mp.StartMonth = startMonth;
                mp.StartYear = startYear;
                mp.EndMonth = endMonth;
                mp.EndYear = endYear;
                context.TbMemberProfileEmploymentInfoV2.Add(mp);
                context.SaveChanges();
            }
        }

       /// <summary>
       /// Updates the member work experience.
       /// </summary>
       /// <param name="empInfoID">Emp info identifier.</param>
       /// <param name="memberID">Member identifier.</param>
       /// <param name="compID">Comp identifier.</param>
       /// <param name="title">Title.</param>
       /// <param name="jobDesc">Job desc.</param>
       /// <param name="city">City.</param>
       /// <param name="state">State.</param>
       /// <param name="startMonth">Start month.</param>
       /// <param name="startYear">Start year.</param>
       /// <param name="endMonth">End month.</param>
       /// <param name="endYear">End year.</param>
        public void UpdateMemberWorkExperience(int empInfoID, int memberID, int compID, string title, string jobDesc, string city, string state, string startMonth, string startYear, string endMonth, string endYear)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext()) {

                //update tb meber profile with new profile picture
                var mbr = (from m in context.TbMemberProfileEmploymentInfoV2 where m.MemberId == memberID && m.CompanyId == compID && m.EmpInfoId == empInfoID select m).First();
                mbr.Position = title;
                mbr.JobDesc = jobDesc;
                mbr.City = city;
                mbr.State = state;
                mbr.StartMonth = startMonth;
                mbr.StartYear = startYear;
                mbr.EndMonth = endMonth;
                mbr.EndYear = endYear;
                context.SaveChanges();
            }
        }

      /// <summary>
      /// Removes the member work experience.
      /// </summary>
      /// <param name="empInfoID">Emp info identifier.</param>
      /// <param name="memberID">Member identifier.</param>
      /// <param name="compID">Comp identifier.</param>
        public void RemoveMemberWorkExperience(int empInfoID, int memberID, int compID)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {
                var s = (from c in context.TbMemberProfileEmploymentInfoV2 where c.CompanyId == compID && c.MemberId == memberID && c.EmpInfoId == empInfoID select c).First();
                context.TbMemberProfileEmploymentInfoV2.Remove(s);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Gets the resume settings.
        /// </summary>
        /// <returns>The resume settings.</returns>
        /// <param name="memberID">Member identifier.</param>
        public List<TbResumeSettings> GetResumeSettings(int memberID)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {
                var s = (from c in context.TbResumeSettings where c.MemberId == memberID select c).ToList();
                return s;
            }
        }

        /// <summary>
        /// update resume settings
        /// </summary>
        /// <param name="memberID"></param>
        /// <param name="showResume"></param>
        /// <param name="ShowSpecialSkills"></param>
        /// <param name="ShowAbout"></param>
        /// <param name="ShowInterests"></param>
        /// <param name="ShowActivities"></param>
        public void UpdateResumeSettings(int memberID, bool showResume, bool ShowSpecialSkills, bool ShowAbout, bool ShowInterests, bool ShowActivities)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext()) {
                var s = (from c in context.TbResumeSettings where c.MemberId == memberID select c).ToList();
                if (s.Count == 0) //insert
                {
                    TbResumeSettings rs = new TbResumeSettings();
                    rs.MemberId = memberID;
                    rs.ShowResume = showResume;
                    rs.ShowSpecialSkills = ShowSpecialSkills;
                    rs.ShowAbout = ShowAbout;
                    rs.ShowInterests = ShowInterests;
                    rs.ShowActivities = ShowActivities;
                    context.TbResumeSettings.Add(rs);
                    context.SaveChanges();
                }
                else //update
                {
                    //update tb meber profile with new profile picture
                    var mbr = (from m in context.TbResumeSettings where m.MemberId == memberID select m).First();
                    mbr.MemberId = memberID;
                    mbr.ShowResume = showResume;
                    mbr.ShowSpecialSkills = ShowSpecialSkills;
                    mbr.ShowAbout = ShowAbout;
                    mbr.ShowInterests = ShowInterests;
                    mbr.ShowActivities = ShowActivities;
                    context.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Checks to see if the member active.
        /// </summary>
        /// <returns><c>true</c>, if member active was ised, <c>false</c> otherwise.</returns>
        /// <param name="memberID">Member identifier.</param>
        public bool IsMemberActive(int memberID)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext()) {
                List<TbMembers> mbr = (from m in context.TbMembers where m.MemberId == memberID && m.Status != 3 select m).ToList();
                if (mbr.Count == 0)
                    return false;
                else
                    return true;
            }
        }

        /// <summary>
        /// returns the count of all pictures or photos for the member id 
        /// </summary>
        /// <param name="memberID"></param>
        /// <returns></returns>
        public int GetMemberPhotoCount(int memberID)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {
                var lst = (from p in context.TbAlbumPhotos join r in context.TbAlbums on p.AlbumId equals r.AlbumId where r.MemberId == memberID select p).ToList();
                return lst.Count();
            }
        }


        /// <summary>
        /// returns the count of all profile pictures for the member id
        /// </summary>
        /// <param name="memberID"></param>
        /// <returns></returns>
        public int GetMemberProfilePictureCount(int memberID)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {
                List<TbMemberProfilePictures> dat = (from m in context.TbMemberProfilePictures where m.MemberId == memberID select m).ToList();
                return dat.Count;
            }
        }

        /// <summary>
        /// Gets the registered members.
        /// </summary>
        /// <returns>The registered members.</returns>
        /// <param name="status">Status.</param>
        public List<RegisteredMembersModel> GetRegisteredMembers(int status)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {

                List<RegisteredMembersModel> dat = (from m in context.TbMembers
                                                    join mp in context.TbMemberProfile on m.MemberId equals mp.MemberId
                                                    join r in context.TbMembersRegistered on m.MemberId equals r.MemberId
                                                    //into matchGroup
                                                    where //matchGroup.Count() > 0 && 
                                                    m.Status == (int?)status
                                                    //orderby r.registeredDate descending
                                                    select new RegisteredMembersModel()
                                                    {
                                                        memberID = m.MemberId.ToString(),
                                                        email = m.Email,
                                                        status = m.Status.ToString(),
                                                        firstName = mp.FirstName,
                                                        lastName = mp.LastName,
                                                        sex = mp.Sex,
                                                        picturePath = mp.PicturePath,
                                                        joinedDate = mp.JoinedDate.ToString(),
                                                        titleDesc = mp.TitleDesc,
                                                        sector = mp.Sector,
                                                        industry = mp.Industry,
                                                        registeredDate = r.RegisteredDate.ToString()
                                                    }).ToList();

                return dat;
            }
        }



        #endregion
    }
}
