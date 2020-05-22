using Acme.BookStore.Features;
using Volo.Abp;
using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Features;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.TenantManagement;
using Volo.Abp.AspNetCore.Mvc;

namespace Acme.BookStore
{
    [DependsOn(
        typeof(BookStoreDomainModule),
        typeof(AbpAspNetCoreMvcModule),
        typeof(AbpAccountApplicationModule),
        typeof(BookStoreApplicationContractsModule),
        typeof(AbpIdentityApplicationModule),
        typeof(AbpPermissionManagementApplicationModule),
        typeof(AbpTenantManagementApplicationModule),
        typeof(AbpFeatureManagementApplicationModule)
        )]
    public class BookStoreApplicationModule : AbpModule
    {

        public override void OnPreApplicationInitialization(ApplicationInitializationContext context)
        {
            base.OnPreApplicationInitialization(context);
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<BookStoreApplicationModule>();
            });
        }
    }
}
