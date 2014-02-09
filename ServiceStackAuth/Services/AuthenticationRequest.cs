namespace ServiceStackAuth.Services
{
    using ServiceStack.ServiceHost;

    public class AuthenticationRequest
    {
        public string Id { get; set; }

        public string Password { get; set; }

        public string UserName { get; set; }
    }
}