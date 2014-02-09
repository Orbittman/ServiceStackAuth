namespace ServiceStackAuth.Services
{
    using ServiceStack.ServiceInterface;

    [Authenticate]
    public class ClaimsService
        : ServiceBase
    {
        public ClaimsResponse Get(ClaimsRequest request)
        {
            return new ClaimsResponse { Claims = UserSession.Claims };
        }
    }

    public class ClaimsRequest
    {
    }

    public class ClaimsResponse
    {
        public string[] Claims { get; set; }
    }
}