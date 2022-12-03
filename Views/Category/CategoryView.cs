using EmilWallin_Inlämning_1.Products;
using EmilWallin_Inlämning_1.Views.MenuOptions;
using EmilWallin_Inlämning_1.Views.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmilWallin_Inlämning_1.Views.Category
{
    // Category viewing class. Used for viewing products of a given category
    internal class CategoryView : View
    {
        public ProductCategories Category { get; set; }

        public CategoryView(ProductCategories category)
        {
            Category = category;

            MenuOptions.AddRange(Product.Products.Where(p => p.ProductCategory == category).Select(p => new ProductOption(p)).ToList());
        }

        public override void Show()
        {
            while (true)
            {
                Console.Clear();
                PrintVendingMachineHeader();

                PrintMenuOptions();

                Console.ReadKey();
            }
        }
    }
}