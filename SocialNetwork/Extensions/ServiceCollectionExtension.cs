using System;
using SocialNetwork.Models.DAL;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialNetwork.Models;
using SocialNetwork.Models.DAL;
using SocialNetwork.Services;
using SocialNetwork.Services.TokenGenerators;
using SocialNetwork.Services.Interfaces;
using SocialNetwork.Services.TokenValidators;
using SocialNetwork.Services.Mapping;
using SocialNetwork.Models.DTOs.Settings;
using SocialNetwork.Models.DAL.Interfaces;
using SocialNetwork.Models.DAL.Repositories;

namespace SocialNetwork.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped((Func<IServiceProvider, Func<SocialNetworkContext>>)((provider) => () => provider.GetService<SocialNetworkContext>()));
            services.AddScoped<DbFactory>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.Configure<MailSettings>(configuration.GetSection("MailSettings"));

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
               .AddScoped(typeof(IRepository<>), typeof(Repository<>))
               .AddScoped<IUserRepository, UserRepository>()
               .AddScoped<IRoleRepository, RoleRepository>()
               .AddScoped<IRefreshTokenRepository, RefreshTokenRepository>()
               .AddScoped<IUserGroupRepository, UserGroupRepository>()
               .AddScoped<ICredentialRepository, CredentialRepository>()
               .AddScoped<IPostRepository, PostRepository>()
               .AddScoped<IFriendRepository, FriendRepository>();
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
                .AddScoped<Encryptor>()
                .AddScoped<AccessTokenGenerator>()
                .AddScoped<RefreshTokenGenerator>()
                .AddScoped<RefreshTokenValidator>()
                .AddScoped<TokenGenerator>()
                .AddScoped<IEmailSender, EmailSender>()
                .AddScoped<IUserService, UserService>()
                .AddScoped<IMapperCustom, Mapper>()
                .AddScoped<IPermissionService, PermissionService>()
                .AddScoped<IRoleService, RoleService>()
                .AddScoped<IUserGroupService, UserGroupService>()
                .AddScoped<IAuthService, AuthService>()
                .AddScoped<IAdminService, AdminService>()
                .AddScoped<IPostService, PostService>()
                .AddScoped<IFriendService, FriendService>();
        }
    }
}
