using Desafio_Core.Models;

namespace Desafio_Data.Interface
{
    public interface IUserRepository
    {
        User? Get(long id);
        IList<User> GetAll();
        User Add(User user);
        void Update(User user);
        void Delete(long id);        
    }
}