using EmilWallin_Inlämning_1.Products;
using EmilWallin_Inlämning_1.Views.MenuOptions;

namespace EmilWallin_Inlämning_1.Views
{
    // View for when user is purchasing a product
    internal class PurchaseView : View
    {
        private Product Product { get; }

        public PurchaseView(Product product)
        {
            Product = product;
        }

        public override void Show()
        {
            while (true)
            {
                Console.Clear();
                PrintVendingMachineHeader();

                UpdateMenuOptions();

                int inputBalance = User.User.Wallet.InputBalance;
                int remaining = Product.Price - inputBalance < 0 ? 0 : Product.Price - inputBalance;

                Console.WriteLine($"Purchasing a {Product.Name} for {Product.Price}kr.");
                Console.WriteLine();
                Console.WriteLine($"Your total remaining balance: {User.User.Wallet.Balance}");
                Console.WriteLine($"Input: {inputBalance}. Remaining: {remaining}");
                Console.WriteLine();

                PrintMenuOptions();

                int backpackCount = User.User.Backpack.Inventory.Count;

                SelectedIndex = InputHandler.HandleInput(MenuOptions, SelectedIndex);

                // If the backpack count has increased then the purchase has gone through
                if (backpackCount < User.User.Backpack.Inventory.Count)
                {
                    return;
                }

                // -1 is returned from user pressing [Backspace] (aka return/exit)
                if (SelectedIndex == -1)
                {
                    // Cancel Purchase and return to categoryview
                    User.User.Wallet.CancelPurchase();
                    return;
                }
            }
        }

        private void UpdateMenuOptions()
        {
            MenuOptions.Clear();
            var money = User.User.Wallet.Money;

            // Create nested lists grouped by money value and order them for consistent output
            var groupedList = money.GroupBy(i => i.Value).Select(l => l.ToList()).ToList();
            groupedList = groupedList.OrderBy(l => l[0].Value).ToList();

            foreach (var sublist in groupedList)
            {
                MenuOptions.Add(new MoneyOption(sublist));
            }

            MenuOptions.Add(new CustomOption("Complete purchase.", () => User.User.Wallet.CompletePurchase(Product)));
        }
    }
}