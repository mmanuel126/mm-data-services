using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MM.DataServices.Models
{
    public partial class DB_9B0E5C_linkedglobeContext : DbContext
    {
        public DB_9B0E5C_linkedglobeContext()
        {
        }

        public DB_9B0E5C_linkedglobeContext(DbContextOptions<DB_9B0E5C_linkedglobeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbActivityType> TbActivityType { get; set; }
        public virtual DbSet<TbAlbumPhotos> TbAlbumPhotos { get; set; }
        public virtual DbSet<TbAlbums> TbAlbums { get; set; }
        public virtual DbSet<TbCaliPublicSchools> TbCaliPublicSchools { get; set; }
        public virtual DbSet<TbChatMessages> TbChatMessages { get; set; }
        public virtual DbSet<TbChatRoom> TbChatRoom { get; set; }
        public virtual DbSet<TbColleges> TbColleges { get; set; }
        public virtual DbSet<TbCompanies> TbCompanies { get; set; }
        public virtual DbSet<TbCompaniesOfInterest> TbCompaniesOfInterest { get; set; }
        public virtual DbSet<TbContactRequests> TbContactRequests { get; set; }
        public virtual DbSet<TbContacts> TbContacts { get; set; }
        public virtual DbSet<TbDegreeType> TbDegreeType { get; set; }
        public virtual DbSet<TbDiscussionTopicPosts> TbDiscussionTopicPosts { get; set; }
        public virtual DbSet<TbEventInvites> TbEventInvites { get; set; }
        public virtual DbSet<TbEventPosts> TbEventPosts { get; set; }
        public virtual DbSet<TbEvents> TbEvents { get; set; }
        public virtual DbSet<TbEventTimes> TbEventTimes { get; set; }
        public virtual DbSet<TbForgotPwdCodes> TbForgotPwdCodes { get; set; }
        public virtual DbSet<TbInterests> TbInterests { get; set; }
        public virtual DbSet<TbIssues> TbIssues { get; set; }
        public virtual DbSet<TbJobApplicants> TbJobApplicants { get; set; }
        public virtual DbSet<TbJobExperienceLevel> TbJobExperienceLevel { get; set; }
        public virtual DbSet<TbJobFunctions> TbJobFunctions { get; set; }
        public virtual DbSet<TbJobs> TbJobs { get; set; }
        public virtual DbSet<TbJobsToFollow> TbJobsToFollow { get; set; }
        public virtual DbSet<TbLinks> TbLinks { get; set; }
        public virtual DbSet<TbLoggedInUser> TbLoggedInUser { get; set; }
        public virtual DbSet<TbMajors> TbMajors { get; set; }
        public virtual DbSet<TbMemberNotifications> TbMemberNotifications { get; set; }
        public virtual DbSet<TbMemberPostResponses> TbMemberPostResponses { get; set; }
        public virtual DbSet<TbMemberPosts> TbMemberPosts { get; set; }
        public virtual DbSet<TbMemberProfile> TbMemberProfile { get; set; }
        public virtual DbSet<TbMemberProfileContactInfo> TbMemberProfileContactInfo { get; set; }
        public virtual DbSet<TbMemberProfileEducation> TbMemberProfileEducation { get; set; }
        public virtual DbSet<TbMemberProfileEducationV2> TbMemberProfileEducationV2 { get; set; }
        public virtual DbSet<TbMemberProfileEmploymentInfo> TbMemberProfileEmploymentInfo { get; set; }
        public virtual DbSet<TbMemberProfileEmploymentInfoV2> TbMemberProfileEmploymentInfoV2 { get; set; }
        public virtual DbSet<TbMemberProfilePersonalInfo> TbMemberProfilePersonalInfo { get; set; }
        public virtual DbSet<TbMemberProfilePictures> TbMemberProfilePictures { get; set; }
        public virtual DbSet<TbMembers> TbMembers { get; set; }
        public virtual DbSet<TbMembersPrivacySettings> TbMembersPrivacySettings { get; set; }
        public virtual DbSet<TbMembersRecentActivities> TbMembersRecentActivities { get; set; }
        public virtual DbSet<TbMembersRegistered> TbMembersRegistered { get; set; }
        public virtual DbSet<TbMessages> TbMessages { get; set; }
        public virtual DbSet<TbMessagesDeleted> TbMessagesDeleted { get; set; }
        public virtual DbSet<TbMessagesJunk> TbMessagesJunk { get; set; }
        public virtual DbSet<TbMessagesReplies> TbMessagesReplies { get; set; }
        public virtual DbSet<TbMessagesSent> TbMessagesSent { get; set; }
        public virtual DbSet<TbNetworkCategory> TbNetworkCategory { get; set; }
        public virtual DbSet<TbNetworkCategoryType> TbNetworkCategoryType { get; set; }
        public virtual DbSet<TbNetworkDiscussionTopics> TbNetworkDiscussionTopics { get; set; }
        public virtual DbSet<TbNetworkMemberInvites> TbNetworkMemberInvites { get; set; }
        public virtual DbSet<TbNetworkMembers> TbNetworkMembers { get; set; }
        public virtual DbSet<TbNetworkPhotos> TbNetworkPhotos { get; set; }
        public virtual DbSet<TbNetworkPostResponses> TbNetworkPostResponses { get; set; }
        public virtual DbSet<TbNetworkPosts> TbNetworkPosts { get; set; }
        public virtual DbSet<TbNetworkRecentActivities> TbNetworkRecentActivities { get; set; }
        public virtual DbSet<TbNetworkRequests> TbNetworkRequests { get; set; }
        public virtual DbSet<TbNetworks> TbNetworks { get; set; }
        public virtual DbSet<TbNetworkSettings> TbNetworkSettings { get; set; }
        public virtual DbSet<TbNetworkVideos> TbNetworkVideos { get; set; }
        public virtual DbSet<TbNoteCommentPosts> TbNoteCommentPosts { get; set; }
        public virtual DbSet<TbNotes> TbNotes { get; set; }
        public virtual DbSet<TbNotifications> TbNotifications { get; set; }
        public virtual DbSet<TbNotificationSettings> TbNotificationSettings { get; set; }
        public virtual DbSet<TbPollAnswers> TbPollAnswers { get; set; }
        public virtual DbSet<TbPolls> TbPolls { get; set; }
        public virtual DbSet<TbPrivateSchools> TbPrivateSchools { get; set; }
        public virtual DbSet<TbPublcSchoolDisctricts> TbPublcSchoolDisctricts { get; set; }
        public virtual DbSet<TbPublicLibraries> TbPublicLibraries { get; set; }
        public virtual DbSet<TbPublicSchools> TbPublicSchools { get; set; }
        public virtual DbSet<TbRecentNews> TbRecentNews { get; set; }
        public virtual DbSet<TbResumeSettings> TbResumeSettings { get; set; }
        public virtual DbSet<TbSchoolsIlike> TbSchoolsIlike { get; set; }
        public virtual DbSet<TbSchoolType> TbSchoolType { get; set; }
        public virtual DbSet<TbStates> TbStates { get; set; }
        public virtual DbSet<TbSuggestions> TbSuggestions { get; set; }
        public virtual DbSet<TbUserResponses> TbUserResponses { get; set; }
        public virtual DbSet<TbVideoCategory> TbVideoCategory { get; set; }
        public virtual DbSet<TbVideos> TbVideos { get; set; }

        // Unable to generate entity type for table 'dbo.tbYears'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.tbDays'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.tbMonths'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.companylist'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.companylist$'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.tbNetworkRegulators'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.tbMembersBlocked'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.tbNetworkMemberRequests'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=SQL5002.site4now.net;Initial Catalog=DB_9B0E5C_linkedglobe;User Id=DB_9B0E5C_linkedglobe_admin;Password=Jordan360;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbActivityType>(entity =>
            {
                entity.HasKey(e => e.ActivityTypeId);

                entity.ToTable("tbActivityType");

                entity.Property(e => e.ActivityTypeId)
                    .HasColumnName("ActivityTypeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ActivityTypeDesc)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ImageFile)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbAlbumPhotos>(entity =>
            {
                entity.HasKey(e => e.PhotoId);

                entity.ToTable("tbAlbumPhotos");

                entity.Property(e => e.PhotoId).HasColumnName("PhotoID");

                entity.Property(e => e.AlbumId).HasColumnName("AlbumID");

                entity.Property(e => e.FileName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhotoDesc)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PhotoName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Removed).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Album)
                    .WithMany(p => p.TbAlbumPhotos)
                    .HasForeignKey(d => d.AlbumId)
                    .HasConstraintName("FK_tbAlbumPhotos_tbAlbums");
            });

            modelBuilder.Entity<TbAlbums>(entity =>
            {
                entity.HasKey(e => e.AlbumId);

                entity.ToTable("tbAlbums");

                entity.Property(e => e.AlbumId).HasColumnName("AlbumID");

                entity.Property(e => e.AlbumName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Location)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.Removed).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.TbAlbums)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_tbAlbums_tbMembers");
            });

            modelBuilder.Entity<TbCaliPublicSchools>(entity =>
            {
                entity.HasKey(e => e.Lgid);

                entity.ToTable("tbCaliPublicSchools");

                entity.Property(e => e.Lgid).HasColumnName("LGID");

                entity.Property(e => e.Charter)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CountryName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.District)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DistrictId)
                    .HasColumnName("DistrictID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HighGrade)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Image)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LocalCode)
                    .HasColumnName("localCode")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Locale)
                    .HasColumnName("locale")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LowGrade)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Magnet)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SchoolId)
                    .HasColumnName("SchoolID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SchoolName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StateDistrict)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StateSchoolId)
                    .HasColumnName("StateSchoolID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StreetName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Title1SchoolWide)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Titlle1School)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Zip)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Zip4Digit)
                    .HasMaxLength(4)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbChatMessages>(entity =>
            {
                entity.HasKey(e => e.MessageId);

                entity.ToTable("tbChatMessages");

                entity.Property(e => e.MessageId).HasColumnName("MessageID");

                entity.Property(e => e.Color)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.Property(e => e.Text)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.TimeStamp).HasColumnType("datetime");

                entity.Property(e => e.ToUserId).HasColumnName("ToUserID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.TbChatMessages)
                    .HasForeignKey(d => d.RoomId)
                    .HasConstraintName("FK_tbChatMessages_tbChatRoom");

                entity.HasOne(d => d.ToUser)
                    .WithMany(p => p.TbChatMessagesToUser)
                    .HasForeignKey(d => d.ToUserId)
                    .HasConstraintName("FK_tbChatMessages_tbMembers");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TbChatMessagesUser)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_tbChatMessages_tbMembers1");
            });

            modelBuilder.Entity<TbChatRoom>(entity =>
            {
                entity.HasKey(e => e.RoomId);

                entity.ToTable("tbChatRoom");

                entity.Property(e => e.RoomId)
                    .HasColumnName("RoomID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Responded).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<TbColleges>(entity =>
            {
                entity.HasKey(e => e.SchoolId);

                entity.ToTable("tbColleges");

                entity.Property(e => e.SchoolId).HasColumnName("SchoolID");

                entity.Property(e => e.Address)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.AwardsOffered)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CampusHousing)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.CampusSetting)
                    .HasMaxLength(90)
                    .IsUnicode(false);

                entity.Property(e => e.ImageFile)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ipedsid)
                    .HasColumnName("IPEDSID")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Opeid)
                    .HasColumnName("OPEID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.StudentToFacultyRatio)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Website)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbCompanies>(entity =>
            {
                entity.ToTable("tbCompanies");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ImageFile)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Industry)
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.Ipoyear)
                    .HasColumnName("IPOYear")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Sector)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.SummaryQuote)
                    .HasColumnName("summaryQuote")
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.Symbol)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Website)
                    .HasColumnName("website")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbCompaniesOfInterest>(entity =>
            {
                entity.HasKey(e => new { e.CompInterestId, e.CompanyId });

                entity.ToTable("tbCompaniesOfInterest");

                entity.Property(e => e.CompInterestId)
                    .HasColumnName("CompInterestID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.MemberId).HasColumnName("MemberID");
            });

            modelBuilder.Entity<TbContactRequests>(entity =>
            {
                entity.HasKey(e => e.RequestId);

                entity.ToTable("tbContactRequests");

                entity.Property(e => e.RequestId).HasColumnName("RequestID");

                entity.Property(e => e.FromMemberId).HasColumnName("FromMemberID");

                entity.Property(e => e.RequestDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Status).HasDefaultValueSql("((0))");

                entity.Property(e => e.ToMemberId).HasColumnName("ToMemberID");

                entity.HasOne(d => d.FromMember)
                    .WithMany(p => p.TbContactRequestsFromMember)
                    .HasForeignKey(d => d.FromMemberId)
                    .HasConstraintName("FK_tbContactRequests_tbMembers");

                entity.HasOne(d => d.ToMember)
                    .WithMany(p => p.TbContactRequestsToMember)
                    .HasForeignKey(d => d.ToMemberId)
                    .HasConstraintName("FK_tbContactRequests_tbMembers1");
            });

            modelBuilder.Entity<TbContacts>(entity =>
            {
                entity.HasKey(e => new { e.MemberId, e.ContactId });

                entity.ToTable("tbContacts");

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.ContactId).HasColumnName("ContactID");

                entity.Property(e => e.DateStamp)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.TbContactsContact)
                    .HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbContacts_tbMembers1");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.TbContactsMember)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbContacts_tbMembers");
            });

            modelBuilder.Entity<TbDegreeType>(entity =>
            {
                entity.HasKey(e => e.DegreeTypeId);

                entity.ToTable("tbDegreeType");

                entity.Property(e => e.DegreeTypeId)
                    .HasColumnName("DegreeTypeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DegreeTypeDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbDiscussionTopicPosts>(entity =>
            {
                entity.HasKey(e => e.PostId);

                entity.ToTable("tbDiscussionTopicPosts");

                entity.Property(e => e.PostId).HasColumnName("PostID");

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.PostDate).HasColumnType("datetime");

                entity.Property(e => e.PostDesc)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.TopicId).HasColumnName("TopicID");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.TbDiscussionTopicPosts)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_tbDiscussionTopicPosts_tbMembers");
            });

            modelBuilder.Entity<TbEventInvites>(entity =>
            {
                entity.HasKey(e => e.InviteId);

                entity.ToTable("tbEventInvites");

                entity.Property(e => e.InviteId).HasColumnName("InviteID");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EventId).HasColumnName("EventID");

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.Rsvpstatus)
                    .HasColumnName("RSVPStatus")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Attending')");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.TbEventInvites)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK_tbEventInvites_tbEvents");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.TbEventInvites)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_tbEventInvites_tbMembers");
            });

            modelBuilder.Entity<TbEventPosts>(entity =>
            {
                entity.HasKey(e => e.PostId);

                entity.ToTable("tbEventPosts");

                entity.Property(e => e.PostId).HasColumnName("PostID");

                entity.Property(e => e.AttachFile)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(700)
                    .IsUnicode(false);

                entity.Property(e => e.EventId).HasColumnName("EventID");

                entity.Property(e => e.FileType).HasDefaultValueSql("((0))");

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.PostDate).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.TbEventPosts)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK_tbEventPosts_tbEvents");
            });

            modelBuilder.Entity<TbEvents>(entity =>
            {
                entity.HasKey(e => e.EventId);

                entity.ToTable("tbEvents");

                entity.Property(e => e.EventId).HasColumnName("EventID");

                entity.Property(e => e.AnyoneCanViewRsvp).HasColumnName("AnyoneCanViewRSVP");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.EndEndTime)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EndTime)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EventImg)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.Location)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.MoreInfo)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NetworkId).HasColumnName("NetworkID");

                entity.Property(e => e.PlanningWhat)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.StartEndTime)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StartTime)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Street)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Zip)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.TbEvents)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_tbEvents_tbMembers");

                entity.HasOne(d => d.Network)
                    .WithMany(p => p.TbEvents)
                    .HasForeignKey(d => d.NetworkId)
                    .HasConstraintName("FK_tbEvents_tbNetworks");
            });

            modelBuilder.Entity<TbEventTimes>(entity =>
            {
                entity.HasKey(e => e.TimeId);

                entity.ToTable("tbEventTimes");

                entity.Property(e => e.TimeId)
                    .HasColumnName("TimeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbForgotPwdCodes>(entity =>
            {
                entity.HasKey(e => e.CodeId);

                entity.ToTable("tbForgotPwdCodes");

                entity.Property(e => e.CodeId).HasColumnName("CodeID");

                entity.Property(e => e.CodeDate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbInterests>(entity =>
            {
                entity.HasKey(e => e.InterestId);

                entity.ToTable("tbInterests");

                entity.Property(e => e.InterestId).HasColumnName("InterestID");

                entity.Property(e => e.InterestDesc)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbIssues>(entity =>
            {
                entity.HasKey(e => e.IssueId);

                entity.ToTable("tbIssues");

                entity.Property(e => e.IssueId).HasColumnName("IssueID");

                entity.Property(e => e.Description)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.Subject)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbJobApplicants>(entity =>
            {
                entity.HasKey(e => new { e.AppJobId, e.MemberId, e.PostId });

                entity.ToTable("tbJobApplicants");

                entity.Property(e => e.AppJobId)
                    .HasColumnName("AppJobID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.PostId).HasColumnName("PostID");

                entity.Property(e => e.AppliedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbJobExperienceLevel>(entity =>
            {
                entity.HasKey(e => e.ExperienceId);

                entity.ToTable("tbJobExperienceLevel");

                entity.Property(e => e.ExperienceId)
                    .HasColumnName("ExperienceID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ExperienceDesc)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbJobFunctions>(entity =>
            {
                entity.HasKey(e => e.FunctionId);

                entity.ToTable("tbJobFunctions");

                entity.Property(e => e.FunctionId)
                    .HasColumnName("FunctionID")
                    .ValueGeneratedNever();

                entity.Property(e => e.FunctionDesc)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbJobs>(entity =>
            {
                entity.HasKey(e => e.PostId);

                entity.ToTable("tbJobs");

                entity.Property(e => e.PostId).HasColumnName("PostID");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Company)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Compensation)
                    .HasMaxLength(170)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DatePosted)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ExperienceType)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Industry)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.JobDescription).HasColumnType("text");

                entity.Property(e => e.JobFunction)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.JobTitle)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.JobType)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.PostMemberId).HasColumnName("PostMemberID");

                entity.Property(e => e.ReferralBonus)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Sector)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.SkillsExperience).HasColumnType("text");

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WebSite)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbJobsToFollow>(entity =>
            {
                entity.HasKey(e => new { e.JobFollowId, e.PostId, e.MemberId });

                entity.ToTable("tbJobsToFollow");

                entity.Property(e => e.JobFollowId)
                    .HasColumnName("JobFollowID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.PostId).HasColumnName("PostID");

                entity.Property(e => e.MemberId).HasColumnName("MemberID");
            });

            modelBuilder.Entity<TbLinks>(entity =>
            {
                entity.HasKey(e => e.LinkId);

                entity.ToTable("tbLinks");

                entity.Property(e => e.LinkId).HasColumnName("LinkID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.OwnerId).HasColumnName("OwnerID");

                entity.Property(e => e.PrivacyType).HasDefaultValueSql("((0))");

                entity.Property(e => e.ThumbNail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.TbLinks)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("FK_tbLinks_tbMembers");
            });

            modelBuilder.Entity<TbLoggedInUser>(entity =>
            {
                entity.HasKey(e => e.LoggedInUserId);

                entity.ToTable("tbLoggedInUser");

                entity.Property(e => e.LoggedInUserId).HasColumnName("LoggedInUserID");

                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.TbLoggedInUser)
                    .HasForeignKey(d => d.RoomId)
                    .HasConstraintName("FK_tbLoggedInUser_tbChatRoom");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TbLoggedInUser)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_tbLoggedInUser_tbMembers");
            });

            modelBuilder.Entity<TbMajors>(entity =>
            {
                entity.HasKey(e => e.MajorId);

                entity.ToTable("tbMajors");

                entity.Property(e => e.MajorId).HasColumnName("MajorID");

                entity.Property(e => e.MajorDesc)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbMemberNotifications>(entity =>
            {
                entity.HasKey(e => new { e.NotificationMemberId, e.MemberId, e.NotificationId });

                entity.ToTable("tbMemberNotifications");

                entity.Property(e => e.NotificationMemberId)
                    .HasColumnName("NotificationMemberID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.NotificationId).HasColumnName("NotificationID");
            });

            modelBuilder.Entity<TbMemberPostResponses>(entity =>
            {
                entity.HasKey(e => e.PostResponseId);

                entity.ToTable("tbMemberPostResponses");

                entity.Property(e => e.PostResponseId).HasColumnName("PostResponseID");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.PostId).HasColumnName("PostID");

                entity.Property(e => e.ResponseDate).HasColumnType("datetime");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.TbMemberPostResponses)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_tbMemberPostResponses_tbMembers");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.TbMemberPostResponses)
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("FK_tbMemberPostResponses_tbMemberPosts");
            });

            modelBuilder.Entity<TbMemberPosts>(entity =>
            {
                entity.HasKey(e => e.PostId);

                entity.ToTable("tbMemberPosts");

                entity.Property(e => e.PostId).HasColumnName("PostID");

                entity.Property(e => e.AttachFile)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(700)
                    .IsUnicode(false);

                entity.Property(e => e.FileType).HasDefaultValueSql("((0))");

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.PostDate).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.TbMemberPosts)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_tbMemberPosts_tbMembers");
            });

            modelBuilder.Entity<TbMemberProfile>(entity =>
            {
                entity.HasKey(e => e.MemberId);

                entity.ToTable("tbMemberProfile");

                entity.Property(e => e.MemberId)
                    .HasColumnName("MemberID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CurrentCity)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Dobday)
                    .HasColumnName("DOBDay")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Dobmonth)
                    .HasColumnName("DOBMonth")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Dobyear)
                    .HasColumnName("DOBYear")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HomeNeighborhood)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Hometown)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Industry)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.JoinedDate).HasColumnType("datetime");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PicturePath)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.PoliticalView)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ReligiousView)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Sector)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Sex)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ShowDobtype).HasColumnName("ShowDOBType");

                entity.Property(e => e.TitleDesc)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.Member)
                    .WithOne(p => p.TbMemberProfile)
                    .HasForeignKey<TbMemberProfile>(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbMemberProfile_tbMembers");
            });

            modelBuilder.Entity<TbMemberProfileContactInfo>(entity =>
            {
                entity.HasKey(e => e.MemberId);

                entity.ToTable("tbMemberProfileContactInfo");

                entity.Property(e => e.MemberId)
                    .HasColumnName("MemberID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CellPhone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.HomePhone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ImdisplayName)
                    .HasColumnName("IMDisplayName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ImserviceType).HasColumnName("IMServiceType");

                entity.Property(e => e.Neighborhood)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OtherEmail)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OtherPhone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WebSiteLinks)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Zip)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Member)
                    .WithOne(p => p.TbMemberProfileContactInfo)
                    .HasForeignKey<TbMemberProfileContactInfo>(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbMemberProfileContactInfo_tbMembers");
            });

            modelBuilder.Entity<TbMemberProfileEducation>(entity =>
            {
                entity.HasKey(e => e.MemberId);

                entity.ToTable("tbMemberProfileEducation");

                entity.Property(e => e.MemberId)
                    .HasColumnName("MemberID")
                    .ValueGeneratedNever();

                entity.Property(e => e.College1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.College1ClassYear)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.College1Major)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.College1Societies)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.College2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.College2ClassYear)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.College2Major)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.College2Societies)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.HighSchool)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HighSchoolClassYear)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Member)
                    .WithOne(p => p.TbMemberProfileEducation)
                    .HasForeignKey<TbMemberProfileEducation>(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbMemberProfileEducation_tbMembers");
            });

            modelBuilder.Entity<TbMemberProfileEducationV2>(entity =>
            {
                entity.HasKey(e => new { e.MemberId, e.SchoolId, e.SchoolType });

                entity.ToTable("tbMemberProfileEducationV2");

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.SchoolId).HasColumnName("SchoolID");

                entity.Property(e => e.ClassYear)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Major)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SchoolName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Societies)
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbMemberProfileEmploymentInfo>(entity =>
            {
                entity.HasKey(e => e.MemberId);

                entity.ToTable("tbMemberProfileEmploymentInfo");

                entity.Property(e => e.MemberId)
                    .HasColumnName("MemberID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Emp1City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Emp1EndMonth)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Emp1EndYear)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Emp1JobDesc)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Emp1Position)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Emp1StartMonth)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Emp1StartYear)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Emp1State)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Emp2City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Emp2EndMonth)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Emp2EndYear)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Emp2JobDesc)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Emp2Position)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Emp2StartMonth)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Emp2StartYear)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Emp2State)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Emp3City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Emp3EndMonth)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Emp3EndYear)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Emp3JobDesc)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Emp3Position)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Emp3StartMonth)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Emp3StartYear)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Emp3State)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Employer1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Employer2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Employer3)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Member)
                    .WithOne(p => p.TbMemberProfileEmploymentInfo)
                    .HasForeignKey<TbMemberProfileEmploymentInfo>(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbMemberProfileEmploymentInfo_tbMembers");
            });

            modelBuilder.Entity<TbMemberProfileEmploymentInfoV2>(entity =>
            {
                entity.HasKey(e => e.EmpInfoId);

                entity.ToTable("tbMemberProfileEmploymentInfoV2");

                entity.Property(e => e.EmpInfoId).HasColumnName("EmpInfoID");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EndMonth)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.EndYear)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.JobDesc)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.Position)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.StartMonth)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.StartYear)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbMemberProfilePersonalInfo>(entity =>
            {
                entity.HasKey(e => e.MemberId);

                entity.ToTable("tbMemberProfilePersonalInfo");

                entity.Property(e => e.MemberId)
                    .HasColumnName("MemberID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AboutMe).HasColumnType("text");

                entity.Property(e => e.Activities).HasColumnType("text");

                entity.Property(e => e.FavoriteBooks).HasColumnType("text");

                entity.Property(e => e.FavoriteMovies).HasColumnType("text");

                entity.Property(e => e.FavoriteMusic).HasColumnType("text");

                entity.Property(e => e.FavoriteQuotations).HasColumnType("text");

                entity.Property(e => e.FavoriteTvshows)
                    .HasColumnName("FavoriteTVShows")
                    .HasColumnType("text");

                entity.Property(e => e.Interests).HasColumnType("text");

                entity.Property(e => e.SpecialSkills).HasColumnType("text");

                entity.HasOne(d => d.Member)
                    .WithOne(p => p.TbMemberProfilePersonalInfo)
                    .HasForeignKey<TbMemberProfilePersonalInfo>(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbMemberProfilePersonalInfo_tbMembers");
            });

            modelBuilder.Entity<TbMemberProfilePictures>(entity =>
            {
                entity.HasKey(e => new { e.ProfileId, e.MemberId });

                entity.ToTable("tbMemberProfilePictures");

                entity.Property(e => e.ProfileId)
                    .HasColumnName("ProfileID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.FileName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbMembers>(entity =>
            {
                entity.HasKey(e => e.MemberId);

                entity.ToTable("tbMembers");

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.ChatStatus).HasDefaultValueSql("((1))");

                entity.Property(e => e.DeactivateExplanation)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LogOn).HasDefaultValueSql("((0))");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SecurityAnswer)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbMembersPrivacySettings>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.MemberId });

                entity.ToTable("tbMembersPrivacySettings");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.BasicInfo).HasDefaultValueSql("((3))");

                entity.Property(e => e.ContactInfo).HasDefaultValueSql("((3))");

                entity.Property(e => e.Education).HasDefaultValueSql("((3))");

                entity.Property(e => e.EmailAddress).HasDefaultValueSql("((3))");

                entity.Property(e => e.ImdisplayName)
                    .HasColumnName("IMDisplayName")
                    .HasDefaultValueSql("((3))");

                entity.Property(e => e.MobilePhone).HasDefaultValueSql("((3))");

                entity.Property(e => e.OtherPhone).HasDefaultValueSql("((3))");

                entity.Property(e => e.PersonalInfo).HasDefaultValueSql("((3))");

                entity.Property(e => e.PhotosTagOfYou).HasDefaultValueSql("((3))");

                entity.Property(e => e.Profile).HasDefaultValueSql("((3))");

                entity.Property(e => e.VideosTagOfYou).HasDefaultValueSql("((3))");

                entity.Property(e => e.ViewFriendsList).HasDefaultValueSql("((1))");

                entity.Property(e => e.ViewLinkToRequestAddingYouAsFriend).HasDefaultValueSql("((1))");

                entity.Property(e => e.ViewLinkToSendYouMsg).HasDefaultValueSql("((1))");

                entity.Property(e => e.ViewProfilePicture).HasDefaultValueSql("((1))");

                entity.Property(e => e.Visibility).HasDefaultValueSql("((1))");

                entity.Property(e => e.WorkInfo).HasDefaultValueSql("((3))");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.TbMembersPrivacySettings)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbMembersPrivacySettings_tbMembers");
            });

            modelBuilder.Entity<TbMembersRecentActivities>(entity =>
            {
                entity.HasKey(e => e.ActivityId);

                entity.ToTable("tbMembersRecentActivities");

                entity.Property(e => e.ActivityId).HasColumnName("ActivityID");

                entity.Property(e => e.ActivityDate).HasColumnType("datetime");

                entity.Property(e => e.ActivityTypeId).HasColumnName("ActivityTypeID");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.HasOne(d => d.ActivityType)
                    .WithMany(p => p.TbMembersRecentActivities)
                    .HasForeignKey(d => d.ActivityTypeId)
                    .HasConstraintName("FK_tbMembersRecentActivities_tbActivityType");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.TbMembersRecentActivities)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_tbMembersRecentActivities_tbMembers");
            });

            modelBuilder.Entity<TbMembersRegistered>(entity =>
            {
                entity.HasKey(e => new { e.MemberCodeId, e.MemberId });

                entity.ToTable("tbMembersRegistered");

                entity.Property(e => e.MemberCodeId)
                    .HasColumnName("MemberCodeID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.RegisteredDate).HasColumnType("datetime");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.TbMembersRegistered)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbMembersRegistered_tbMembers");
            });

            modelBuilder.Entity<TbMessages>(entity =>
            {
                entity.HasKey(e => e.MessageId);

                entity.ToTable("tbMessages");

                entity.Property(e => e.MessageId).HasColumnName("MessageID");

                entity.Property(e => e.AttachmentFile)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Body)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ContactId).HasColumnName("ContactID");

                entity.Property(e => e.MsgDate).HasColumnType("datetime");

                entity.Property(e => e.OriginalMsg).IsUnicode(false);

                entity.Property(e => e.SenderId).HasColumnName("SenderID");

                entity.Property(e => e.Source)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Subject)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.TbMessagesContact)
                    .HasForeignKey(d => d.ContactId)
                    .HasConstraintName("FK_tbMessages_tbMembers1");

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.TbMessagesSender)
                    .HasForeignKey(d => d.SenderId)
                    .HasConstraintName("FK_tbMessages_tbMembers");
            });

            modelBuilder.Entity<TbMessagesDeleted>(entity =>
            {
                entity.HasKey(e => e.MessageId);

                entity.ToTable("tbMessagesDeleted");

                entity.Property(e => e.MessageId)
                    .HasColumnName("MessageID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AttachmentFile)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Body)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ContactId).HasColumnName("ContactID");

                entity.Property(e => e.MsgDate).HasColumnType("datetime");

                entity.Property(e => e.OriginalMsg).IsUnicode(false);

                entity.Property(e => e.SenderId).HasColumnName("SenderID");

                entity.Property(e => e.Source)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Subject)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.TbMessagesDeletedContact)
                    .HasForeignKey(d => d.ContactId)
                    .HasConstraintName("FK_tbMessagesDeleted_tbMembers1");

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.TbMessagesDeletedSender)
                    .HasForeignKey(d => d.SenderId)
                    .HasConstraintName("FK_tbMessagesDeleted_tbMembers");
            });

            modelBuilder.Entity<TbMessagesJunk>(entity =>
            {
                entity.HasKey(e => e.MessageId);

                entity.ToTable("tbMessagesJunk");

                entity.Property(e => e.MessageId)
                    .HasColumnName("MessageID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AttachmentFile)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Body)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ContactId).HasColumnName("ContactID");

                entity.Property(e => e.MsgDate).HasColumnType("datetime");

                entity.Property(e => e.OriginalMsg).IsUnicode(false);

                entity.Property(e => e.SenderId).HasColumnName("SenderID");

                entity.Property(e => e.Source)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Subject)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.TbMessagesJunkContact)
                    .HasForeignKey(d => d.ContactId)
                    .HasConstraintName("FK_tbMessagesJunk_tbMembers1");

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.TbMessagesJunkSender)
                    .HasForeignKey(d => d.SenderId)
                    .HasConstraintName("FK_tbMessagesJunk_tbMembers");
            });

            modelBuilder.Entity<TbMessagesReplies>(entity =>
            {
                entity.HasKey(e => e.ReplyId);

                entity.ToTable("tbMessagesReplies");

                entity.Property(e => e.ReplyId).HasColumnName("ReplyID");

                entity.Property(e => e.AttachmentFile)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Body)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ContactId).HasColumnName("ContactID");

                entity.Property(e => e.MessageId).HasColumnName("MessageID");

                entity.Property(e => e.MsgDate).HasColumnType("datetime");

                entity.Property(e => e.SenderId).HasColumnName("SenderID");

                entity.Property(e => e.Source)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Subject)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.TbMessagesRepliesContact)
                    .HasForeignKey(d => d.ContactId)
                    .HasConstraintName("FK_tbMessagesReplies_tbMembers1");

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.TbMessagesRepliesSender)
                    .HasForeignKey(d => d.SenderId)
                    .HasConstraintName("FK_tbMessagesReplies_tbMembers");
            });

            modelBuilder.Entity<TbMessagesSent>(entity =>
            {
                entity.HasKey(e => e.MessageId);

                entity.ToTable("tbMessagesSent");

                entity.Property(e => e.MessageId).HasColumnName("MessageID");

                entity.Property(e => e.AttachmentFile)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Body)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ContactId).HasColumnName("ContactID");

                entity.Property(e => e.MsgDate).HasColumnType("datetime");

                entity.Property(e => e.OriginalMsg).IsUnicode(false);

                entity.Property(e => e.SenderId).HasColumnName("SenderID");

                entity.Property(e => e.Source)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Subject)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.TbMessagesSentContact)
                    .HasForeignKey(d => d.ContactId)
                    .HasConstraintName("FK_tbMessagesSent_tbMembers1");

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.TbMessagesSentSender)
                    .HasForeignKey(d => d.SenderId)
                    .HasConstraintName("FK_tbMessagesSent_tbMembers");
            });

            modelBuilder.Entity<TbNetworkCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.ToTable("tbNetworkCategory");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbNetworkCategoryType>(entity =>
            {
                entity.HasKey(e => e.CategoryTypeId);

                entity.ToTable("tbNetworkCategoryType");

                entity.Property(e => e.CategoryTypeId).HasColumnName("CategoryTypeID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbNetworkDiscussionTopics>(entity =>
            {
                entity.HasKey(e => e.TopicId);

                entity.ToTable("tbNetworkDiscussionTopics");

                entity.Property(e => e.TopicId).HasColumnName("TopicID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.NetworkId).HasColumnName("NetworkID");

                entity.Property(e => e.TopicDesc)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.TbNetworkDiscussionTopics)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_tbNetworkDiscussionTopics_tbMembers");

                entity.HasOne(d => d.Network)
                    .WithMany(p => p.TbNetworkDiscussionTopics)
                    .HasForeignKey(d => d.NetworkId)
                    .HasConstraintName("FK_tbNetworkDiscussionTopics_tbNetworks");
            });

            modelBuilder.Entity<TbNetworkMemberInvites>(entity =>
            {
                entity.HasKey(e => e.InviteId);

                entity.ToTable("tbNetworkMemberInvites");

                entity.Property(e => e.InviteId).HasColumnName("InviteID");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.NetworkId).HasColumnName("NetworkID");

                entity.Property(e => e.Status).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.TbNetworkMemberInvites)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_tbNetworkMemberInvites_tbMembers");

                entity.HasOne(d => d.Network)
                    .WithMany(p => p.TbNetworkMemberInvites)
                    .HasForeignKey(d => d.NetworkId)
                    .HasConstraintName("FK_tbNetworkMemberInvites_tbNetworks");
            });

            modelBuilder.Entity<TbNetworkMembers>(entity =>
            {
                entity.HasKey(e => new { e.NetworkId, e.MemberId });

                entity.ToTable("tbNetworkMembers");

                entity.Property(e => e.NetworkId).HasColumnName("NetworkID");

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.JoinedDate).HasColumnType("datetime");

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.TbNetworkMembers)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbNetworkMembers_tbMembers");

                entity.HasOne(d => d.Network)
                    .WithMany(p => p.TbNetworkMembers)
                    .HasForeignKey(d => d.NetworkId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbNetworkMembers_tbNetworks");
            });

            modelBuilder.Entity<TbNetworkPhotos>(entity =>
            {
                entity.HasKey(e => e.PhotoId);

                entity.ToTable("tbNetworkPhotos");

                entity.Property(e => e.PhotoId).HasColumnName("PhotoID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FileName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.NetworkId).HasColumnName("NetworkID");

                entity.Property(e => e.PhotoDesc)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PhotoName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Removed).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.TbNetworkPhotos)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_tbNetworkPhotos_tbMembers");

                entity.HasOne(d => d.Network)
                    .WithMany(p => p.TbNetworkPhotos)
                    .HasForeignKey(d => d.NetworkId)
                    .HasConstraintName("FK_tbNetworkPhotos_tbNetworks");
            });

            modelBuilder.Entity<TbNetworkPostResponses>(entity =>
            {
                entity.HasKey(e => e.PostResponseId);

                entity.ToTable("tbNetworkPostResponses");

                entity.Property(e => e.PostResponseId).HasColumnName("PostResponseID");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.NetworkId).HasColumnName("NetworkID");

                entity.Property(e => e.PostId).HasColumnName("PostID");

                entity.Property(e => e.ResponseDate).HasColumnType("datetime");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.TbNetworkPostResponses)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_tbNetworkPostResponses_tbMembers");

                entity.HasOne(d => d.Network)
                    .WithMany(p => p.TbNetworkPostResponses)
                    .HasForeignKey(d => d.NetworkId)
                    .HasConstraintName("FK_tbNetworkPostResponses_tbNetworks");
            });

            modelBuilder.Entity<TbNetworkPosts>(entity =>
            {
                entity.HasKey(e => e.PostId);

                entity.ToTable("tbNetworkPosts");

                entity.Property(e => e.PostId).HasColumnName("PostID");

                entity.Property(e => e.AttachFile)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(700)
                    .IsUnicode(false);

                entity.Property(e => e.FileType).HasDefaultValueSql("((0))");

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.NetworkId).HasColumnName("NetworkID");

                entity.Property(e => e.PostDate).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.TbNetworkPosts)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_tbNetworkPosts_tbMembers");

                entity.HasOne(d => d.Network)
                    .WithMany(p => p.TbNetworkPosts)
                    .HasForeignKey(d => d.NetworkId)
                    .HasConstraintName("FK_tbNetworkPosts_tbNetworks");
            });

            modelBuilder.Entity<TbNetworkRecentActivities>(entity =>
            {
                entity.HasKey(e => e.ActivityId);

                entity.ToTable("tbNetworkRecentActivities");

                entity.Property(e => e.ActivityId).HasColumnName("ActivityID");

                entity.Property(e => e.ActivityDate).HasColumnType("datetime");

                entity.Property(e => e.ActivityTypeId).HasColumnName("ActivityTypeID");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.NetworkId).HasColumnName("NetworkID");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.TbNetworkRecentActivities)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_tbNetworkRecentActivities_tbMembers");

                entity.HasOne(d => d.Network)
                    .WithMany(p => p.TbNetworkRecentActivities)
                    .HasForeignKey(d => d.NetworkId)
                    .HasConstraintName("FK_tbNetworkRecentActivities_tbNetworks");
            });

            modelBuilder.Entity<TbNetworkRequests>(entity =>
            {
                entity.HasKey(e => e.RequestId);

                entity.ToTable("tbNetworkRequests");

                entity.Property(e => e.RequestId).HasColumnName("RequestID");

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.NetworkId).HasColumnName("NetworkID");

                entity.Property(e => e.Purpose)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.RequestedDate).HasColumnType("datetime");

                entity.Property(e => e.Status).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.TbNetworkRequests)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_tbNetworkRequests_tbMembers");

                entity.HasOne(d => d.Network)
                    .WithMany(p => p.TbNetworkRequests)
                    .HasForeignKey(d => d.NetworkId)
                    .HasConstraintName("FK_tbNetworkRequests_tbNetworks");
            });

            modelBuilder.Entity<TbNetworks>(entity =>
            {
                entity.HasKey(e => e.NetworkId);

                entity.ToTable("tbNetworks");

                entity.Property(e => e.NetworkId).HasColumnName("NetworkID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CategoryTypeId).HasColumnName("CategoryTypeID");

                entity.Property(e => e.City)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Image)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.InActive).HasDefaultValueSql("((0))");

                entity.Property(e => e.NetworkName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Office)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RecentNews).HasColumnType("text");

                entity.Property(e => e.State)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Street)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Website)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Zip)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.TbNetworks)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_tbNetworks_tbNetworkCategory");

                entity.HasOne(d => d.CategoryType)
                    .WithMany(p => p.TbNetworks)
                    .HasForeignKey(d => d.CategoryTypeId)
                    .HasConstraintName("FK_tbNetworks_tbNetworkCategoryType");
            });

            modelBuilder.Entity<TbNetworkSettings>(entity =>
            {
                entity.HasKey(e => e.NetworkId);

                entity.ToTable("tbNetworkSettings");

                entity.Property(e => e.NetworkId)
                    .HasColumnName("NetworkID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Access).HasDefaultValueSql("((1))");

                entity.Property(e => e.EnableDiscussionBoard).HasDefaultValueSql("((1))");

                entity.Property(e => e.EnableLinks).HasDefaultValueSql("((1))");

                entity.Property(e => e.EnablePhotos).HasDefaultValueSql("((1))");

                entity.Property(e => e.EnableVideos).HasDefaultValueSql("((1))");

                entity.Property(e => e.NonAdminCanWrite).HasDefaultValueSql("((1))");

                entity.Property(e => e.OnlyAllowAdminsToPostLinks).HasDefaultValueSql("((0))");

                entity.Property(e => e.OnlyAllowAdminsToUploadPhotos).HasDefaultValueSql("((0))");

                entity.Property(e => e.OnlyAllowAdminsToUploadVideos).HasDefaultValueSql("((0))");

                entity.Property(e => e.ShowGroupEvents).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Network)
                    .WithOne(p => p.TbNetworkSettings)
                    .HasForeignKey<TbNetworkSettings>(d => d.NetworkId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbNetworkSettings_tbNetworks");
            });

            modelBuilder.Entity<TbNetworkVideos>(entity =>
            {
                entity.HasKey(e => e.VideoId);

                entity.ToTable("tbNetworkVideos");

                entity.Property(e => e.VideoId).HasColumnName("VideoID");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FileName)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.NetworkId).HasColumnName("NetworkID");

                entity.Property(e => e.Removed).HasDefaultValueSql("((0))");

                entity.Property(e => e.VidCategory).HasDefaultValueSql("((1))");

                entity.Property(e => e.VidDate).HasColumnType("datetime");

                entity.Property(e => e.VidType).HasDefaultValueSql("((0))");

                entity.Property(e => e.VideoName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.TbNetworkVideos)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbNetworkVideos_tbMembers");

                entity.HasOne(d => d.Network)
                    .WithMany(p => p.TbNetworkVideos)
                    .HasForeignKey(d => d.NetworkId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbNetworkVideos_tbNetworks");
            });

            modelBuilder.Entity<TbNoteCommentPosts>(entity =>
            {
                entity.HasKey(e => e.PostId);

                entity.ToTable("tbNoteCommentPosts");

                entity.Property(e => e.PostId).HasColumnName("PostID");

                entity.Property(e => e.CommentDesc)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.NoteId).HasColumnName("NoteID");

                entity.Property(e => e.PostDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbNotes>(entity =>
            {
                entity.HasKey(e => e.NoteId);

                entity.ToTable("tbNotes");

                entity.Property(e => e.NoteId).HasColumnName("NoteID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.NoteText).HasColumnType("text");

                entity.Property(e => e.Title)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbNotifications>(entity =>
            {
                entity.HasKey(e => e.NotificationId);

                entity.ToTable("tbNotifications");

                entity.Property(e => e.NotificationId).HasColumnName("NotificationID");

                entity.Property(e => e.Notification)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.SentDate).HasColumnType("datetime");

                entity.Property(e => e.Subject)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbNotificationSettings>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.MemberId });

                entity.ToTable("tbNotificationSettings");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.EvDateChanged)
                    .HasColumnName("EV_DateChanged")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.EvInviteToEvent)
                    .HasColumnName("EV_InviteToEvent")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.EvMakeYouEventAdmin)
                    .HasColumnName("EV_MakeYouEventAdmin")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.EvRequestToJoinEventYouAdmin)
                    .HasColumnName("EV_RequestToJoinEventYouAdmin")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.GiSendYouGift)
                    .HasColumnName("GI_SendYouGift")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.GpChangesTheNameOfGroupYouBelong)
                    .HasColumnName("GP_ChangesTheNameOfGroupYouBelong")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.GpInviteYouToJoin)
                    .HasColumnName("GP_InviteYouToJoin")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.GpMakesYouAgpadmin)
                    .HasColumnName("GP_MakesYouAGPAdmin")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.GpPromoteToAdmin)
                    .HasColumnName("GP_PromoteToAdmin")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.GpRepliesToYourDiscBooardPost)
                    .HasColumnName("GP_RepliesToYourDiscBooardPost")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.GpRequestToJoinGpyouAdmin)
                    .HasColumnName("GP_RequestToJoinGPYouAdmin")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.HeRepliesToYourHelpQuest)
                    .HasColumnName("HE_RepliesToYourHelpQuest")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LgAddAsFriend)
                    .HasColumnName("LG_AddAsFriend")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LgAddsFriendYouSuggest)
                    .HasColumnName("LG_AddsFriendYouSuggest")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LgConfirmFriendDetails)
                    .HasColumnName("LG_ConfirmFriendDetails")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LgConfirmFriendShipRequest)
                    .HasColumnName("LG_ConfirmFriendShipRequest")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LgHasBirthDayComingUp)
                    .HasColumnName("LG_HasBirthDayComingUp")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LgPoking)
                    .HasColumnName("LG_Poking")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LgRequestToListAsFamily)
                    .HasColumnName("LG_RequestToListAsFamily")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LgSendMsg)
                    .HasColumnName("LG_SendMsg")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.NoCommentAfterYouInNote)
                    .HasColumnName("NO_CommentAfterYouInNote")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.NoCommentYourNotes)
                    .HasColumnName("NO_CommentYourNotes")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.NoTagsYouInNote)
                    .HasColumnName("NO_TagsYouInNote")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.PhTagInPhoto)
                    .HasColumnName("PH_TagInPhoto")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.PhTagOneOfYourPhotos)
                    .HasColumnName("PH_TagOneOfYourPhotos")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ViCommentAfterYouInVideo)
                    .HasColumnName("VI_CommentAfterYouInVideo")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ViCommentOnVideo)
                    .HasColumnName("VI_CommentOnVideo")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ViCommentOnVideoOfYou)
                    .HasColumnName("VI_CommentOnVideoOfYou")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ViTagsInVideo)
                    .HasColumnName("VI_TagsInVideo")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ViTagsOneOfYourVideos)
                    .HasColumnName("VI_TagsOneOfYourVideos")
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.TbNotificationSettings)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbNotificationSettings_tbMembers");
            });

            modelBuilder.Entity<TbPollAnswers>(entity =>
            {
                entity.HasKey(e => e.PollAnswerId);

                entity.ToTable("tbPollAnswers");

                entity.Property(e => e.PollAnswerId).HasColumnName("PollAnswerID");

                entity.Property(e => e.DisplayText)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.PollId).HasColumnName("PollID");
            });

            modelBuilder.Entity<TbPolls>(entity =>
            {
                entity.HasKey(e => e.PollId);

                entity.ToTable("tbPolls");

                entity.Property(e => e.PollId).HasColumnName("PollID");

                entity.Property(e => e.DisplayText)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<TbPrivateSchools>(entity =>
            {
                entity.HasKey(e => e.Lgid);

                entity.ToTable("tbPrivateSchools");

                entity.Property(e => e.Lgid).HasColumnName("LGId");

                entity.Property(e => e.City).HasMaxLength(255);

                entity.Property(e => e.County).HasMaxLength(255);

                entity.Property(e => e.HiGrade).HasMaxLength(255);

                entity.Property(e => e.ImageFile).HasMaxLength(255);

                entity.Property(e => e.LoGrade).HasMaxLength(255);

                entity.Property(e => e.PPacislPct)
                    .HasColumnName("P_PACISL_PCT")
                    .HasMaxLength(255);

                entity.Property(e => e.PTwomorePct)
                    .HasColumnName("P_TWOMORE_PCT")
                    .HasMaxLength(255);

                entity.Property(e => e.Phone).HasMaxLength(255);

                entity.Property(e => e.PssAsianPct)
                    .HasColumnName("PSS_ASIAN_PCT")
                    .HasMaxLength(255);

                entity.Property(e => e.PssAssoc1)
                    .HasColumnName("PSS_ASSOC_1")
                    .HasMaxLength(255);

                entity.Property(e => e.PssAssoc2)
                    .HasColumnName("PSS_ASSOC_2")
                    .HasMaxLength(255);

                entity.Property(e => e.PssAssoc3)
                    .HasColumnName("PSS_ASSOC_3")
                    .HasMaxLength(255);

                entity.Property(e => e.PssAssoc4)
                    .HasColumnName("PSS_ASSOC_4")
                    .HasMaxLength(255);

                entity.Property(e => e.PssAssoc5)
                    .HasColumnName("PSS_ASSOC_5")
                    .HasMaxLength(255);

                entity.Property(e => e.PssAssoc6)
                    .HasColumnName("PSS_ASSOC_6")
                    .HasMaxLength(255);

                entity.Property(e => e.PssAssoc7)
                    .HasColumnName("PSS_ASSOC_7")
                    .HasMaxLength(255);

                entity.Property(e => e.PssBlackPct)
                    .HasColumnName("PSS_BLACK_PCT")
                    .HasMaxLength(255);

                entity.Property(e => e.PssCoed)
                    .HasColumnName("PSS_COED")
                    .HasMaxLength(255);

                entity.Property(e => e.PssCommType)
                    .HasColumnName("PSS_COMM_TYPE")
                    .HasMaxLength(255);

                entity.Property(e => e.PssCountyFips)
                    .HasColumnName("PSS_COUNTY_FIPS")
                    .HasMaxLength(255);

                entity.Property(e => e.PssCountyNo)
                    .HasColumnName("PSS_COUNTY_NO")
                    .HasMaxLength(255);

                entity.Property(e => e.PssEnroll1)
                    .HasColumnName("PSS_ENROLL_1")
                    .HasMaxLength(255);

                entity.Property(e => e.PssEnroll10)
                    .HasColumnName("PSS_ENROLL_10")
                    .HasMaxLength(255);

                entity.Property(e => e.PssEnroll11)
                    .HasColumnName("PSS_ENROLL_11")
                    .HasMaxLength(255);

                entity.Property(e => e.PssEnroll12)
                    .HasColumnName("PSS_ENROLL_12")
                    .HasMaxLength(255);

                entity.Property(e => e.PssEnroll2)
                    .HasColumnName("PSS_ENROLL_2")
                    .HasMaxLength(255);

                entity.Property(e => e.PssEnroll3)
                    .HasColumnName("PSS_ENROLL_3")
                    .HasMaxLength(255);

                entity.Property(e => e.PssEnroll4)
                    .HasColumnName("PSS_ENROLL_4")
                    .HasMaxLength(255);

                entity.Property(e => e.PssEnroll5)
                    .HasColumnName("PSS_ENROLL_5")
                    .HasMaxLength(255);

                entity.Property(e => e.PssEnroll6)
                    .HasColumnName("PSS_ENROLL_6")
                    .HasMaxLength(255);

                entity.Property(e => e.PssEnroll7)
                    .HasColumnName("PSS_ENROLL_7")
                    .HasMaxLength(255);

                entity.Property(e => e.PssEnroll8)
                    .HasColumnName("PSS_ENROLL_8")
                    .HasMaxLength(255);

                entity.Property(e => e.PssEnroll9)
                    .HasColumnName("PSS_ENROLL_9")
                    .HasMaxLength(255);

                entity.Property(e => e.PssEnrollK)
                    .HasColumnName("PSS_ENROLL_K")
                    .HasMaxLength(255);

                entity.Property(e => e.PssEnrollPk)
                    .HasColumnName("PSS_ENROLL_PK")
                    .HasMaxLength(255);

                entity.Property(e => e.PssEnrollT)
                    .HasColumnName("PSS_ENROLL_T")
                    .HasMaxLength(255);

                entity.Property(e => e.PssEnrollTk12)
                    .HasColumnName("PSS_ENROLL_TK12")
                    .HasMaxLength(255);

                entity.Property(e => e.PssEnrollUg)
                    .HasColumnName("PSS_ENROLL_UG")
                    .HasMaxLength(255);

                entity.Property(e => e.PssFips)
                    .HasColumnName("PSS_FIPS")
                    .HasMaxLength(255);

                entity.Property(e => e.PssFteTeach)
                    .HasColumnName("PSS_FTE_TEACH")
                    .HasMaxLength(255);

                entity.Property(e => e.PssHispPct)
                    .HasColumnName("PSS_HISP_PCT")
                    .HasMaxLength(255);

                entity.Property(e => e.PssIndianPct)
                    .HasColumnName("PSS_INDIAN_PCT")
                    .HasMaxLength(255);

                entity.Property(e => e.PssLevel)
                    .HasColumnName("PSS_LEVEL")
                    .HasMaxLength(255);

                entity.Property(e => e.PssLibrary)
                    .HasColumnName("PSS_LIBRARY")
                    .HasMaxLength(255);

                entity.Property(e => e.PssLocale)
                    .HasColumnName("PSS_LOCALE")
                    .HasMaxLength(255);

                entity.Property(e => e.PssOrient)
                    .HasColumnName("PSS_ORIENT")
                    .HasMaxLength(255);

                entity.Property(e => e.PssRace2)
                    .HasColumnName("PSS_RACE_2")
                    .HasMaxLength(255);

                entity.Property(e => e.PssRaceAi)
                    .HasColumnName("PSS_RACE_AI")
                    .HasMaxLength(255);

                entity.Property(e => e.PssRaceAs)
                    .HasColumnName("PSS_RACE_AS")
                    .HasMaxLength(255);

                entity.Property(e => e.PssRaceB)
                    .HasColumnName("PSS_RACE_B")
                    .HasMaxLength(255);

                entity.Property(e => e.PssRaceH)
                    .HasColumnName("PSS_RACE_H")
                    .HasMaxLength(255);

                entity.Property(e => e.PssRaceP)
                    .HasColumnName("PSS_RACE_P")
                    .HasMaxLength(255);

                entity.Property(e => e.PssRaceW)
                    .HasColumnName("PSS_RACE_W")
                    .HasMaxLength(255);

                entity.Property(e => e.PssRelig)
                    .HasColumnName("PSS_RELIG")
                    .HasMaxLength(255);

                entity.Property(e => e.PssSchDays)
                    .HasColumnName("PSS_SCH_DAYS")
                    .HasMaxLength(255);

                entity.Property(e => e.PssSchoolId)
                    .HasColumnName("PSS_SCHOOL_ID")
                    .HasMaxLength(255);

                entity.Property(e => e.PssStdtchRt)
                    .HasColumnName("PSS_STDTCH_RT")
                    .HasMaxLength(255);

                entity.Property(e => e.PssStuDayHrs)
                    .HasColumnName("PSS_STU_DAY_HRS")
                    .HasMaxLength(255);

                entity.Property(e => e.PssType)
                    .HasColumnName("PSS_TYPE")
                    .HasMaxLength(255);

                entity.Property(e => e.PssWhitePct)
                    .HasColumnName("PSS_WHITE_PCT")
                    .HasMaxLength(255);

                entity.Property(e => e.SchoolName).HasMaxLength(255);

                entity.Property(e => e.State).HasMaxLength(255);

                entity.Property(e => e.StreetName).HasMaxLength(255);

                entity.Property(e => e.Zip).HasMaxLength(255);
            });

            modelBuilder.Entity<TbPublcSchoolDisctricts>(entity =>
            {
                entity.HasKey(e => e.Lgid);

                entity.ToTable("tbPublcSchoolDisctricts");

                entity.Property(e => e.Lgid).HasColumnName("LGID");

                entity.Property(e => e.City)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.CountyName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ImageFile)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.Locale)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LocaleCode)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NcesdistrictId)
                    .HasColumnName("NCESDistrictID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SchoolName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Schools)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StateDistrictId)
                    .HasColumnName("StateDistrictID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StreetName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.StudentTeacherRatio)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Students)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Teachers)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Zip)
                    .HasColumnName("ZIP")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Zip4)
                    .HasColumnName("ZIP4")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbPublicLibraries>(entity =>
            {
                entity.HasKey(e => e.Lgid);

                entity.ToTable("tbPublicLibraries");

                entity.Property(e => e.Lgid).HasColumnName("LGID");

                entity.Property(e => e.AddresM)
                    .HasColumnName("ADDRES_M")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Audio)
                    .HasColumnName("AUDIO")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Benefit)
                    .HasColumnName("BENEFIT")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Bkmob)
                    .HasColumnName("BKMOB")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Bkvol)
                    .HasColumnName("BKVOL")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Branlib)
                    .HasColumnName("BRANLIB")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CAdmin)
                    .HasColumnName("C_ADMIN")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CFscs)
                    .HasColumnName("C_FSCS")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CLegbas)
                    .HasColumnName("C_LEGBAS")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.COutTy)
                    .HasColumnName("C_OUT_TY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CRelatn)
                    .HasColumnName("C_RELATN")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CapRev)
                    .HasColumnName("CAP_REV")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Capital)
                    .HasColumnName("CAPITAL")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Centlib)
                    .HasColumnName("CENTLIB")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasColumnName("CITY")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CityM)
                    .HasColumnName("CITY_M")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Cnty)
                    .HasColumnName("CNTY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Cntyfips)
                    .HasColumnName("CNTYFIPS")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DataYear)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Database)
                    .HasColumnName("DATABASE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Dbase)
                    .HasColumnName("DBase")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Ebook)
                    .HasColumnName("EBOOK")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Elmatexp)
                    .HasColumnName("ELMATEXP")
                    .HasMaxLength(255);

                entity.Property(e => e.EresUsr)
                    .HasColumnName("ERES_USR")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Esubscrp)
                    .HasColumnName("ESUBSCRP")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Fedgvt)
                    .HasColumnName("FEDGVT")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FscsSeq)
                    .HasColumnName("FSCS_SEQ")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Fscskey)
                    .HasColumnName("FSCSKEY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Geocode)
                    .HasColumnName("GEOCODE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Gpterms)
                    .HasColumnName("GPTERMS")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.HrsOpen)
                    .HasColumnName("HRS_OPEN")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Kidatten)
                    .HasColumnName("KIDATTEN")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Kidcircl)
                    .HasColumnName("KIDCIRCL")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Libid)
                    .HasColumnName("LIBID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Libraria)
                    .HasColumnName("LIBRARIA")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Libsysname)
                    .HasColumnName("LIBSYSNAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Loanfm)
                    .HasColumnName("LOANFM")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Loanto)
                    .HasColumnName("LOANTO")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Locgvt)
                    .HasColumnName("LOCGVT")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Lsabound)
                    .HasColumnName("LSABOUND")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Master)
                    .HasColumnName("MASTER")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Mstatus)
                    .HasColumnName("MStatus")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Ncesid)
                    .HasColumnName("NCESID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Obereg)
                    .HasColumnName("OBEREG")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Othincm)
                    .HasColumnName("OTHINCM")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Othmatex)
                    .HasColumnName("OTHMATEX")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Othopexp)
                    .HasColumnName("OTHOPEXP")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Othpaid)
                    .HasColumnName("OTHPAID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasColumnName("PHONE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PopuLsa)
                    .HasColumnName("POPU_LSA")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PopuUnd)
                    .HasColumnName("POPU_UND")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Prmatexp)
                    .HasColumnName("PRMATEXP")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PubFips)
                    .HasColumnName("Pub_Fips")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Referenc)
                    .HasColumnName("REFERENC")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Rgdetail)
                    .HasColumnName("rgdetail")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Rstatus)
                    .HasColumnName("RSTATUS")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Salaries)
                    .HasColumnName("SALARIES")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SchoolName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.StabrM)
                    .HasColumnName("stabr_M")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Staffexp)
                    .HasColumnName("STAFFEXP")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StateCode)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Stgvt)
                    .HasColumnName("STGVT")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.StreetName)
                    .HasMaxLength(155)
                    .IsUnicode(false);

                entity.Property(e => e.Subscrip)
                    .HasColumnName("SUBSCRIP")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SystemName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Totcir)
                    .HasColumnName("TOTCIR")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Totexpco)
                    .HasColumnName("TOTEXPCO")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Totincm)
                    .HasColumnName("TOTINCM")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Totopexp)
                    .HasColumnName("TOTOPEXP")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Totstaff)
                    .HasColumnName("TOTSTAFF")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Video)
                    .HasColumnName("VIDEO")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Visits)
                    .HasColumnName("VISITS")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.WebAddr)
                    .HasColumnName("WEB_ADDR")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.YrSub)
                    .HasColumnName("YR_SUB")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Zip)
                    .HasColumnName("ZIP")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Zip4)
                    .HasColumnName("ZIP4")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Zip4M)
                    .HasColumnName("ZIP4_M")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ZipM)
                    .HasColumnName("ZIP_M")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbPublicSchools>(entity =>
            {
                entity.HasKey(e => e.Lgid);

                entity.ToTable("tbPublicSchools");

                entity.Property(e => e.Lgid).HasColumnName("LGID");

                entity.Property(e => e.Charter)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CountryName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.District)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DistrictId)
                    .HasColumnName("DistrictID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HighGrade)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ImageFile)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.LocalCode)
                    .HasColumnName("localCode")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Locale)
                    .HasColumnName("locale")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LowGrade)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Magnet)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SchoolId)
                    .HasColumnName("SchoolID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SchoolName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StateDistrict)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StateSchoolId)
                    .HasColumnName("StateSchoolID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StreetName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Title1SchoolWide)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Titlle1School)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Zip)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Zip4Digit)
                    .HasMaxLength(4)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbRecentNews>(entity =>
            {
                entity.ToTable("tbRecentNews");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.HeaderText)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.NavigateUrl)
                    .HasColumnName("NavigateURL")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PostingDate).HasColumnType("datetime");

                entity.Property(e => e.TextField)
                    .HasMaxLength(2000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbResumeSettings>(entity =>
            {
                entity.HasKey(e => e.MemberId);

                entity.ToTable("tbResumeSettings");

                entity.Property(e => e.MemberId)
                    .HasColumnName("MemberID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<TbSchoolsIlike>(entity =>
            {
                entity.HasKey(e => new { e.SchoolLikeId, e.SchoolId, e.MemberId });

                entity.ToTable("tbSchoolsILike");

                entity.Property(e => e.SchoolLikeId)
                    .HasColumnName("SchoolLikeID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.SchoolId).HasColumnName("SchoolID");

                entity.Property(e => e.SchoolType)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbSchoolType>(entity =>
            {
                entity.HasKey(e => e.SchoolTypeId);

                entity.ToTable("tbSchoolType");

                entity.Property(e => e.SchoolTypeId)
                    .HasColumnName("SchoolTypeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.SchoolTypeDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbStates>(entity =>
            {
                entity.HasKey(e => e.StateId);

                entity.ToTable("tbStates");

                entity.Property(e => e.StateId).HasColumnName("StateID");

                entity.Property(e => e.Abbreviation)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbSuggestions>(entity =>
            {
                entity.HasKey(e => new { e.MemberId, e.ContactEmail });

                entity.ToTable("tbSuggestions");

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.ContactEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.TbSuggestions)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbSuggestions_tbMembers");
            });

            modelBuilder.Entity<TbUserResponses>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.PollAnswerId });

                entity.ToTable("tbUserResponses");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.PollAnswerId).HasColumnName("PollAnswerID");
            });

            modelBuilder.Entity<TbVideoCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.ToTable("tbVideoCategory");

                entity.Property(e => e.CategoryId)
                    .HasColumnName("CategoryID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbVideos>(entity =>
            {
                entity.HasKey(e => e.VideoId);

                entity.ToTable("tbVideos");

                entity.Property(e => e.VideoId).HasColumnName("VideoID");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FileName)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.Removed).HasDefaultValueSql("((0))");

                entity.Property(e => e.VidDate).HasColumnType("datetime");

                entity.Property(e => e.VidType).HasDefaultValueSql("((0))");

                entity.Property(e => e.VideoName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.TbVideos)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbVideos_tbMembers");

                entity.HasOne(d => d.VidCategoryNavigation)
                    .WithMany(p => p.TbVideos)
                    .HasForeignKey(d => d.VidCategory)
                    .HasConstraintName("FK_tbVideos_tbVideoCategory");
            });

            modelBuilder.Query<SearchModel>();
            modelBuilder.Query<MemberContactModel>();
        }
    }
}
