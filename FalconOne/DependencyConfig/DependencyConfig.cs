﻿using FalconeOne.BLL.Interfaces;
using FalconeOne.BLL.Services;
using FalconOne.API.Filters;
using FalconOne.DAL;
using FalconOne.DAL.Interfaces;

namespace FalconOne.API.DependencyConfig
{
    public static class DependencyConfig
    {
        public static void Configure(WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IRequestInformationService, RequestInformationService>();
            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IAppRoleService, AppRoleService>();
            builder.Services.AddTransient<AsyncActionFilter>();
            builder.Services.AddTransient<ITokenService, TokenService>();
            builder.Services.AddTransient<IAppConfigService, AppConfigService>();
            builder.Services.AddTransient<IAppClaimService, AppClaimService>();
            builder.Services.AddTransient<IAppPolicyService, AppPolicyService>();
            builder.Services.AddTransient<IPostService, PostService>();
            builder.Services.AddTransient<IDepartmentService, DepartmentService>();
            builder.Services.AddScoped<ISettingsService, SettingsService>();
            builder.Services.AddScoped<ITenantService, TenantService>();
        }
    }
}
