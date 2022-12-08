using EmilWallin_Inlämning_1.Products;
using System.Text;

namespace EmilWallin_Inlämning_1.Views.MenuOptions
{
    // Menu option specified for displaying product info
    internal class ProductOption : MenuOption
    {
        private Product Product { get; set; }

        public ProductOption(Product product)
        {
            Product = product;

            PurchaseView pv = new(Product);
            Action = () => pv.Show();
        }

        // Creates string of the product, its price, and its description for displaying in the menu
        public override string GetMenuOptionString(bool selected = false)
        {
            StringBuilder output = new();

            output.AppendLine($"{Product.Name,-25}Price: {Product.Price}kr");
            output.Append($"\t{Product.Description}");

            if (selected) output = base.AddSelected(output);

            return output.ToString();
        }
    }
}