namespace ServiceStackAuth.Queries
{
    using System.Collections.Generic;

    public class ClaimsQuery : IClaimsQuery
    {
        private readonly Dictionary<string, string[]> _claimsRepo = new Dictionary<string, string[]>
                                                                        {
                                                                            {
                                                                                "User1",
                                                                                new[]
                                                                                    {
                                                                                        "http://www.ssauthtest.com/secured/delete"
                                                                                    }
                                                                            },
                                                                            {
                                                                                "User2",
                                                                                new[]
                                                                                    {
                                                                                        "http://www.ssauthtest.com/secured/read"
                                                                                    }
                                                                            }
                                                                        };
        public string[] GetClaims(string userName)
        {
            return this._claimsRepo.ContainsKey(userName) ? this._claimsRepo[userName] : new string[0];
        }
    }
}