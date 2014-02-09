namespace ServiceStackAuth.Attributes
{
    using System.Net;

    using ServiceStack;
    using ServiceStack.ServiceInterface;

    using ServiceStackAuth.Sessions;

    public class AuthenticateClaimsAttribute : AuthenticateAttribute
    {
        private readonly string[] _claims;

        public AuthenticateClaimsAttribute(params string[] claims)
        {
            this._claims = claims;
        }

        public override void Execute(ServiceStack.ServiceHost.IHttpRequest req, ServiceStack.ServiceHost.IHttpResponse res, object requestDto)
        {
            base.Execute(req, res, requestDto);

            if (res.IsClosed)
            {
                return;
            }

            var session = req.GetSession() as CustomSession;
            if (session != null && session.HasAnyClaims(this._claims))
            {
                return;
            }


            res.StatusCode = (int)HttpStatusCode.Forbidden;
            res.EndRequest();
        }
    }
}