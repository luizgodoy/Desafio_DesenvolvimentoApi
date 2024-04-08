using Desafio_Api.Interfaces;
using Desafio_Core.ViewModels;
using Desafio_Data.Interface;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Desafio_Api.Services
{
    public class TokenService : ITokenService
    {
        // Configura a injeção de dependência das configurações do appSettings na nossa service
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;

        public TokenService(IConfiguration configuration, IUserRepository userRepository)
        {
            _configuration = configuration;
            _userRepository = userRepository;
        }

        public string GetToken(LoginRequest auth)
        {
            // TODO
            // Validar o RawToken
            // CheckRawToken(auth);

            // Recuperar o usuário do banco de dados
            var user = _userRepository.Get(auth.UserId);

            if (user is null) throw new UnauthorizedAccessException();

            // Variável responsável por gerar o token
            var tokenHandler = new JwtSecurityTokenHandler();

            // Recupera a chave que criamos no nosso appSettings e convert para um array de bytes
            var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("SecretJWT"));

            // O Descriptor é responsável por definir todas as propriedades que o nosso token terá quando descriptografarmos
            var tokenProps = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, (user.Role.ToString())),
                }),

                // Tempo de expiração do token
                Expires = DateTime.UtcNow.AddHours(8),

                // Adiciona a nossa chave de criptografia
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            // Cria o nosso token e devolve pro método solicitante
            var token = tokenHandler.CreateToken(tokenProps);
            return tokenHandler.WriteToken(token);
        }
    }
}
