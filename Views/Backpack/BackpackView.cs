using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmilWallin_Inlämning_1.Views.Backpack
{
    internal class BackpackView : View
    {
        // TO BE IMPLEMENTED

        public override void Show()
        {
            while (true)
            {
                Console.Clear();
                PrintVendingMachineHeader();

                Console.ReadKey();
            }
        }
    }
}