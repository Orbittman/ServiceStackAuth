namespace ServiceStackAuth.Services
{
    using System;

    using ServiceStack.ServiceHost;
    using ServiceStack.ServiceInterface;
    using ServiceStack.ServiceInterface.Auth;

    using ServiceStackAuth.AuthProviders;
    using ServiceStackAuth.Queries;
    using ServiceStackAuth.Services.Requests;
    using ServiceStackAuth.Services.Responses;

    public class AuthenticationService
        : ServiceBase
    {
        private readonly IClaimsQuery _claimsQuery;

        public AuthenticationService(IClaimsQuery claimsQuery)
        {
            _claimsQuery = claimsQuery;
        }

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
                                             provider = TestAuthProvider.Name,
                                             RememberMe = false
                                         });

                if (authResponse is IHttpError)
                {
                    throw (Exception)authResponse;
                }
            }

            UserSession.IsAuthenticated = true;
            UserSession.Claims = _claimsQuery.GetClaims(UserSession.UserName);
            this.SaveSession(UserSession);

            return new AuthenticationResponse();
        }
    }
}