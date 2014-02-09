namespace ServiceStackAuth.Queries
{
    using System.Threading.Tasks;

    using ServiceStackAuth.Models.Output;
    using ServiceStackAuth.Models.Requests;

    public interface IUserQuery
    {
        Task<UserModel> Execute(UserByUserNameRequest request);
    }
}
