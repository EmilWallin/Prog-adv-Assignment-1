using EmilWallin_Inlämning_1.Navigation;
using EmilWallin_Inlämning_1.Products;
using EmilWallin_Inlämning_1.Products.Chocolate;
using EmilWallin_Inlämning_1.Products.EnergyDrinks;
using EmilWallin_Inlämning_1.Products.Sodas;
using EmilWallin_Inlämning_1.Views.MenuOptions;
using EmilWallin_Inlämning_1.Views.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EmilWallin_Inlämning_1.Navigation.InputEnums;

namespace EmilWallin_Inlämning_1.Views.MainView
{
    // Main view class. Called upon from Program.Main(). Console main menu
    internal class MainView : View
    {
        private User.Wallet wallet { get; set; }

        public MainView()
        {
            // Initialize Products array for showing supply
            Product.Products = new Product[]
            {
                new Snickers(),
                new Twix(),
                new Mars(),
                new RedBull(),
                new Powerking(),
                new Monster(),
                new CocaCola(),
                new Fanta(),
                new Sprite()
            };

            // Initialize category menu options
            foreach (var category in (ProductCategories[])Enum.GetValues(typeof(ProductCategories)))
            {
                MenuOptions.Add(new CategoryOption(category));
            }

            BackpackView bpView = new();

            MenuOptions.Add(new CustomOption("Backpack", () => bpView.Show()));
            MenuOptions.Add(new CustomOption("Check Balance", () => User.User.Wallet.PrintBalance()));
        }

        public override void Show()
        {
            while (true)
            {
                Console.Clear();
                PrintVendingMachineHeader();

                PrintMenuOptions();
                SelectedIndex = InputHandler.HandleInput(MenuOptions, SelectedIndex);

                if (SelectedIndex == -1)
                {
                    PrintGoodbyeMessage();
                    return;
                }
            }
        }

        private void PrintGoodbyeMessage()
        {
            Console.Clear();
            Console.WriteLine("Now leaving the vending machine app.");
            Console.WriteLine("Goodbye!");
            Thread.Sleep(1000);
        }

        protected override void PrintMenuOptions()
        {
            base.PrintMenuOptions();
        }
    }
}