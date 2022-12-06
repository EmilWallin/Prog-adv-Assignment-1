using EmilWallin_Inlämning_1.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmilWallin_Inlämning_1.Views.Category;

namespace EmilWallin_Inlämning_1.Views.MenuOptions
{
    internal class CategoryOption : MenuOption
    {
        private ProductCategories category { get; set; }
        private CategoryView categoryView { get; set; }

        public CategoryOption(ProductCategories category)
        {
            this.category = category;
            categoryView = new CategoryView(category);
            action = new Action(() => categoryView.Show());
        }

        public override string GetMenuOptionString(bool selected = false)
        {
            string categoryItems = Product.Products.Where(p => p.ProductCategory == category).Aggregate("", (acc, p) => acc += $"{p.Name,-14}").TrimEnd(',', ' ');

            StringBuilder output = new();

            output.AppendLine($"{CategoryName.Get(category)}:");
            output.Append($"\t{categoryItems}");

            if (selected) output = base.AddSelected(output);

            return output.ToString();
        }
    }
}