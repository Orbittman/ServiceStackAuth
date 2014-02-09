namespace ServiceStackAuth.Bootstrap
{
    using System.Collections.Generic;

    using ServiceStack.ServiceInterface.Auth;

    using ServiceStackAuth.Models.Requests;
    using ServiceStackAuth.Queries;

    public class TestAuthRepository
        : IUserAuthRepository
    {
        private readonly IUserQuery _userQuery;

        public TestAuthRepository(IUserQuery userQuery)
        {
            this._userQuery = userQuery;
        }

        public UserAuth CreateUserAuth(UserAuth newUser, string password)
        {
            throw new System.NotImplementedException();
        }

        public UserAuth UpdateUserAuth(UserAuth existingUser, UserAuth newUser, string password)
        {
            throw new System.NotImplementedException();
        }

        public UserAuth GetUserAuthByUserName(string userNameOrEmail)
        {
            throw new System.NotImplementedException();
        }

        public bool TryAuthenticate(string userName, string password, out UserAuth userAuth)
        {
            userAuth = new UserAuth { UserName = userName };

            var user = _userQuery.Execute(new UserByUserNameRequest { UserName = userName }).Result;

            if (user != null && user.Password == password)
            {
                return true;
            }

            return false;
        }

        public bool TryAuthenticate(
            Dictionary<string, string> digestHeaders, string PrivateKey, int NonceTimeOut, string sequence, out UserAuth userAuth)
        {
            throw new System.NotImplementedException();
        }

        public void LoadUserAuth(IAuthSession session, IOAuthTokens tokens)
        {
            throw new System.NotImplementedException();
        }

        public UserAuth GetUserAuth(string userAuthId)
        {
            throw new System.NotImplementedException();
        }

        public void SaveUserAuth(IAuthSession authSession)
        {
            throw new System.NotImplementedException();
        }

        public void SaveUserAuth(UserAuth userAuth)
        {
            throw new System.NotImplementedException();
        }

        public List<UserOAuthProvider> GetUserOAuthProviders(string userAuthId)
        {
            return new List<UserOAuthProvider>();
        }

        public UserAuth GetUserAuth(IAuthSession authSession, IOAuthTokens tokens)
        {
            throw new System.NotImplementedException();
        }

        public string CreateOrMergeAuthSession(IAuthSession authSession, IOAuthTokens tokens)
        {
            throw new System.NotImplementedException();
        }
    }
}