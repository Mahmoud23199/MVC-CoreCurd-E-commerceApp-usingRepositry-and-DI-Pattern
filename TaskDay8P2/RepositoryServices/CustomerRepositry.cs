using Microsoft.EntityFrameworkCore;
using TaskDay8P2.Models;

namespace TaskDay8P2.RepositoryServices
{
    public class CustomerRepositry:ICustomerRepositry
    {
        public AppDbContext context { get; }
        public CustomerRepositry(AppDbContext context)
        {
            this.context = context;
        }

        public void Create(Customer customer)
        {
            if (customer != null)
            {
                context.Customers.Add(customer);
                context.SaveChanges();
            }
        }

        public void DeleteById(int id)
        {
            var currentP = context.Customers.FirstOrDefault(p => p.Id == id);
            if (currentP != null)
            {
                context.Customers.Remove(currentP);
                context.SaveChanges();
            }
        }

        public List<Customer> GetAll()
        {
            return context.Customers.Include(p=>p.Orders).ToList();
        }

        public Customer GetById(int id)
        {
            var customer = context.Customers.Find(id);
            if (customer != null)
            {
                return customer;
            }
            else
            {
                throw new Exception("Not Found..!");
            }
        }

        public void UpdateById(int id, Customer customer)
        {
            context.Customers.Update(customer);
            context.SaveChanges();

        }

        public List<Product> GetCustProductById(int id)
        {
          return context.Products.Where(i=>i.CustomerId==id).ToList();
        }
    }
}
