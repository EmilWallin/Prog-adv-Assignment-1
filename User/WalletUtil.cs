using EmilWallin_Inlämning_1.User.Values;

namespace EmilWallin_Inlämning_1.User
{
    internal class WalletUtil
    {
        // value money relationship
        private static readonly Dictionary<int, Money> moneyValues = new()
            {
                {
                    1,
                    new OneMoney()
                },
                {
                    5,
                    new FiveMoney()
                },
                {
                    10,
                    new TenMoney()
                },
                {
                    20,
                    new TwentyMoney()
                },
                {
                    50,
                    new FiftyMoney()
                },
                {
                    100,
                    new HundredMoney()
                }
            };

        // Both returns and prints the values of the change
        public static List<Money> GetChange(int change)
        {
            List<Money> returnMoney = new();
            List<int> values = moneyValues.Keys.OrderByDescending(x => x).ToList();

            Console.WriteLine("Your change:");

            foreach (int value in values)
            {
                int noOfMoney = change / value;

                for (int i = 0; i < noOfMoney; i++)
                {
                    returnMoney.Add(moneyValues[value].Get());
                }

                if (noOfMoney != 0) Console.WriteLine($"{noOfMoney}x {moneyValues[value].Value}kr");

                change -= (value * noOfMoney);
            }

            return returnMoney;
        }
    }
}