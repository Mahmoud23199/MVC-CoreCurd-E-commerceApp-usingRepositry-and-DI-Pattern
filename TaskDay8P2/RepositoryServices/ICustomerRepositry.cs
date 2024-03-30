using TaskDay8P2.Models;

namespace TaskDay8P2.RepositoryServices
{
    public interface ICustomerRepositry
    {
        public List<Customer> GetAll();
        public Customer GetById(int id);
        public void Create(Customer customer);
        public void DeleteById(int id);
        public void UpdateById(int id ,Customer customer);

        public List<Product> GetCustProductById(int id);

    }
}
