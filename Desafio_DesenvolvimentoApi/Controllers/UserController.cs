using Desafio_Core.Enums;
using Desafio_Core.Models;
using Desafio_Data.Interface;
using Desafio_Logging.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<User> _logger;
        public UserController(IUserRepository userRepository, ILogger<User> logger)
        {
            _userRepository = userRepository;
            _logger = logger;

            CustomLogger.TryWriteInLogFile = true;
        }

        /// <summary>
        /// Retorna lista de usuários cadastrados
        /// </summary>
        /// <returns>Lista de usuários</returns>
        [HttpGet("GetAllUsers")]
        [Authorize]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_userRepository.GetAll());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Mensagem: {ex.Message}\r\nStackTrace: {ex.StackTrace}", ex);
                return StatusCode(500, ex);
            }
        }

        /// <summary>
        /// Recupera dado do usuário identificado pelo código
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Entidade usuário</returns>
        [HttpGet("GetUser")]
        [Authorize]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_userRepository.Get(id));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Mensagem: {ex.Message}\r\nStackTrace: {ex.StackTrace}", ex);
                return StatusCode(500, ex);
            }
        }

        /// <summary>
        /// Exclusão de usuários
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteUser")]
        [Authorize(Roles = Scope.Administrator)]
        public IActionResult Delete(int id)
        {
            try
            {
                _userRepository.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Mensagem: {ex.Message}\r\nStackTrace: {ex.StackTrace}", ex);
                return StatusCode(500, ex);
            }
        }

        /// <summary>
        /// Insere um novo usuário ao sistema
        /// </summary>
        /// <param name="user">Objeto Usuário</param>
        /// <returns>Entidade usuário</returns>
        [HttpPost("AddUser")]
        [Authorize]
        public IActionResult AddUser(User user)
        {            
            try
            {
                var result = _userRepository.Add(user);
                return Created("", result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Mensagem: {ex.Message}\r\nStackTrace: {ex.StackTrace}", ex);
                return StatusCode(500, ex);
            }
        }

        /// <summary>
        /// Atualiza dados um usuário
        /// </summary>
        /// <param name="user">Objeto Usuário</param>
        /// <returns>Entidade usuário</returns>
        [HttpPost("UpdateUser")]
        [Authorize]
        public IActionResult UpdateUser(User user)
        {
            _userRepository.Update(user);
            return NoContent();
        }
    }
}