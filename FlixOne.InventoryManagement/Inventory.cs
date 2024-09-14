namespace FlixOne.InventoryManagement {
    public class Inventory {
        private int quantity;
        public object @lock = new object();

        public void RemoveQuantity(int amount) {
            lock (@lock) {
                if(quantity - amount < 0) {
                    throw new Exception("Cannot remove more than we have!");
                }
                quantity -= amount;
            }
        }
    }
}
