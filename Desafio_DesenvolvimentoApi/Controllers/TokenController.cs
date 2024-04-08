using Desafio_Api.Interfaces;
using Desafio_Core.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        public TokenController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] LoginRequest login)
        {
            var token = _tokenService.GetToken(login);

            if (!string.IsNullOrWhiteSpace(token))
            {
                return Ok(token);
            }

            return Unauthorized();
        }
    }
}
