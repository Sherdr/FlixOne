using FlixOne.InventoryManagement.Interfaces;
using FlixOne.InventoryManagement.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Authentication.ExtendedProtection;

namespace FlixOne.InventoryManagementTests {
    [TestClass]
    public class InventoryContextTests {
        ServiceProvider Services { get; set; }

        [TestInitialize]
        public void Startup() {
            var services = new ServiceCollection();
            services.AddSingleton<IInventoryContext, InventoryContext>();
            Services = services.BuildServiceProvider();
        }

        [TestMethod]
        public void MaintainBooks_Successful() {
            List<Task> tasks = new List<Task>();

            foreach (var id in Enumerable.Range(1, 30)) {
                tasks.Add(AddBook($"Book_{id}"));
            }
            Task.WaitAll(Task.WhenAll(tasks));
            tasks.Clear();

            foreach(var quantity in Enumerable.Range(1, 10)) {
                foreach (var id in Enumerable.Range(1, 30)) {
                    tasks.Add(UpdateQuantiry($"Book_{id}", quantity));
                }
            }
            foreach (var quantity in Enumerable.Range(1, 10)) {
                foreach (var id in Enumerable.Range(1, 30)) {
                    tasks.Add(UpdateQuantiry($"Book_{id}", -quantity));
                }
            }
            Task.WaitAll(Task.WhenAll(tasks));
            tasks.Clear();

            foreach (var book in Services.GetService<IInventoryContext>().GetBooks()) {
                Assert.AreEqual(0, book.Quantity);
            }
        }

        public Task AddBook(string name) {
            return Task.Run(() => {
                Assert.IsTrue(Services.GetService<IInventoryContext>().AddBook(name));
            });
        }

        public Task UpdateQuantiry(string name, int quantity) {
            return Task.Run(() => {
                Assert.IsTrue(Services.GetService<IInventoryContext>().UpdateQuantity(name, quantity));
            });
        }
    }
}
