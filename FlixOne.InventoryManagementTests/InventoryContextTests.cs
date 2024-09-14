using FlixOne.InventoryManagement.Repositories;

namespace FlixOne.InventoryManagementTests {
    [TestClass]
    public class InventoryContextTests {
        [TestMethod]
        public void MaintainBooks_Successful() {
            var context = InventoryContext.Singleton;
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

            foreach (var book in context.GetBooks()) {
                Assert.AreEqual(0, book.Quantity);
            }
        }

        public Task AddBook(string name) {
            return Task.Run(() => {
                var context = InventoryContext.Singleton;
                Assert.IsTrue(context.AddBook(name));
            });
        }

        public Task UpdateQuantiry(string name, int quantity) {
            return Task.Run(() => {
                var context = InventoryContext.Singleton;
                Assert.IsTrue(context.UpdateQuantity(name, quantity));
            });
        }
    }
}
