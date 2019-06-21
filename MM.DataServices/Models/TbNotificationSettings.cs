using System;
using System.Collections.Generic;

namespace MM.DataServices.Models
{
    public partial class TbNotificationSettings
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public bool? LgSendMsg { get; set; }
        public bool? LgAddAsFriend { get; set; }
        public bool? LgConfirmFriendShipRequest { get; set; }
        public bool? LgPoking { get; set; }
        public bool? LgConfirmFriendDetails { get; set; }
        public bool? LgRequestToListAsFamily { get; set; }
        public bool? LgAddsFriendYouSuggest { get; set; }
        public bool? LgHasBirthDayComingUp { get; set; }
        public bool? PhTagInPhoto { get; set; }
        public bool? PhTagOneOfYourPhotos { get; set; }
        public bool? ViTagsInVideo { get; set; }
        public bool? ViTagsOneOfYourVideos { get; set; }
        public bool? ViCommentOnVideo { get; set; }
        public bool? ViCommentOnVideoOfYou { get; set; }
        public bool? ViCommentAfterYouInVideo { get; set; }
        public bool? GpInviteYouToJoin { get; set; }
        public bool? GpPromoteToAdmin { get; set; }
        public bool? GpMakesYouAgpadmin { get; set; }
        public bool? GpRequestToJoinGpyouAdmin { get; set; }
        public bool? GpRepliesToYourDiscBooardPost { get; set; }
        public bool? GpChangesTheNameOfGroupYouBelong { get; set; }
        public bool? EvInviteToEvent { get; set; }
        public bool? EvDateChanged { get; set; }
        public bool? EvMakeYouEventAdmin { get; set; }
        public bool? EvRequestToJoinEventYouAdmin { get; set; }
        public bool? NoTagsYouInNote { get; set; }
        public bool? NoCommentYourNotes { get; set; }
        public bool? NoCommentAfterYouInNote { get; set; }
        public bool? GiSendYouGift { get; set; }
        public bool? HeRepliesToYourHelpQuest { get; set; }

        public TbMembers Member { get; set; }
    }
}
