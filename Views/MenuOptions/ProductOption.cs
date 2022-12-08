using EmilWallin_Inlämning_1.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmilWallin_Inlämning_1.Views.MenuOptions
{
    internal class ProductOption : MenuOption
    {
        private Product Product { get; set; }

        public ProductOption(Product product)
        {
            this.Product = product;

            PurchaseView pv = new(Product);
            this.Action = () => pv.Show();
        }

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