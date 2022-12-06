using EmilWallin_Inlämning_1.Navigation;
using EmilWallin_Inlämning_1.Views.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmilWallin_Inlämning_1.Views
{
    // Console view base class
    internal abstract class View : IView
    {
        protected List<MenuOption> MenuOptions { get; set; } = new List<MenuOption>();
        protected int SelectedIndex { get; set; } = 0;

        protected MenuInputHandler InputHandler { get; set; } = new();

        public virtual void Show()
        {
            Console.WriteLine("Empty show method.");
        }

        protected virtual void PrintMenuOptions()
        {
            List<string> optionsOutput = MenuOptions.Select((m, i) => m.GetMenuOptionString(i == SelectedIndex)).ToList();

            optionsOutput.ForEach(o => Console.WriteLine(o + "\n"));
        }

        protected virtual void PrintVendingMachineHeader()
        {
            int headerWidth = 102;
            Console.WriteLine(TextUtils.GetSeparatorString(headerWidth, "*"));
            Console.WriteLine(TextUtils.GetCenteredText(headerWidth, "VENDING MACHINE", "*"));
            Console.WriteLine(TextUtils.GetSeparatorString(headerWidth, "*"));
            Console.WriteLine();
        }
    }
}