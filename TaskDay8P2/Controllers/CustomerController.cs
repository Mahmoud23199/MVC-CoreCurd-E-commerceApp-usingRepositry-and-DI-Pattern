using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskDay8P2.Models;
using TaskDay8P2.RepositoryServices;
using TaskDay8P2.ViewModel;

namespace TaskDay8P2.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepositry customerRepo;

        public CustomerController(ICustomerRepositry customerRepositry) 
        {
            this.customerRepo= customerRepositry;
        }
        // GET: CustomerController
        public ActionResult Index()
        {
            return View(customerRepo.GetAll());
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            Product_Cust_ViewModel _ViewModel = new Product_Cust_ViewModel()
            {
                customer = customerRepo.GetById(id),
                custProduct = customerRepo.GetCustProductById(id)
            };
            return View(_ViewModel);
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    customerRepo.Create(customer);
                    return RedirectToAction(nameof(Index));
                }
                else{
                     return View(customer);
                }
            }
            catch
            {
                return View(customer);
            }
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(customerRepo.GetById(id));
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Customer customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    customerRepo.UpdateById(id,customer);
                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    return View(customer);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {

            return View(customerRepo.GetById(id));
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                customerRepo.DeleteById(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
