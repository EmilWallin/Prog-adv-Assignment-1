using EmilWallin_Inlämning_1.Products;
using EmilWallin_Inlämning_1.Products.Chocolate;
using EmilWallin_Inlämning_1.Products.EnergyDrinks;
using EmilWallin_Inlämning_1.Products.Sodas;
using EmilWallin_Inlämning_1.Views.MenuOptions;

namespace EmilWallin_Inlämning_1.Views.MainView
{
    // Main view class. Called upon from Program.Main(). Main Menu.
    internal class MainView : View
    {
        public MainView()
        {
            // Initialize Products array for showing supply throughout app
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

            // Additional options
            MenuOptions.Add(new CustomOption("Backpack", () => new BackpackView().Show()));
            MenuOptions.Add(new CustomOption("Check Balance", () => new WalletView().Show()));
        }

        public override void Show()
        {
            while (true)
            {
                Console.Clear();
                PrintVendingMachineHeader();

                base.PrintMenuOptions();
                SelectedIndex = InputHandler.HandleInput(MenuOptions, SelectedIndex);

                // -1 is returned from user pressing [Backspace] (aka return/exit)
                if (SelectedIndex == -1)
                {
                    PrintGoodbyeMessage();
                    return;
                }
            }
        }

        private static void PrintGoodbyeMessage()
        {
            Console.Clear();
            Console.WriteLine("Now leaving the vending machine app.");
            Console.WriteLine("Goodbye!");
            Thread.Sleep(1000);
        }
    }
}