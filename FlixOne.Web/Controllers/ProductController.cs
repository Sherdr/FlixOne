using FlixOne.Web.Common;
using FlixOne.Web.Models;
using FlixOne.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace FlixOne.Web.Controllers {
    public class ProductController : Controller {
        private readonly IInventoryRepository repository;

        public ProductController(IInventoryRepository inventoryRepository) {
            repository = inventoryRepository;
        }

        public IActionResult Index() {
            return View(repository.GetProducts().ToProductVM());
        }

        public IActionResult Details(Guid id) {
            return View(repository.GetProduct(id).ToProductVM());
        }

        public IActionResult Create() {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create([FromBody] Product product) {
            try {
                repository.AddProduct(product);
                return RedirectToAction(nameof(Index));
            }
            catch {
                return View();
            }
        }

        public IActionResult Edit(Guid id) {
            return View(repository.GetProduct(id));
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [FromBody] Product product) {
            try {
                repository.UpdateProduct(product);
                return RedirectToAction(nameof(Index));
            }
            catch {
                return View();
            }
        }

        public IActionResult Delete(Guid id) {
            return View(repository.GetProduct(id));
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Delete(Guid id, [FromBody] Product product) {
            try {
                repository.RemoveProduct(product);
                return RedirectToAction(nameof(Index));
            }
            catch {
                return View();
            }
        }
    }
}
