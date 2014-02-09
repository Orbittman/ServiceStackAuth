namespace ServiceStackAuth.Services.Requests
{
    public class AuthenticationRequest
    {
        public string Id { get; set; }

        public string Password { get; set; }

        public string UserName { get; set; }
    }
}