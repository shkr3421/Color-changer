using ADODemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ADODemo.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductRepository _repo;
        public ProductsController(IConfiguration config)
        {
            _repo = new ProductRepository(config);
        }
        public IActionResult Index()
        {
            List<Product> products = _repo.GetAll();
            return View(products);
        }
        //CREATE GET
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            _repo.Add(product);
            return RedirectToAction("Index");
        }
        //Edit GET
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _repo.GetById(id);
            if (product == null) return NotFound();
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _repo.Update(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }
        //DELETE GET
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = _repo.GetById(id);
            if (product == null) return NotFound();
            return View(product);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _repo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}