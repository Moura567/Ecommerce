using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly Context context;

        public CategoryRepo(Context context)
        {
            this.context = context;
        }
        public void Add(Category category)
        {
            context.Add(category);
        }

        public void Delete(Category category)
        {
            context.Remove(category);
        }

        public IEnumerable<Category> GetAll()
        {
           return context.categories.ToList();
        }

        public IEnumerable<product> GetProducts(int id)
        {
            return context.products.Where(x=>x.categoryId == id).ToList();
        }
        public Category GetByID(int id)
        {
            return context.categories.Find(id);
        }

        public Category GetByName(string name)
        {
            return context.categories.FirstOrDefault(c => c.Name == name);
        }

        public string GetName(int id)
        {
            var category=GetByID(id);
            return category.Name;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Category category)
        {
            context.categories.Update(category);
        }
    }
}
