using Dapper.Contrib.Extensions;
using Desafio_Core.Models;
using Desafio_Data.Interface;
using System.Data;

namespace Desafio_Data.Respository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _dbConnection;

        public ProductRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        /// <summary>
        /// Retorna as informações de um usuário especificado
        /// </summary>
        /// <param name="id">Id do usuário na base de dados</param>
        /// <returns>Retorna um objeto do tipo Usuario com as informações cadastradas</returns>
        public Product Get(long id)
        {
            return _dbConnection.Get<Product>(id);
        }

        /// <summary>
        /// Retorna todos os usuários da base
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public IList<Product> GetAll()
        {
            return _dbConnection.GetAll<Product>().ToList();
        }

        /// <summary>
        /// Insere um novo usuário na base de dados
        /// </summary>
        /// <param name="entity">Classe do tipo Entity</param>
        /// <returns></returns>
        public Product Add(Product prod)
        {
            prod.Id = (long)_dbConnection.Insert<Product>(prod);
            return prod;
        }
        
        public void Update(Product prod)
        {
            _dbConnection.Update<Product>(prod);
        }        

        /// <summary>
        /// Exclui um produto da base de dados
        /// </summary>
        /// <param name="id">Código do produto</param>
        public void Delete(long id)
        {
            var delete = Get(id);

            if (delete is null || delete.Id.Equals(0)) return;

            _dbConnection.Delete<Product>(delete);
        }        
    }
}