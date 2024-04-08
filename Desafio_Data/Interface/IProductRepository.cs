using Desafio_Core.Models;

namespace Desafio_Data.Interface
{
    public interface IProductRepository
    {
        Product? Get(long id);
        IList<Product> GetAll();
        Product Add(Product user);
        void Update(Product user);
        void Delete(long id);
    }
}