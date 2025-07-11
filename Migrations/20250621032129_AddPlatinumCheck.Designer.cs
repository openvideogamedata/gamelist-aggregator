﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace community.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250621032129_AddPlatinumCheck")]
    partial class AddPlatinumCheck
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Badge", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<bool>("AutomaticallyGiven")
                        .HasColumnType("boolean");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PixelArt")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Priority")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Badges");
                });

            modelBuilder.Entity("BadgeUser", b =>
                {
                    b.Property<long>("BadgesId")
                        .HasColumnType("bigint");

                    b.Property<long>("UsersId")
                        .HasColumnType("bigint");

                    b.HasKey("BadgesId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("UserBadge", (string)null);
                });

            modelBuilder.Entity("Friendship", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<long>("User1Id")
                        .HasColumnType("bigint");

                    b.Property<long>("User2Id")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("User1Id");

                    b.HasIndex("User2Id");

                    b.ToTable("Friendships");
                });

            modelBuilder.Entity("GameList", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<bool>("ByUser")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateLastUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long?>("FinalGameListId")
                        .HasColumnType("bigint");

                    b.Property<long?>("SourceId")
                        .HasColumnType("bigint");

                    b.Property<string>("SourceListUrl")
                        .HasColumnType("text");

                    b.Property<long?>("UserContributedId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("FinalGameListId");

                    b.HasIndex("SourceId");

                    b.HasIndex("UserContributedId");

                    b.ToTable("GameLists");
                });

            modelBuilder.Entity("GameListRequestUser", b =>
                {
                    b.Property<long>("GameListRequestsLikedId")
                        .HasColumnType("bigint");

                    b.Property<long>("UsersLikedId")
                        .HasColumnType("bigint");

                    b.HasKey("GameListRequestsLikedId", "UsersLikedId");

                    b.HasIndex("UsersLikedId");

                    b.ToTable("UserLikedItem", (string)null);
                });

            modelBuilder.Entity("GameListRequestUser1", b =>
                {
                    b.Property<long>("GameListRequestsDislikedId")
                        .HasColumnType("bigint");

                    b.Property<long>("UsersDislikedId")
                        .HasColumnType("bigint");

                    b.HasKey("GameListRequestsDislikedId", "UsersDislikedId");

                    b.HasIndex("UsersDislikedId");

                    b.ToTable("UserDislikedItem", (string)null);
                });

            modelBuilder.Entity("GameRequest", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("GameId")
                        .HasColumnType("bigint");

                    b.Property<long>("GameListRequestId")
                        .HasColumnType("bigint");

                    b.Property<string>("GameTitle")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Position")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("GameListRequestId");

                    b.ToTable("GameRequests");
                });

            modelBuilder.Entity("GameUserTracker", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("GameId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Note")
                        .HasColumnType("text");

                    b.Property<bool>("Platinum")
                        .HasColumnType("boolean");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<DateTime>("StatusDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("UserId");

                    b.ToTable("GameUserTrackers");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("BanReason")
                        .HasColumnType("text");

                    b.Property<bool>("Banned")
                        .HasColumnType("boolean");

                    b.Property<string>("GivenName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NameIdentifier")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserPixelArt")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("UserNotification", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Read")
                        .HasColumnType("boolean");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("community.Data.FinalGameList", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<bool>("ConsideredForAvgScore")
                        .HasColumnType("boolean");

                    b.Property<bool>("Pinned")
                        .HasColumnType("boolean");

                    b.Property<int>("PinnedPriority")
                        .HasColumnType("integer");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("SocialComments")
                        .HasColumnType("integer");

                    b.Property<string>("SocialUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Tags")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("Year")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("FinalGameLists");
                });

            modelBuilder.Entity("community.Data.Game", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("ExternalCoverImageId")
                        .HasColumnType("text");

                    b.Property<long>("ExternalId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("FirstReleaseDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("community.Data.GameListRequest", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("FinalGameListId")
                        .HasColumnType("bigint");

                    b.Property<bool>("Hidden")
                        .HasColumnType("boolean");

                    b.Property<string>("HostUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("Score")
                        .HasColumnType("bigint");

                    b.Property<string>("SourceListUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SourceName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("UserPostedId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("FinalGameListId");

                    b.HasIndex("UserPostedId");

                    b.ToTable("GameListRequests");
                });

            modelBuilder.Entity("community.Data.Item", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("FinalGameListId")
                        .HasColumnType("bigint");

                    b.Property<long>("GameId")
                        .HasColumnType("bigint");

                    b.Property<long>("GameListId")
                        .HasColumnType("bigint");

                    b.Property<string>("GameTitle")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Position")
                        .HasColumnType("integer");

                    b.Property<int>("Score")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("FinalGameListId");

                    b.HasIndex("GameId");

                    b.HasIndex("GameListId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("community.Data.Source", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("HostUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Sources");
                });

            modelBuilder.Entity("community.Data.TopWinner", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<bool>("ByUser")
                        .HasColumnType("boolean");

                    b.Property<int>("Citations")
                        .HasColumnType("integer");

                    b.Property<string>("CoverImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long?>("FinalGameListId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("FirstReleaseDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("GameId")
                        .HasColumnType("bigint");

                    b.Property<long>("GameListId")
                        .HasColumnType("bigint");

                    b.Property<string>("GameTitle")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PorcentageOfCitations")
                        .HasColumnType("integer");

                    b.Property<int>("Position")
                        .HasColumnType("integer");

                    b.Property<int>("Score")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("FinalGameListId");

                    b.HasIndex("GameId");

                    b.HasIndex("GameListId");

                    b.ToTable("TopWinners");
                });

            modelBuilder.Entity("BadgeUser", b =>
                {
                    b.HasOne("Badge", null)
                        .WithMany()
                        .HasForeignKey("BadgesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Friendship", b =>
                {
                    b.HasOne("User", "UserRequested")
                        .WithMany("RequestedFriends")
                        .HasForeignKey("User1Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("User", "UserReceived")
                        .WithMany("ReceivedFriends")
                        .HasForeignKey("User2Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("UserReceived");

                    b.Navigation("UserRequested");
                });

            modelBuilder.Entity("GameList", b =>
                {
                    b.HasOne("community.Data.FinalGameList", "FinalGameList")
                        .WithMany("GameLists")
                        .HasForeignKey("FinalGameListId");

                    b.HasOne("community.Data.Source", "Source")
                        .WithMany()
                        .HasForeignKey("SourceId");

                    b.HasOne("User", "UserContributed")
                        .WithMany("GameListsContributed")
                        .HasForeignKey("UserContributedId");

                    b.Navigation("FinalGameList");

                    b.Navigation("Source");

                    b.Navigation("UserContributed");
                });

            modelBuilder.Entity("GameListRequestUser", b =>
                {
                    b.HasOne("community.Data.GameListRequest", null)
                        .WithMany()
                        .HasForeignKey("GameListRequestsLikedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("User", null)
                        .WithMany()
                        .HasForeignKey("UsersLikedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GameListRequestUser1", b =>
                {
                    b.HasOne("community.Data.GameListRequest", null)
                        .WithMany()
                        .HasForeignKey("GameListRequestsDislikedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("User", null)
                        .WithMany()
                        .HasForeignKey("UsersDislikedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GameRequest", b =>
                {
                    b.HasOne("community.Data.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("community.Data.GameListRequest", "GameListRequest")
                        .WithMany("GameRequests")
                        .HasForeignKey("GameListRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("GameListRequest");
                });

            modelBuilder.Entity("GameUserTracker", b =>
                {
                    b.HasOne("community.Data.Game", "Game")
                        .WithMany("GameUserTrackers")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("User");
                });

            modelBuilder.Entity("UserNotification", b =>
                {
                    b.HasOne("User", "User")
                        .WithMany("Notifications")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("community.Data.GameListRequest", b =>
                {
                    b.HasOne("community.Data.FinalGameList", "FinalGameList")
                        .WithMany()
                        .HasForeignKey("FinalGameListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("User", "UserPosted")
                        .WithMany("GameListRequestsPosted")
                        .HasForeignKey("UserPostedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FinalGameList");

                    b.Navigation("UserPosted");
                });

            modelBuilder.Entity("community.Data.Item", b =>
                {
                    b.HasOne("community.Data.FinalGameList", "FinalGameList")
                        .WithMany()
                        .HasForeignKey("FinalGameListId");

                    b.HasOne("community.Data.Game", "Game")
                        .WithMany("Items")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameList", "GameList")
                        .WithMany("Items")
                        .HasForeignKey("GameListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FinalGameList");

                    b.Navigation("Game");

                    b.Navigation("GameList");
                });

            modelBuilder.Entity("community.Data.TopWinner", b =>
                {
                    b.HasOne("community.Data.FinalGameList", "FinalGameList")
                        .WithMany()
                        .HasForeignKey("FinalGameListId");

                    b.HasOne("community.Data.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameList", "GameList")
                        .WithMany()
                        .HasForeignKey("GameListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FinalGameList");

                    b.Navigation("Game");

                    b.Navigation("GameList");
                });

            modelBuilder.Entity("GameList", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.Navigation("GameListRequestsPosted");

                    b.Navigation("GameListsContributed");

                    b.Navigation("Notifications");

                    b.Navigation("ReceivedFriends");

                    b.Navigation("RequestedFriends");
                });

            modelBuilder.Entity("community.Data.FinalGameList", b =>
                {
                    b.Navigation("GameLists");
                });

            modelBuilder.Entity("community.Data.Game", b =>
                {
                    b.Navigation("GameUserTrackers");

                    b.Navigation("Items");
                });

            modelBuilder.Entity("community.Data.GameListRequest", b =>
                {
                    b.Navigation("GameRequests");
                });
#pragma warning restore 612, 618
        }
    }
}
