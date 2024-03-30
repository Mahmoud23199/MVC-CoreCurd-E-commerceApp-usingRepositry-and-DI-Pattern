using TaskDay8P2.Models;

namespace TaskDay8P2.ViewModel
{
    public class Product_Cust_ViewModel
    {
        //(Customer ID, Customer Name along with All his Products Details) 
        public Customer customer { get; set; }
        public List<Product> custProduct { get; set; }

    }
}
