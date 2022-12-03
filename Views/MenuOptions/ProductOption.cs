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

        public override string GetMenuOptionString(bool selected)
        {
            StringBuilder output = new();

            output.AppendLine($"{product.Name,-25}Price: {product.Price}");
            output.Append($"\tDescription: {product.Description}");

            if (selected) output.Insert(0, "==>");

            return output.ToString();
        }
    }
}