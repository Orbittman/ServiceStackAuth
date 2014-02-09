namespace ServiceStackAuth.Services
{
    using ServiceStackAuth.Attributes;
    using ServiceStackAuth.Services.Requests;
    using ServiceStackAuth.Services.Responses;

    public class SecuredService
        : ServiceBase
    {
        [AuthenticateClaims("http://www.ssauthtest.com/secured/read")]
        public SecuredServiceResponse Get(SecuredServiceRequest request)
        {
            return new SecuredServiceResponse();
        }

        [AuthenticateClaims("http://www.ssauthtest.com/secured/delete")]
        public SecuredServiceResponse Delete(SecuredServiceRequest request)
        {
            return new SecuredServiceResponse();
        }
    }
}