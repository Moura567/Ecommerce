using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public interface IProductRepo
    {
        void Add(product product);

        void Update(product product);
        void Delete(product product);
        product GetByID(int id);
        product GetByName(string name);
        public IEnumerable<product> SearchProducts(string query, int categoryId);
        IEnumerable<product> GetAll();
        void Save();

    }
}
