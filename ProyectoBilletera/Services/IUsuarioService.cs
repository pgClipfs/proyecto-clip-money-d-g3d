using Clip.Models.Request;
using Clip.Models.Response;

namespace Clip.Services
{
    public interface IUsuarioService
    {
        LoginResponse Auth(AuthRequest request);
    }
}
