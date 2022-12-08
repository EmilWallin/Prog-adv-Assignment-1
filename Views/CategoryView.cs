using EmilWallin_Inlämning_1.Products;
using EmilWallin_Inlämning_1.Views.MenuOptions;

namespace EmilWallin_Inlämning_1.Views
{
    // Category viewing class. Used for viewing products of a given category
    internal class CategoryView : View
    {
        public ProductCategories Category { get; set; }

        public CategoryView(ProductCategories category)
        {
            Category = category;

            // Create MenuOptions for each product of the given category
            MenuOptions.AddRange(Product.Products.Where(p => p.ProductCategory == category).Select(p => new ProductOption(p)).ToList());
        }

        public override void Show()
        {
            while (true)
            {
                Console.Clear();
                PrintVendingMachineHeader();

                PrintMenuOptions();
                SelectedIndex = InputHandler.HandleInput(MenuOptions, SelectedIndex);

                // -1 is returned from user pressing [Backspace] (aka return/exit)
                if (SelectedIndex == -1) return;
            }
        }
    }
}