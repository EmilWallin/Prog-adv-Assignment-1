using EmilWallin_Inlämning_1.Products;
using System.Text;

namespace EmilWallin_Inlämning_1.Views.MenuOptions
{
    // Menu option specified for category use. It will send the user to the inspect the category's products if selected.
    internal class CategoryOption : MenuOption
    {
        private ProductCategories Category { get; set; }
        private CategoryView CategoryView { get; set; }

        public CategoryOption(ProductCategories category)
        {
            Category = category;
            CategoryView = new CategoryView(category);
            Action = new Action(() => CategoryView.Show());
        }

        // Creates string of the category and its products for displaying in the menu
        public override string GetMenuOptionString(bool selected = false)
        {
            string categoryItems = Product.Products.Where(p => p.ProductCategory == Category).Aggregate("", (acc, p) => acc += $"{p.Name,-14}").TrimEnd(',', ' ');

            StringBuilder output = new();

            output.AppendLine($"{CategoryName.Get(Category)}:");
            output.Append($"\t{categoryItems}");

            if (selected) output = base.AddSelected(output);

            return output.ToString();
        }
    }
}