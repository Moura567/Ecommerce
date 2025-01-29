using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public interface ICategoryRepo
    {
        void Add(Category category);

        void Update(Category category);
        void Delete(Category category);
        Category GetByID(int id);
        Category GetByName(string name);
        IEnumerable<product>GetProducts(int id);
        IEnumerable<Category> GetAll();
        void Save();
        string GetName(int id);
    
    }
}
