using Microsoft.IdentityModel.Tokens;
using reto_bcp_api.Dtos.Auth;

namespace reto_bcp_api.Services.Interfaces
{
    public interface IAuthService
    {
        string Login(LoginDto loginDto);
    }
}