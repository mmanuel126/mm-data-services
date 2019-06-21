using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MM.DataServices.Models;
using MM.DataServices.Security;

namespace MM.DataServices.Controllers
{
    [Route("services/[controller]/[action]")]
    public class SettingController : Controller
    {
        private readonly SettingDataManager setMgr;

        public SettingController()
        {
            setMgr = new SettingDataManager();
        }

        /// <summary>
        /// Gets the member name information.
        /// </summary>
        /// <returns>The member name info.</returns>
        /// <param name="memberID">Member identifier.</param>
        [HttpGet]
        public List<MemberNameInfoModel> GetMemberNameInfo([FromQuery] int memberID)
        {
            return setMgr.GetMemberNameInfo(memberID);
        }

        /// <summary>
        /// Saves the member name info.
        /// </summary>
        /// <param name="memberID">Member identifier.</param>
        /// <param name="fName">First name.</param>
        /// <param name="mName">Middle name.</param>
        /// <param name="lName">Last name.</param>
        [HttpPut]
        public void SaveMemberNameInfo([FromQuery] int memberID, [FromQuery] string fName, [FromQuery] string mName, [FromQuery] string lName)
        {
            setMgr.SaveMemberNameInfo(memberID, fName, mName, lName);
        }

        /// <summary>
        /// Saves the member email information.
        /// </summary>
        /// <param name="memberID">Member identifier.</param>
        /// <param name="email">Email.</param>
        [HttpPut]
        public void SaveMemberEmailInfo([FromQuery] int memberID, [FromQuery] string email)
        {
            setMgr.SaveMemberEmailInfo(memberID, email);
        }

        /// <summary>
        /// Saves the password information.
        /// </summary>
        /// <param name="memberID">Member identifier.</param>
        /// <param name="pwd">Password.</param>
        [HttpPut]
        public void SavePasswordInfo([FromQuery] int memberID, [FromQuery] string pwd)
        {
            string mykey = "r0b1nr0y";
            pwd = EncryptStrings.Encrypt(pwd, mykey);
            setMgr.SavePasswordInfo(memberID, pwd);
        }

        /// <summary>
        /// Saves the security question info.
        /// </summary>
        /// <param name="memberID">Member identifier.</param>
        /// <param name="questionID">Question identifier.</param>
        /// <param name="answer">Answer.</param>
        [HttpPut]
        public void SaveSecurityQuestionInfo([FromQuery] int memberID, [FromQuery] int questionID, [FromQuery] string answer)
        {
            setMgr.SaveSecurityQuestionInfo(memberID, questionID, answer);
        }

        /// <summary>
        /// Deactivates the account.
        /// </summary>
        /// <param name="memberID">Member identifier.</param>
        /// <param name="reason">Reason.</param>
        /// <param name="explanation">Explanation.</param>
        /// <param name="futureEmail">Future email.</param>
        [HttpPut]
        public void DeactivateAccount([FromQuery] int memberID, [FromQuery] int reason, [FromQuery] string explanation, [FromQuery] bool? futureEmail)
        {
            setMgr.DeactivateAccount(memberID, reason, explanation, futureEmail);
        }

        /// <summary>
        /// Gets the member notifications.
        /// </summary>
        /// <returns>The member notifications.</returns>
        /// <param name="memberId">Member identifier.</param>
        [HttpGet]
        public List<NotificationsSettingModel> GetMemberNotifications([FromQuery] int memberId)
        {
            return setMgr.GetMemberNotifications(memberId);
        }

        /// <summary>
        /// Saves the notification settings.
        /// </summary>
        /// <param name="memberID">Member identifier.</param>
        /// <param name="body">Body.</param>
        [HttpPut]
        public void SaveNotificationSettings([FromQuery] int memberID, [FromBody] NotificationsSettingModel body)
        {

            setMgr.SaveNotificationSettings(memberID, body.LG_SendMsg, body.LG_AddAsFriend, body.LG_ConfirmFriendShipRequest,
                                           body.GP_InviteYouToJoin, body.GP_MakesYouAGPAdmin, body.GP_RepliesToYourDiscBooardPost,
                                           body.GP_ChangesTheNameOfGroupYouBelong, body.EV_InviteToEvent, body.EV_DateChanged,
                                           body.HE_RepliesToYourHelpQuest);

        }

        /// <summary>
        /// Gets the profile settings.
        /// </summary>
        /// <returns>The profile settings.</returns>
        /// <param name="memberID">Member identifier.</param>
        [HttpGet]
        public List<PrivacySearchSettingsModel> GetProfileSettings([FromQuery] int memberID)
        {
            return setMgr.GetProfileSettings(memberID);
        }

        /// <summary>
        /// Saves the profile settings.
        /// </summary>
        /// <param name="memberID">Member identifier.</param>
        /// <param name="body">Body.</param>
        [HttpPut]
        public void SaveProfileSettings([FromQuery] int memberID, [FromBody] PrivacySearchSettingsModel body)
        {
            setMgr.SaveProfileSettings(memberID, body);
        }

        /// <summary>
        /// Gets the privacy search settings.
        /// </summary>
        /// <returns>The privacy search settings.</returns>
        /// <param name="memberID">Member identifier.</param>
        [HttpGet]
        public List<PrivacySearchSettingsModel> GetPrivacySearchSettings([FromQuery]int memberID)
        {
            return setMgr.GetPrivacySearchSettings(memberID);
        }

        /// <summary>
        /// Saves the privacy search settings.
        /// </summary>
        /// <param name="memberID">Member identifier.</param>
        /// <param name="visibility">Visibility.</param>
        /// <param name="viewProfilePicture">If set to <c>true</c> view profile picture.</param>
        /// <param name="viewFriendsList">If set to <c>true</c> view friends list.</param>
        /// <param name="viewLinkToRequestAddingYouAsFriend">If set to <c>true</c> view link to request adding you as friend.</param>
        /// <param name="viewLinkToSendYouMsg">If set to <c>true</c> view link to send you message.</param>
        [HttpPut]
        public void SavePrivacySearchSettings(
              [FromQuery] int memberID,
              [FromQuery] int visibility,
              [FromQuery] bool viewProfilePicture,
              [FromQuery] bool viewFriendsList,
              [FromQuery] bool viewLinkToRequestAddingYouAsFriend,
              [FromQuery] bool viewLinkToSendYouMsg)
        {
            setMgr.SavePrivacySearchSettings(memberID, visibility, viewProfilePicture, viewFriendsList, viewLinkToRequestAddingYouAsFriend,
                                             viewLinkToSendYouMsg);
        }

    }
}
