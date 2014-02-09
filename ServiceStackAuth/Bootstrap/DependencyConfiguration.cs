namespace ServiceStackAuth.Bootstrap
{
    using Funq;

    using ServiceStack.CacheAccess;
    using ServiceStack.CacheAccess.Providers;
    using ServiceStack.ServiceInterface.Auth;

    using ServiceStackAuth.Caching;
    using ServiceStackAuth.Queries;

    public static class DependencyConfiguration
    {
        public static void Configure(Funq.Container container)
        {
            container.RegisterAutoWiredAs<DictionaryCache, ICacheClient>().ReusedWithin(ReuseScope.Container);
            container.RegisterAutoWiredAs<TestAuthRepository, IUserAuthRepository>();//.ReusedWithin(ReuseScope.Request);
            container.RegisterAutoWiredAs<ClaimsQuery, IClaimsQuery>();
            container.RegisterAutoWiredAs<UserQuery, IUserQuery>();

            //container.RegisterAutoWiredAs<MemoryCacheClient, ICacheClient>().ReusedWithin(ReuseScope.Container); 
        }
    }
}