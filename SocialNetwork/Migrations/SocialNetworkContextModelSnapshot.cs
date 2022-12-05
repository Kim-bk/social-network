﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SocialNetwork.Models;

#nullable disable

namespace SocialNetwork.Migrations
{
    [DbContext(typeof(SocialNetworkContext))]
    partial class SocialNetworkContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CommercialClothes.Models.Credential", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsActivated")
                        .HasColumnType("boolean");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.Property<int>("UserGroupId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserGroupId");

                    b.ToTable("Credentials");
                });

            modelBuilder.Entity("SocialNetwork.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PostId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("SocialNetwork.Models.Friend", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ApprovedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DeniedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("SourceId")
                        .HasColumnType("integer");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.Property<int>("TargetId")
                        .HasColumnType("integer");

                    b.Property<int>("UserSourceId")
                        .HasColumnType("integer");

                    b.Property<int>("UserTargetId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserSourceId");

                    b.HasIndex("UserTargetId");

                    b.ToTable("Friends");
                });

            modelBuilder.Entity("SocialNetwork.Models.Interaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Interactions");
                });

            modelBuilder.Entity("SocialNetwork.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("SourceId")
                        .HasColumnType("integer");

                    b.Property<int>("TargetId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("UserSourceId")
                        .HasColumnType("integer");

                    b.Property<int>("UserTargetId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserSourceId");

                    b.HasIndex("UserTargetId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("SocialNetwork.Models.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("NotificationObjectId")
                        .HasColumnType("integer");

                    b.Property<int>("NotifierId")
                        .HasColumnType("integer");

                    b.Property<int>("PostId")
                        .HasColumnType("integer");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("NotificationObjectId");

                    b.HasIndex("NotifierId");

                    b.HasIndex("PostId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("SocialNetwork.Models.NotificationChange", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ActorId")
                        .HasColumnType("integer");

                    b.Property<int>("NotificationObjectId")
                        .HasColumnType("integer");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("ActorId");

                    b.HasIndex("NotificationObjectId");

                    b.ToTable("NotificationChanges");
                });

            modelBuilder.Entity("SocialNetwork.Models.NotificationObject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("EntityTypeId")
                        .HasColumnType("integer");

                    b.Property<int>("PostId")
                        .HasColumnType("integer");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("NotificationObjects");
                });

            modelBuilder.Entity("SocialNetwork.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("SocialNetwork.Models.PostInteractions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("InteractionId")
                        .HasColumnType("integer");

                    b.Property<int>("PostId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("InteractionId");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("PostInteractions");
                });

            modelBuilder.Entity("SocialNetwork.Models.RefreshToken", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Token")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("SocialNetwork.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("SocialNetwork.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<Guid>("ActivationCode")
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsActivated")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<Guid>("ResetPasswordCode")
                        .HasColumnType("uuid");

                    b.Property<int?>("ShopId")
                        .HasColumnType("integer");

                    b.Property<int?>("UserGroupId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserGroupId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SocialNetwork.Models.UserGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("UserGroups");
                });

            modelBuilder.Entity("CommercialClothes.Models.Credential", b =>
                {
                    b.HasOne("SocialNetwork.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialNetwork.Models.UserGroup", "UserGroup")
                        .WithMany()
                        .HasForeignKey("UserGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("UserGroup");
                });

            modelBuilder.Entity("SocialNetwork.Models.Comment", b =>
                {
                    b.HasOne("SocialNetwork.Models.Post", "Post")
                        .WithMany()
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialNetwork.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SocialNetwork.Models.Friend", b =>
                {
                    b.HasOne("SocialNetwork.Models.User", "UserSource")
                        .WithMany()
                        .HasForeignKey("UserSourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialNetwork.Models.User", "UserTarget")
                        .WithMany()
                        .HasForeignKey("UserTargetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserSource");

                    b.Navigation("UserTarget");
                });

            modelBuilder.Entity("SocialNetwork.Models.Message", b =>
                {
                    b.HasOne("SocialNetwork.Models.User", "UserSource")
                        .WithMany()
                        .HasForeignKey("UserSourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialNetwork.Models.User", "UserTarget")
                        .WithMany()
                        .HasForeignKey("UserTargetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserSource");

                    b.Navigation("UserTarget");
                });

            modelBuilder.Entity("SocialNetwork.Models.Notification", b =>
                {
                    b.HasOne("SocialNetwork.Models.NotificationObject", "NotificationObject")
                        .WithMany()
                        .HasForeignKey("NotificationObjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialNetwork.Models.User", "Notifier")
                        .WithMany()
                        .HasForeignKey("NotifierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialNetwork.Models.Post", "Post")
                        .WithMany()
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NotificationObject");

                    b.Navigation("Notifier");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("SocialNetwork.Models.NotificationChange", b =>
                {
                    b.HasOne("SocialNetwork.Models.User", "Actor")
                        .WithMany()
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialNetwork.Models.NotificationObject", "NotificationObject")
                        .WithMany()
                        .HasForeignKey("NotificationObjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("NotificationObject");
                });

            modelBuilder.Entity("SocialNetwork.Models.NotificationObject", b =>
                {
                    b.HasOne("SocialNetwork.Models.Post", "Post")
                        .WithMany()
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");
                });

            modelBuilder.Entity("SocialNetwork.Models.Post", b =>
                {
                    b.HasOne("SocialNetwork.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SocialNetwork.Models.PostInteractions", b =>
                {
                    b.HasOne("SocialNetwork.Models.Interaction", "Interaction")
                        .WithMany()
                        .HasForeignKey("InteractionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialNetwork.Models.Post", "Post")
                        .WithMany()
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialNetwork.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Interaction");

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SocialNetwork.Models.RefreshToken", b =>
                {
                    b.HasOne("SocialNetwork.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SocialNetwork.Models.User", b =>
                {
                    b.HasOne("SocialNetwork.Models.UserGroup", "UserGroup")
                        .WithMany("Users")
                        .HasForeignKey("UserGroupId");

                    b.Navigation("UserGroup");
                });

            modelBuilder.Entity("SocialNetwork.Models.UserGroup", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
