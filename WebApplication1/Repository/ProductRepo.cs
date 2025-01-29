
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class ProductRepo : IProductRepo
    {
        private readonly Context context;

        public ProductRepo(Context context)
        {
            this.context = context;
        }
        public void Add(product product)
        {
            context.Add(product);
        }

        public IEnumerable<product> SearchProducts(string query, int categoryId)
        {
            var products = context.products.AsQueryable();

            // Apply search query filter
            if (!string.IsNullOrEmpty(query))
            {
                products = products.Where(p => p.Name.Contains(query) || p.Description.Contains(query));
            }

            // Apply category filter
            if (categoryId!=null)
            {
                products = products.Where(p => p.categoryId == categoryId);
            }

            return products.ToList();
        }


        public void Delete(product product)
        {
            context.Remove(product);
        }

        public IEnumerable<product> GetAll()
        {
            return context.products.ToList();
        }

        public product GetByID(int id)
        {
            return context.products.Find(id);
        }

        public product GetByName(string name)
        {
            return (context.products.FirstOrDefault(x => x.Name == name));
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(product product)
        {
            context.Update(product);
        }
    }
}
