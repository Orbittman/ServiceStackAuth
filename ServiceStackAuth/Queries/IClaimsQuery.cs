namespace ServiceStackAuth.Queries
{
    public interface IClaimsQuery
    {
        string[] GetClaims(string userName);
    }
}