using EmilWallin_Inlämning_1.User.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmilWallin_Inlämning_1.Views.MenuOptions
{
    internal class MoneyOption : MenuOption
    {
        private List<Money> Money { get; set; }

        public MoneyOption(List<Money> money)
        {
            this.Money = money;
            this.Action = () =>
            {
                Console.Clear();
                if (User.User.Wallet.Input(Money[0]))
                {
                    Console.WriteLine($"Put a {money[0].Value}kr into the vending machine.");
                }
                else
                {
                    Console.WriteLine("Error: You appear to not have enough of that value. Please try again.");
                    Thread.Sleep(1000);
                }
            };
        }

        public override string GetMenuOptionString(bool selected = false)
        {
            StringBuilder output = new();

            output.AppendLine($"{Money.Count}x {Money[0].Value}kr");

            if (selected) output = AddSelected(output);

            return output.ToString();
        }

        public override StringBuilder AddSelected(StringBuilder output)
        {
            output.Append("\t[Enter] to put into vending machine.");
            return base.AddSelected(output);
        }
    }
}