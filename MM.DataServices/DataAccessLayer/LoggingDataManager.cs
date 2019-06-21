using System;
using System.Collections.Generic;
using System.Linq;

using MM.DataServices.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace MM.DataServices.Security
{
    /// <summary>
    /// Describes the functionalities for accessing data for security
    /// </summary>
    public class LoggingDataManager
    {
        /// <summary>
        /// constructor for ths class
        /// </summary>
        public LoggingDataManager()
        {
        }

        /// <summary>
        /// Allows you to change user password.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="newPwd"></param>
        public void ChangePassword(string email, string newPwd)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {
                var em = new SqlParameter("@Email", email);
                var nPwd = new SqlParameter("@NewPwd", newPwd);

                context.Database.ExecuteSqlCommand("EXEC spChangePasswordViaEmail @Email, @NewPwd",em, nPwd);
            }
        }

        /// <summary>
        /// validates a user to see if he/she has an account on this site.
        /// </summary>
        /// <param name="strEmail"></param>
        /// <param name="strPwd"></param>
        /// <returns></returns>
        public List<UserModel> ValidateUser(string strEmail, string strPwd)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {
                var mlist = (from c in context.TbMembers join m in context.TbMemberProfile on c.MemberId equals m.MemberId where (c.Email == strEmail) && (c.Password == strPwd) && (c.Status == 2)
                             select new UserModel()
                             {
                                 memberID = c.MemberId.ToString(),
                                 name = m.FirstName + " " + m.LastName,
                                 email = c.Email,
                                 picturepath = m.PicturePath 
                             }
                             ).ToList ();
                if (mlist.Count() != 0)
                {
                    TbMembers mem = new TbMembers();
                    mem = (from m in context.TbMembers where (m.Email == strEmail) && (m.Password == strPwd) && (m.Status == 2) select m).First();

                    mem.LogOn = true;
                    context.SaveChanges();
                }
                return mlist;
            }
        }

        /// <summary>
        /// validates a new registered user. returns a row of info about the validated user. 
        /// </summary>
        /// <param name="strEmail"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public List<ValidateNewRegisteredUserModel> ValidateNewRegisteredUser(string strEmail, int code)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {
                List<ValidateNewRegisteredUserModel> lst = (from m in context.TbMembers
                                                            join mp in context.TbMemberProfile on m.MemberId equals mp.MemberId
                                                            join mr in context.TbMembersRegistered on m.MemberId equals mr.MemberId
                                                            where (mr.MemberCodeId == code) && (m.Email == strEmail) && (m.Status == 1)
                                                            select new ValidateNewRegisteredUserModel()
                                                            {
                                                                memberId = m.MemberId.ToString(),
                                                                email = m.Email,
                                                                firstName = mp.FirstName,
                                                                lastName = mp.LastName,
                                                                passWord = m.Password,
                                                                userImage =mp.PicturePath 
                                                            }

                        ).ToList();

                if (lst.Count != 0) {
                   TbMembers mem = new TbMembers();
                    mem = (from z in context.TbMembers where z.MemberId == Convert.ToInt32(lst[0].memberId) select z).First();
                    mem.Status = 2;
                    context.SaveChanges();
                }

                return (lst);
            }
        }

        internal List<UserModel> FindByUniqueEmail(string strEmail)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {
                List<UserModel> lst = (from m in context.TbMembers
                                       join mp in context.TbMemberProfile on m.MemberId equals mp.MemberId
                                      //join mr in context.TbMembersRegistered on m.MemberId equals mr.MemberId
                                       where  m.Email == strEmail
                                       select new UserModel()
                                       {
                                           memberID = m.MemberId.ToString(),
                                           email = m.Email,
                                           picturepath = mp.PicturePath
                                       }

                       ).ToList();
                return lst;
            }
        }

        /// <summary>
        /// Creates the new user.
        /// </summary>
        /// <returns>The new user.</returns>
        /// <param name="firstName">First name.</param>
        /// <param name="lastName">Last name.</param>
        /// <param name="email">Email.</param>
        /// <param name="password">Password.</param>
        /// <param name="gender">Gender.</param>
        /// <param name="month">Month.</param>
        /// <param name="day">Day.</param>
        /// <param name="year">Year.</param>
        public int CreateNewUser(string firstName, string lastName, string email, string password, string gender, string month,
                                  string day, string year)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {
                {
                    var fName = new SqlParameter("@FirstName", firstName);
                    var lName = new SqlParameter("@LastName", lastName);
                    var em = new SqlParameter("@Email", email);
                    var pwd = new SqlParameter("@Password", password);
                    var gder = new SqlParameter("@Gender", gender);
                    var mth = new SqlParameter("@Month", month);
                    var da = new SqlParameter("@Day", day);
                    var yr = new SqlParameter("@Year", year);

                    var memberCode = new SqlParameter
                    {
                        ParameterName = "MemberCode",
                        SqlDbType = System.Data.SqlDbType.Int,
                        Direction = System.Data.ParameterDirection.Output
                    };

                    context.Database.ExecuteSqlCommand("EXEC spCreateNewUser @FirstName,@LastName ,@Email,@Password,@Gender,@Month,@Day,@Year,@MemberCode OUTPUT",
                                        fName, lName, em, pwd, gder, mth, da, yr, memberCode);

                    return ((int)memberCode.Value);
                }
            }
        }


        /// <summary>
        /// check to see if email exists -- everyone on here has a unique email address
        /// </summary>
        /// <param name="email"></param>
        /// <returns>return list if email exist</returns>
        public List<TbMembers> CheckEmailExists(string email)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {
                var mlist = (from m in context.TbMembers where (m.Email == email) select m).ToList();
                return mlist;
            }
        }

        /// <summary>
        /// get code and name for forgot passwords
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public List<CodeAndNameForgotPwdModel> GetCodeAndNameForgotPwd(string email)
        {

            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {
                List<CodeAndNameForgotPwdModel> bLST = new List<CodeAndNameForgotPwdModel>();

                var l = (from m in context.TbMembers
                         join mp in context.TbMemberProfile on m.MemberId equals mp.MemberId
                         where m.Email == email select mp).ToList();

                var memID = l[0].MemberId;
                var fName = l[0].FirstName;


                CodeAndNameForgotPwdModel lst = new CodeAndNameForgotPwdModel();
                if (memID != 0)
                {
                    TbForgotPwdCodes ins = new TbForgotPwdCodes();
                    ins.Email = email;
                    ins.CodeDate = System.DateTime.Now;
                    ins.Status = 0;

                    context.TbForgotPwdCodes.Add(ins);
                    context.SaveChanges();

                    lst.codeID = ins.CodeId.ToString ();
                    lst.firstName = fName;
                    bLST.Add(lst);
                }
                else {
                    lst.codeID = "0";
                    lst.firstName = "";
                    bLST.Add(lst);
                }
                return bLST ;
            } 
        }

        /// <summary>
        /// checked code expired
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public List<TbForgotPwdCodes> CheckCodeExpired(int code)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {
                var flist = (from f in context.TbForgotPwdCodes where (f.CodeId == code && f.Status == 0) select f).ToList();
                return flist;
            }
        }

        /// <summary>
        /// Set the code to expire 
        /// </summary>
        /// <param name="code"></param>
        public void SetCodeToExpire(int code)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {
                TbForgotPwdCodes fEdit = new TbForgotPwdCodes();
                fEdit = (from f in context.TbForgotPwdCodes where f.CodeId  == code select f).First();
                fEdit.Status = 1;
                context.SaveChanges();
            }
        }

        /// <summary>
        /// record log in user
        /// </summary>
        /// <param name="memberID"></param>
        public void RecordLogInUser(int memberID)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {
                var mId = new SqlParameter("@MemberID", memberID);
                context.Database.ExecuteSqlCommand("EXEC spLoggedInUser @MemberID",mId);
            }
        }

        /// <summary>
        /// delete or remove log in user -- logout
        /// </summary>
        /// <param name="memberID"></param>
        public void DeleteLogInUser(int memberID)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {
                var mId = new SqlParameter("@MemberID", memberID);
                context.Database.ExecuteSqlCommand("EXEC spDeleteLoggedInUser @MemberID", mId);               
            }
        }

        /// <summary>
        /// check to see if user is active
        /// </summary>
        /// <param name="memberID"></param>
        /// <returns></returns>
        public bool IsActiveUser(int memberID)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {
                var q = (from m in context.TbMembers where m.MemberId == memberID && m.Status == 2 select m).ToList();
                if (q.Count != 0)
                    return true;
                else
                    return false;
            }
        }

        /// <summary>
        /// Set status for member id - active, newregister, or inactive
        /// </summary>
        /// <param name="memberID"></param>
        /// <param name="status"></param>
        public void SetMemberStatus(int memberID, int status)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {
                TbMembers mEdit = new TbMembers();
                mEdit = (from m in context.TbMembers where m.MemberId == memberID select m).First();
                mEdit.Status = status;
                context.SaveChanges();
            }
        }

        /// <summary>
        /// check if user is logon
        /// </summary>
        /// <param name="memberID"></param>
        /// <returns></returns>
        public bool CheckIfUserIsLogOn(int memberID)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {
                var v = (from m in context.TbMembers where m.MemberId == memberID && m.LogOn == true select m);

                if (v.Count() != 0)
                    return true;
                else
                    return false;
            }
        }

        /// <summary>
        /// log off user
        /// </summary>
        /// <param name="memberID"></param>
        public void LogOffUser(int memberID)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {
                TbMembers mEdit = new TbMembers();
                mEdit = (from m in context.TbMembers where m.MemberId == memberID select m).First();
                mEdit.LogOn = false;
                context.SaveChanges();
            }
        }

    }
}