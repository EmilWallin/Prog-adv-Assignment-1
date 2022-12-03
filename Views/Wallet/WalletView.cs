using EmilWallin_Inlämning_1.Views.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmilWallin_Inlämning_1.Views.Wallet
{
    // View class for viewing the wallet information
    internal class WalletView : View
    {
        private EmilWallin_Inlämning_1.User.Wallet wallet { get; set; }

        public WalletView(EmilWallin_Inlämning_1.User.Wallet wallet)
        {
            this.wallet = wallet;
        }

        public override void Show()
        {
            while (true)
            {
                Console.Clear();
                PrintVendingMachineHeader();

                wallet.PrintBalance();

                Console.ReadKey();
            }
        }
    }
}