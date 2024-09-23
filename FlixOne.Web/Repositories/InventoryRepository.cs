using FlixOne.Web.Contexts;
using FlixOne.Web.Models;
using FlixOne.Web.Services;
using Microsoft.EntityFrameworkCore;

namespace FlixOne.Web.Repositories {
    public class InventoryRepository : IInventoryRepository {
        private readonly InventoryContext context;

        public InventoryRepository(InventoryContext inventoryContext) {
            context = inventoryContext;
        }

        public bool AddCategory(Category category) {
            context.Categories.Add(category);
            return context.SaveChanges() > 0;
        }

        public bool AddProduct(Product product) {
            context.Products.Add(product);
            return context.SaveChanges() > 0;
        }

        public IEnumerable<Category> GetCategories() {
            return context.Categories.ToList();
        }

        public Category GetCategory(Guid id) {
            return context.Categories.FirstOrDefault(x => x.Id == id);
        }

        public Product GetProduct(Guid id) {
            return context.Products.Include(c => c.Category).FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Product> GetProducts() {
            return context.Products.Include(c => c.Category).ToList();
        }

        public bool RemoveCategory(Category category) {
            context.Remove(category);
            return context.SaveChanges() > 0;
        }

        public bool RemoveProduct(Product product) {
            context.Remove(product);
            return context.SaveChanges() > 0;
        }

        public bool UpdateCategory(Category category) {
            context.Update(category);
            return context.SaveChanges() > 0;
        }

        public bool UpdateProduct(Product product) {
            context.Update(product);
            return context.SaveChanges() > 0;
        }
    }
}
