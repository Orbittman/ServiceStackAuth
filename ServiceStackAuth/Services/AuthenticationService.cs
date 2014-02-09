namespace ServiceStackAuth.Services
{
    using System;

    using ServiceStack.ServiceHost;
    using ServiceStack.ServiceInterface;
    using ServiceStack.ServiceInterface.Auth;

    public class AuthenticationService
        : ServiceBase
    {
        public AuthenticationResponse Delete(AuthenticationRequest logout)
        {
            using (var authService = ResolveService<AuthService>())
            {
                authService.Delete(new Auth());
            }

            return new AuthenticationResponse();
        }

        public AuthenticationResponse Post(AuthenticationRequest request)
        {
            using (var authService = ResolveService<AuthService>())
            {
                // authenticate the user's email and password provided
                var authResponse =
                    authService.Post(new Auth
                                         {
                                             Password = request.Password, 
                                             UserName = request.UserName,
                                             provider = "TestAuthProvider",
                                             RememberMe = false
                                         });

                if (authResponse is IHttpError)
                {
                    throw (Exception)authResponse;
                }
            }

            UserSession.IsAuthenticated = true;
            UserSession.Claims = new[] { "Claim1", "Claim2" };
            this.SaveSession(UserSession);

            return new AuthenticationResponse();
        }
    }
}