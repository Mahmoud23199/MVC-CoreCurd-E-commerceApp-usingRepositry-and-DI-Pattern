using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TaskDay8P2.Models;
using TaskDay8P2.RepositoryServices;

namespace TaskDay8P2.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepositry productRepositry;
        private readonly ICustomerRepositry customerRepo;

        public ProductController(IProductRepositry productRepositry, ICustomerRepositry customerRepo)
        {
            this.productRepositry = productRepositry;
            this.customerRepo = customerRepo;
        }
        // GET: ProuductController
        public ActionResult Index()
        {
            return View(productRepositry.GetAll());
        }

        // GET: ProuductController/Details/5
        public ActionResult Details(int id)
        {
            return View(productRepositry.GetById(id));
        }

        // GET: ProuductController/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(customerRepo.GetAll(), "Id", "Name");
            return View();
        }
        [HttpGet]
        public ActionResult Create(int id)
        {
            ViewBag.CustomerId = new SelectList(customerRepo.GetAll(), "Id", "Name",id);
            return View();
        }

        // POST: ProuductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {  if(product.Id != 0)
            {
                product.Id = 0;
            }
            ViewBag.CustomerId = new SelectList(customerRepo.GetAll(), "Id", "Name");
            try
            {
                if (ModelState.IsValid) 
                {
                    productRepositry.Create(product);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(product);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: ProuductController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.CustomerId = new SelectList(customerRepo.GetAll(), "Id", "Name",id);

            return View(productRepositry.GetById(id));
        }

        // POST: ProuductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    productRepositry.UpdateById(id,product);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(product);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: ProuductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(productRepositry.GetById(id));
        }

        // POST: ProuductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Product product)
        {

            try
            {
               
                    productRepositry.DeleteById(id);
                    return RedirectToAction(nameof(Index));
              
            }
            catch
            {
                return View(product);
            }
        }
    }
}
