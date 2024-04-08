using Dapper.Contrib.Extensions;
using Desafio_Core.Models;
using Desafio_Data.Interface;
using System.Data;

namespace Desafio_Data.Respository
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnection _dbConnection;

        public UserRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        /// <summary>
        /// Retorna as informações de um usuário especificado
        /// </summary>
        /// <param name="id">Id do usuário na base de dados</param>
        /// <returns>Retorna um objeto do tipo Usuario com as informações cadastradas</returns>
        public User Get(long id)
        {
            return _dbConnection.Get<User>(id);
        }

        /// <summary>
        /// Retorna todos os usuários da base
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public IList<User> GetAll()
        {
            return _dbConnection.GetAll<User>().ToList();
        }

        /// <summary>
        /// Insere um novo usuário na base de dados
        /// </summary>
        /// <param name="entity">Classe do tipo Entity</param>
        /// <returns></returns>
        public User Add(User user)
        {
            user.Id = (long) _dbConnection.Insert<User>(user);
            return user;
        }
        
        public void Update(User user)
        {
            _dbConnection.Update<User>(user);
        }        

        /// <summary>
        /// Exclui um usuário da base de dados
        /// </summary>
        /// <param name="id">Código do usuário</param>
        public void Delete(long id)
        {
            var delete = Get(id);

            if (delete is null || delete.Id.Equals(0)) return;

            _dbConnection.Delete<User>(delete);
        }        
    }
}