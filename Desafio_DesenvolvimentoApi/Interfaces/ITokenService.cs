using Desafio_Core.ViewModels;

namespace Desafio_Api.Interfaces
{
    public interface ITokenService
    {
        public string GetToken(LoginRequest auth);
    }
}
