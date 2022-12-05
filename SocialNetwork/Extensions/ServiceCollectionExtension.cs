using System;
using CommercialClothes.Models.DAL;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialNetwork.Models;
using SocialNetwork.Models.DAL;

namespace ComercialClothes.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped((Func<IServiceProvider, Func<SocialNetworkContext>>)((provider) => () => provider.GetService<SocialNetworkContext>()));
            services.AddScoped<DbFactory>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
          //  services.Configure<MailSettings>(configuration.GetSection("MailSettings"));

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped(typeof(IRepository<>), typeof(Repository<>));
             
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return null;
          /*  return services
                .AddScoped<Encryptor>()
                .AddScoped<AccessTokenGenerator>()
                .AddScoped<RefreshTokenGenerator>()
                .AddScoped<RefreshTokenValidator>()
                .AddScoped<TokenGenerator>()
                .AddScoped<IEmailSender, EmailSender>()
                .AddScoped<IUserService, UserService>()
                .AddScoped<IItemService, ItemService>()
                .AddScoped<ICategoryService, CategoryService>()
                .AddScoped<IMapperCustom, Mapper>()
                .AddScoped<IImageService, ImageService>()
                .AddScoped<IOrderService, OrderService>()
                .AddScoped<ISearchService, SearchService>()
                .AddScoped<IPermissionService, PermissionService>()
                .AddScoped<IShopService, ShopService>()
                .AddScoped<IRoleService, RoleService>()
                .AddScoped<IUserGroupService, UserGroupService>()
                .AddScoped<IAuthService, AuthService>()
                .AddScoped<ICartService, CartService>()
                .AddScoped<IStatisticalService, StatisticalService>()
                .AddScoped<IBankService, BankService>()
                .AddScoped<IPaymentService, PaymentService>()
                .AddScoped<IAdminService, AdminService>();*/
        }
    }
}
