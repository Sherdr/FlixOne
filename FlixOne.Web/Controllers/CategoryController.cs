using FlixOne.Web.Models;
using FlixOne.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace FlixOne.Web.Controllers {
    public class CategoryController : Controller {
        private readonly IInventoryRepository repository;

        public CategoryController(IInventoryRepository inventoryRepository) {
            repository = inventoryRepository;
        }
        public IActionResult Index() {
            return View(repository.GetCategories());
        }

        public IActionResult Details(Guid id) {
            return View(repository.GetCategory(id));
        }

        public IActionResult Create() {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create([FromBody] Category category) {
            try {
                repository.AddCategory(category);
                return RedirectToAction(nameof(Index));
            }
            catch {
                return View();
            }
        }

        public IActionResult Edit(Guid id) {
            return View(repository.GetCategory(id));
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [FromBody] Category category) {
            try {
                repository.UpdateCategory(category);
                return RedirectToAction(nameof(Index));
            }
            catch {
                return View();
            }
        }

        public IActionResult Delete(Guid id) {
            return View(repository.GetCategory(id));
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Delete(Guid id, [FromBody] Category category) {
            try {
                repository.RemoveCategory(category);
                return RedirectToAction(nameof(Index));
            }
            catch {
                return View();
            }
        }
    }
}
