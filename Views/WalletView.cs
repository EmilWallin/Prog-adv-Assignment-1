using EmilWallin_Inlämning_1.Views.MenuOptions;

namespace EmilWallin_Inlämning_1.Views
{
    // View for viewing the wallet balance. No way to go further from here, only returning is possible
    internal class WalletView : View
    {
        public WalletView()
        {
            UpdateMenuOptions();
        }

        public override void Show()
        {
            while (true)
            {
                Console.Clear();
                PrintVendingMachineHeader();

                UpdateMenuOptions();

                PrintMenuOptions();

                SelectedIndex = InputHandler.HandleInput(MenuOptions, SelectedIndex);

                // -1 is returned from user pressing [Backspace] (aka return/exit)
                if (SelectedIndex == -1) return;
            }
        }

        // Custom implementation where no option is visibly selected
        protected override void PrintMenuOptions()
        {
            Console.WriteLine("Checking your wallet you find:");
            Console.WriteLine();

            List<string> optionsOutput = MenuOptions.Select((m, i) => m.GetMenuOptionString()).ToList();

            optionsOutput.ForEach(o => Console.WriteLine(o + "\n"));
        }

        // Creating menu options
        private void UpdateMenuOptions()
        {
            MenuOptions.Clear();
            var money = User.User.Wallet.Money;

            // Create nested lists grouped by money value and order them for consistent output
            var groupedList = money.GroupBy(i => i.Value).Select(l => l.ToList()).ToList();
            groupedList = groupedList.OrderBy(l => l[0].Value).ToList();

            foreach (var sublist in groupedList)
            {
                // Empty action, no purchase can be done from checking balance
                MenuOptions.Add(new MoneyOption(sublist, () => { }));
            }
        }
    }
}