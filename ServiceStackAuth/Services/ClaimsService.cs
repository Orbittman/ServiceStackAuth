namespace ServiceStackAuth.Services
{
    using System;

    using ServiceStackAuth.Attributes;
    using ServiceStackAuth.Services.Requests;
    using ServiceStackAuth.Services.Responses;

    [AuthenticateClaims("http://cc.vouchercloud.com/claims/read")]
    public class ClaimsService
        : ServiceBase
    {
        public ClaimsResponse Get(ClaimsRequest request)
        {
            return new ClaimsResponse { Claims = UserSession.Claims };
        }
    }
}