using FlixOne.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace FlixOne.Web.Contexts {
    public class InventoryContext : DbContext {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options) { }

        public InventoryContext() { }
    }
}
