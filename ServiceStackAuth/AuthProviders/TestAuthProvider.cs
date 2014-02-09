namespace ServiceStackAuth.AuthProviders
{
    using System.Net;

    using ServiceStack.Common.Web;
    using ServiceStack.ServiceInterface;
    using ServiceStack.ServiceInterface.Auth;

    public class TestAuthProvider
        : CredentialsAuthProvider
    {
        public TestAuthProvider()
        {
            Provider = Name;
        }

        public static new string Name
        {
            get
            {
                return "TestAuthProvider";
            }
        }

        public override object Authenticate(IServiceBase authService, IAuthSession session, Auth request)
        {
            if (base.TryAuthenticate(authService, request.UserName, request.Password))
            {
                if (session.UserAuthName == null)
                {
                    session.UserAuthName = request.UserName;
                }

                this.OnAuthenticated(authService, session, null, null);

                return new AuthResponse
                {
                    UserName = request.UserName,
                    SessionId = session.Id,
                    ReferrerUrl = string.Empty
                };

                //session.IsAuthenticated = true;

                //var sessionKey = SessionFeature.GetSessionKey();
                //CacheClient.CacheSet(sessionKey, userSession);
                //var response = base.Authenticate(authService, session, request);
                ////var cast

                //if (response is AuthResponse)// && customSession != null)
                //{
                //    // cast
                //    var authResponse = response as AuthResponse;

                //    //// build custom response
                //    //var customAuthResponse = new CustomAuthResponse
                //    //{
                //    //    ReferrerUrl = authResponse.ReferrerUrl,
                //    //    SessionExpiry = customSession.SessionExpires,
                //    //    SessionId = authResponse.SessionId,
                //    //    ResponseStatus = authResponse.ResponseStatus,
                //    //    UserName = authResponse.UserName
                //    //};
                //    //return customAuthResponse;
                //}

                // return the standard response
                //return response;
            }

            return new HttpError(HttpStatusCode.Forbidden, "Error");
        }
    }
}