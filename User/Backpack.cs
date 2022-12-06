using EmilWallin_Inlämning_1.Products;
using EmilWallin_Inlämning_1.Products.Chocolate;
using EmilWallin_Inlämning_1.Products.Sodas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmilWallin_Inlämning_1.User
{
    internal class Backpack
    {
        public List<Product> Inventory { get; }

        public Backpack()
        {
            // Temp initialization with products for testing
            Inventory = new()
            {
                new CocaCola(),
                new CocaCola(),
                new CocaCola(),
                new CocaCola(),
                new Snickers(),
                new Snickers(),
                new Snickers(),
                new Twix()
            };
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