namespace ServiceStackAuth.Sessions
{
    using System.Linq;

    using ServiceStack.ServiceInterface.Auth;

    public class CustomSession : AuthUserSession
    {
        public string[] Claims { get; set; }

        public bool HasAnyClaims(string[] claims)
        {
            return Claims.Any(claims.Contains);
        }
    }
}