using EmilWallin_Inlämning_1.User.Values;
using System.Text;

namespace EmilWallin_Inlämning_1.Views.MenuOptions
{
    // A menu option for displaying groups of a money value for use when purchasing
    internal class MoneyOption : MenuOption
    {
        private List<Money> Money { get; set; }

        // For use when purchasing a product
        public MoneyOption(List<Money> money)
        {
            Money = money;
            Action = () =>
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

        // For use in walletview where no purchase should be done
        public MoneyOption(List<Money> money, Action customAction)
        {
            Money = money;
            Action = customAction;
        }

        public override string GetMenuOptionString(bool selected = false)
        {
            StringBuilder output = new();

            output.AppendLine($"{Money.Count}x {Money[0].Value}kr");

            if (selected) output = AddSelected(output);

            return output.ToString();
        }

        protected override StringBuilder AddSelected(StringBuilder output)
        {
            output.Append("\t[Enter] to put into vending machine.");
            return base.AddSelected(output);
        }
    }
}