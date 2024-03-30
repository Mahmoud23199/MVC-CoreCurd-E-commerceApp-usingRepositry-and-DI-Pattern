using Microsoft.EntityFrameworkCore;
using TaskDay8P2.Models;

namespace TaskDay8P2.RepositoryServices
{
    public class ProductRepositry : IProductRepositry
    {
        public AppDbContext context { get; }
        public ProductRepositry(AppDbContext context)
        {
            this.context=context;
        }

        public void Create(Product product)
        {
            if (product != null) 
            {
             context.Products.Add(product);
             context.SaveChanges();
            }
        }

        public void DeleteById(int id)
        {
            var currentP = context.Products.Include(c=>c.Customer).FirstOrDefault(p => p.Id == id);
            if (currentP != null)
            {
                context.Products.Remove(currentP);
                context.SaveChanges();

            }
        }

        public List<Product> GetAll()
        {
            return context.Products.Include(c=>c.Customer).ToList();
        }

        public Product GetById(int id)
        {
            var product = context.Products.Include(c => c.Customer).FirstOrDefault(i=>i.Id==id);
            if ( product != null)
            {
                return product;
            }
            else
            {
                throw new Exception("Not Found..!");
            }
        }

        public void UpdateById(int id, Product product)
        {
            context.Products.Update(product);
            context.SaveChanges();
        }
       
    }
}
