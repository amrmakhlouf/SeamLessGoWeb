using SeamLessGoWeb.Models;

namespace SeamLessGoWeb.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserSession?> LoginAsync(string username, string password);

    }
}
