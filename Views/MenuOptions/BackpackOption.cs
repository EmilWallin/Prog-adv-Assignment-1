using EmilWallin_Inlämning_1.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmilWallin_Inlämning_1.Views.MenuOptions
{
    // Backpackoption, similar to productoption but holds a list of products to present them as a group
    internal class BackpackOption : MenuOption
    {
        private List<Product> products { get; set; }

        public BackpackOption(List<Product> products)
        {
            this.products = products;
            // Using the product will call the use method and remove one of the products from the backpack
            this.Action = () =>
            {
                Console.Clear();
                products[0].Use();
                User.User.Backpack.Inventory.Remove(products[0]);
                Console.WriteLine();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            };
        }

        public override string GetMenuOptionString(bool selected = false)
        {
            StringBuilder output = new();

            output.AppendLine($"{products.Count}x {products[0].Name}");
            output.Append($"\t{products[0].Description}");

            if (selected) output = AddSelected(output);

            return output.ToString();
        }

        public override StringBuilder AddSelected(StringBuilder output)
        {
            output = base.AddSelected(output);
            output.Append($"\n   [Enter] to use.");

            return output;
        }
    }
}