using FlixOne.InventoryManagement.Repositories;

namespace FlixOne.InventoryManagementTests {
    [TestClass]
    public class InventoryContextTests {
        [TestMethod]
        public void MaintainBooks_Successful() {
            var context = new InventoryContext();

            foreach (var id in Enumerable.Range(0, 30)) {
                context.AddBook($"Book_{id}");
            }

            foreach(var quantity in Enumerable.Range(0, 10)) {
                foreach (var id in Enumerable.Range(0, 30)) {
                    context.UpdateQuantity($"Book_{id}", quantity);
                }
            }
            foreach (var quantity in Enumerable.Range(0, 10)) {
                foreach (var id in Enumerable.Range(0, 30)) {
                    context.UpdateQuantity($"Book_{id}", -quantity);
                }
            }

            foreach (var book in context.GetBooks()) {
                Assert.AreEqual(0, book.Quantity);
            }
        }
    }
}
