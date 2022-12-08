using EmilWallin_Inlämning_1.User.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmilWallin_Inlämning_1.User
{
    internal class WalletUtil
    {
        private static Dictionary<int, Money> moneyValues = new()
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

                change = change - (value * noOfMoney);
            }

            return returnMoney;
        }
    }
}