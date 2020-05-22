using Acme.BookStore.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace Acme.BookStore.Permissions
{
    public class BookStorePermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(BookStorePermissions.GroupName);

            var nomeDaPermissao = myGroup.AddPermission(BookStorePermissions.NomeDaPermissao.Default, null, MultiTenancySides.Tenant);
            nomeDaPermissao.AddChild(BookStorePermissions.NomeDaPermissao.Create, null, MultiTenancySides.Tenant);
            nomeDaPermissao.AddChild(BookStorePermissions.NomeDaPermissao.Delete, null, MultiTenancySides.Tenant);
            nomeDaPermissao.AddChild(BookStorePermissions.NomeDaPermissao.Update, null, MultiTenancySides.Tenant);

            nomeDaPermissao.WithProviders(RolePermissionValueProvider.ProviderName,
                                          UserPermissionValueProvider.ProviderName);
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<BookStoreResource>(name);
        }
    }
}
