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
        private Product product { get; set; }

        public ProductOption(Product product)
        {
            this.product = product;
        }

        public override string GetMenuOptionString(bool selected = false)
        {
            StringBuilder output = new();

            output.AppendLine($"{product.Name,-25}Price: {product.Price}kr");
            output.Append($"\t{product.Description}");

            if (selected) output = base.AddSelected(output);

            return output.ToString();
        }
    }
}