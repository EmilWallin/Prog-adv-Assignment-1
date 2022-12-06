using EmilWallin_Inlämning_1.Products;
using EmilWallin_Inlämning_1.Views.MenuOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmilWallin_Inlämning_1.Views
{
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

                if (SelectedIndex == -1) return;
            }
        }

        protected override void PrintMenuOptions()
        {
            Console.WriteLine("Checking your backpack you find:");
            Console.WriteLine();
            base.PrintMenuOptions();
        }

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