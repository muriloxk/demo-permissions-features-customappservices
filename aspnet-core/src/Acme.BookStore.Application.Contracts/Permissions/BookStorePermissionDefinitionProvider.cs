using Acme.BookStore.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Acme.BookStore.Permissions
{
    public class BookStorePermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(BookStorePermissions.GroupName);

            var nomeDaPermissao = myGroup.AddPermission(BookStorePermissions.NomeDaPermissao.Default);
            nomeDaPermissao.AddChild(BookStorePermissions.NomeDaPermissao.Create);
            nomeDaPermissao.AddChild(BookStorePermissions.NomeDaPermissao.Delete);
            nomeDaPermissao.AddChild(BookStorePermissions.NomeDaPermissao.Update);

            nomeDaPermissao.WithProviders(RolePermissionValueProvider.ProviderName,
                                          UserPermissionValueProvider.ProviderName);

        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<BookStoreResource>(name);
        }
    }
}
