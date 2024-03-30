using TaskDay8P2.Models;

namespace TaskDay8P2.RepositoryServices
{
    public interface IProductRepositry
    {
        public List<Product> GetAll();
        public Product GetById(int id);
        public void Create(Product customer);
        public void DeleteById(int id);
        public void UpdateById(int id, Product customer);
    }
}
