using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmilWallin_Inlämning_1.Views.MainView
{
    internal class MainView : View
    {
        public override void Show()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine(ViewUtils.GetSeparatorString(80, "*"));
                Console.WriteLine(ViewUtils.GetCenteredText(80, "VENDING MACHINE", "*"));
                Console.WriteLine(ViewUtils.GetSeparatorString(80, "*"));

                Console.ReadKey();
            }
        }
    }
}