namespace Acme.BookStore.Permissions
{
    public static class BookStorePermissions
    {
        public const string GroupName = "BookStore";

        public static class NomeDaPermissao
        {
            public const string Default = GroupName + ".NomeDaPermissao";
            public const string Delete = Default + ".Delete";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Transfer = Default + ".Transfer";
        }
    }
}