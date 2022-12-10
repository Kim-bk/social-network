using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Security.Principal;
using SocialNetwork.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using static System.Net.Mime.MediaTypeNames;

#nullable disable

namespace SocialNetwork.Models
{
    public partial class SocialNetworkContext : DbContext
    {
        public SocialNetworkContext(DbContextOptions<SocialNetworkContext> options)
            : base(options)
        {
        }


        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Friend> Friends { get; set; }
        public virtual DbSet<Interaction> Interactions { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<NotificationChange> NotificationChanges { get; set; }
        public virtual DbSet<NotificationObject> NotificationObjects { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<PostInteractions> PostInteractions { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Credential> Credentials { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<UserGroup> UserGroups { get; set; }
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}