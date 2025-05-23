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
    [Migration("20230228021550_AddCampoPosition")]
    partial class AddCampoPosition
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ItemRequestUser", b =>
                {
                    b.Property<long>("ItemsLikedId")
                        .HasColumnType("bigint");

                    b.Property<long>("UsersLikedId")
                        .HasColumnType("bigint");

                    b.HasKey("ItemsLikedId", "UsersLikedId");

                    b.HasIndex("UsersLikedId");

                    b.ToTable("UserLikedItem", (string)null);
                });

            modelBuilder.Entity("ItemRequestUser1", b =>
                {
                    b.Property<long>("ItemsDislikedId")
                        .HasColumnType("bigint");

                    b.Property<long>("UsersDislikedId")
                        .HasColumnType("bigint");

                    b.HasKey("ItemsDislikedId", "UsersDislikedId");

                    b.HasIndex("UsersDislikedId");

                    b.ToTable("UserDislikedItem", (string)null);
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

                    b.Property<string>("Role")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
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

            modelBuilder.Entity("community.Data.GameList", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<bool>("Pinned")
                        .HasColumnType("boolean");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("Year")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("GameLists");
                });

            modelBuilder.Entity("community.Data.Item", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("GameId")
                        .HasColumnType("bigint");

                    b.Property<long>("GameListId")
                        .HasColumnType("bigint");

                    b.Property<string>("GameTitle")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SourceName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SourceUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("UserContributedId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("GameListId");

                    b.HasIndex("UserContributedId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("community.Data.ItemRequest", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("GameId")
                        .HasColumnType("bigint");

                    b.Property<long>("GameListId")
                        .HasColumnType("bigint");

                    b.Property<string>("GameTitle")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Hidden")
                        .HasColumnType("boolean");

                    b.Property<int>("Position")
                        .HasColumnType("integer");

                    b.Property<long>("Score")
                        .HasColumnType("bigint");

                    b.Property<string>("SourceName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SourceUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("UserPostedId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("GameListId");

                    b.HasIndex("UserPostedId");

                    b.ToTable("ItemRequests");
                });

            modelBuilder.Entity("ItemRequestUser", b =>
                {
                    b.HasOne("community.Data.ItemRequest", null)
                        .WithMany()
                        .HasForeignKey("ItemsLikedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("User", null)
                        .WithMany()
                        .HasForeignKey("UsersLikedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ItemRequestUser1", b =>
                {
                    b.HasOne("community.Data.ItemRequest", null)
                        .WithMany()
                        .HasForeignKey("ItemsDislikedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("User", null)
                        .WithMany()
                        .HasForeignKey("UsersDislikedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("community.Data.Item", b =>
                {
                    b.HasOne("community.Data.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("community.Data.GameList", "GameList")
                        .WithMany("Items")
                        .HasForeignKey("GameListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("User", "UserContributed")
                        .WithMany("ItemsContributed")
                        .HasForeignKey("UserContributedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("GameList");

                    b.Navigation("UserContributed");
                });

            modelBuilder.Entity("community.Data.ItemRequest", b =>
                {
                    b.HasOne("community.Data.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("community.Data.GameList", "GameList")
                        .WithMany()
                        .HasForeignKey("GameListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("User", "UserPosted")
                        .WithMany("ItemRequestsPosted")
                        .HasForeignKey("UserPostedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("GameList");

                    b.Navigation("UserPosted");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.Navigation("ItemRequestsPosted");

                    b.Navigation("ItemsContributed");
                });

            modelBuilder.Entity("community.Data.GameList", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
