using P7CreateRestApi.Models;

namespace P7CreateRestApi.Services
{
    public interface ILoginService
    {
        Task<string?> LoginAsync(LoginModel loginModel);
    }
}
