using Desafio_Core.Enums;
using Desafio_Core.Models;
using Desafio_Data.Interface;
using Desafio_Data.Respository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        /// <summary>
        /// Retorna lista de usuários cadastrados
        /// </summary>
        /// <returns>Lista de usuários</returns>
        [HttpGet("GetAllProducts")]
        [Authorize]
        public IActionResult RetornaTodosUsuarios()
        {
            return Ok(_productRepository.GetAll());
        }

        /// <summary>
        /// Recupera dado do usuário identificado pelo código
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Entidade usuário</returns>
        [HttpGet("GetProduct")]
        [Authorize]
        public IActionResult RetornaUsuarioPorId(int id)
        {
            return Ok(_productRepository.Get(id));
        }

        /// <summary>
        /// Exclusão de usuários
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteProduct")]
        [Authorize(Roles = Scope.Administrator)]
        public IActionResult Delete(int id)
        {
            _productRepository.Delete(id);
            return NoContent();
        }

        /// <summary>
        /// Insere um novo usuário ao sistema
        /// </summary>
        /// <param name="product">Objeto Usuário</param>
        /// <returns>Entidade usuário</returns>
        [HttpPost("AddProduct")]
        [Authorize]
        public IActionResult AddProduct(Product product)
        {
            var result = _productRepository.Add(product);
            return Created("", result);
        }

        /// <summary>
        /// Atualiza dados um usuário
        /// </summary>
        /// <param name="product">Objeto Usuário</param>
        /// <returns>Entidade usuário</returns>
        [HttpPost("UpdateProduct")]
        [Authorize]
        public IActionResult UpdateProduct(Product product)
        {
            _productRepository.Update(product);
            return NoContent();
        }
    }
}