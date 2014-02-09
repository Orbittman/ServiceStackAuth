namespace ServiceStackAuth.Queries
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ServiceStackAuth.Models.Output;
    using ServiceStackAuth.Models.Requests;

    public class UserQuery : IUserQuery
    {
        private readonly Dictionary<string, UserModel> _users = new Dictionary<string, UserModel>
                                                           {
                                                               {
                                                                   "User1",
                                                                   new UserModel
                                                                       {
                                                                           Password
                                                                               =
                                                                               "user1",
                                                                           UserName
                                                                               =
                                                                               "User1"
                                                                       }
                                                               },
                                                               {
                                                                   "User2",
                                                                   new UserModel
                                                                       {
                                                                           Password
                                                                               =
                                                                               "user2",
                                                                           UserName
                                                                               =
                                                                               "User2"
                                                                       }
                                                               }
                                                           };
        public Task<UserModel> Execute(UserByUserNameRequest request)
        {
            return Task.Factory.StartNew(() => _users.ContainsKey(request.UserName) ? _users[request.UserName] : null);
        }
    }
}