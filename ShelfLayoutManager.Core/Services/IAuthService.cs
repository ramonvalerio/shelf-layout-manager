namespace ShelfLayoutManager.Core.Services
{
    public interface IAuthService
    {
        Task<bool> RegisterUser(string userName, string password);
        Task<string> GenerateTokenString(string userName);
        Task<bool> Login(string userName, string password);
    }
}