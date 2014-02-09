namespace ServiceStackAuth.Bootstrap
{
    using Funq;

    using ServiceStack.ServiceInterface;
    using ServiceStack.ServiceInterface.Auth;
    using ServiceStack.WebHost.Endpoints;

    using ServiceStackAuth.AuthProviders;
    using ServiceStackAuth.Services;
    using ServiceStackAuth.Services.Requests;
    using ServiceStackAuth.Sessions;

    public class BootStrap
        : AppHostBase
    {
        public BootStrap()
            : base("Test Service", typeof(AuthenticationService).Assembly)
        {
        }

        public override void Configure(Container container)
        {
            // var factory = new SessionFactoryManager().CreateSessionFactory();

            DependencyConfiguration.Configure(container);

            Routes.Add<AuthenticationRequest>("/authentication")
                  .Add<AuthenticationRequest>("/authentication/{UserName}/{Password}")
                  .Add<ClaimsRequest>("/claims")
                  .Add<SecuredServiceRequest>("/secure");

            var authFeature = 
                new AuthFeature(
                    () => new CustomSession(),
                    new IAuthProvider[]
                        {
                            new TestAuthProvider()
                        });

            //authFeature.ServiceRoutes.Remove(typeof(AuthService));

            Plugins.Add(authFeature);
        }
    }
}