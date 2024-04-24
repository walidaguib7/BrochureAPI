using BrochureAPI.Models;

namespace BrochureAPI.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
