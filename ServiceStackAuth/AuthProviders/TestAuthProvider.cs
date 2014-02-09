namespace ServiceStackAuth.AuthProviders
{
    using System.Collections.Generic;
    using System.Net;

    using ServiceStack.Common.Web;
    using ServiceStack.ServiceInterface;
    using ServiceStack.ServiceInterface.Auth;
    using ServiceStack.ServiceInterface.ServiceModel;

    public class TestAuthProvider
        : CredentialsAuthProvider
    {
        public TestAuthProvider()
        {
            Provider = "TestAuthProvider";
        }

        public override object Authenticate(ServiceStack.ServiceInterface.IServiceBase authService, IAuthSession session, Auth request)
        {
            if (base.TryAuthenticate(authService, request.UserName, request.Password))
            {
                if (session.UserAuthName == null)
                {
                    session.UserAuthName = request.UserName;
                }
                this.OnAuthenticated(authService, session, (IOAuthTokens)null, (Dictionary<string, string>)null);
                return new AuthResponse()
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