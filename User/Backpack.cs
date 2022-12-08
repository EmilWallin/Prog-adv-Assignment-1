using EmilWallin_Inlämning_1.Products;
using EmilWallin_Inlämning_1.Products.Chocolate;
using EmilWallin_Inlämning_1.Products.Sodas;

namespace EmilWallin_Inlämning_1.User
{
    // Class for holding user inventory
    internal class Backpack
    {
        public List<Product> Inventory { get; }

        public Backpack()
        {
            Inventory = new();
        }

        public void AddItem(Product item)
        {
            Inventory.Add(item);
        }

        public void Use(Product item)
        {
            // Guard clause checking if inventory contains a correct product
            if (!Inventory.Any(i => Type.Equals(i, item))) return;

            // Use the item and remove from list
            item.Use();
            Inventory.Remove(Inventory.First(i => Type.Equals(i, item)));
        }
    }
}