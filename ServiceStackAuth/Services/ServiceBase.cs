using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceStackAuth.Services
{
    using ServiceStack.ServiceInterface;
    using ServiceStack.ServiceInterface.Auth;

    using ServiceStackAuth.Bootstrap;
    using ServiceStackAuth.Sessions;

    public class ServiceBase
        : Service
    {
        public CustomSession UserSession
        {
            get
            {
                return base.SessionAs<CustomSession>();
            }
        }
    }
}