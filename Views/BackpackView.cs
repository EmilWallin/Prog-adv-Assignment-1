using EmilWallin_Inlämning_1.Views.MenuOptions;

namespace EmilWallin_Inlämning_1.Views
{
    // View for inspecting and using the user backpack inventory.
    internal class BackpackView : View
    {
        public BackpackView()
        {
            MenuOptions = new();
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

        protected override void PrintMenuOptions()
        {
            Console.WriteLine("Checking your backpack you find:");
            Console.WriteLine();
            base.PrintMenuOptions();
        }

        // Updating menu options every while loop iteration as to fetch the fresh inventory in case something was used
        private void UpdateMenuOptions()
        {
            MenuOptions.Clear();
            var inventory = User.User.Backpack.Inventory;

            foreach (var sublist in inventory.GroupBy(i => i.Name).Select(l => l.ToList()).ToList())
            {
                MenuOptions.Add(new BackpackOption(sublist));
            }
        }
    }
}