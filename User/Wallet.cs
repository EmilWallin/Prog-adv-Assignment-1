using EmilWallin_Inlämning_1.User.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmilWallin_Inlämning_1.User
{
    internal class Wallet
    {
        private List<Money> balance;

        public Wallet()
        {
            balance = new();

            //Add 10 of each 1, 5, and 10
            for (int i = 0; i < 10; i++)
            {
                balance.Add(new OneMoney());
                balance.Add(new FiveMoney());
                balance.Add(new TenMoney());
            }
        }

        public void PrintBalance()
        {
            int total = balance.Sum(m => m.Value);
            int ones = balance.Count(b => b.Value == 1);
            int fives = balance.Count(b => b.Value == 5);
            int tens = balance.Count(b => b.Value == 10);
            int twenties = balance.Count(b => b.Value == 20);
            int fifties = balance.Count(b => b.Value == 50);
            int hundreds = balance.Count(b => b.Value == 100);

            Console.WriteLine($"Your wallet contains a total of {total}kr.");
            Console.WriteLine("It consists of:");
            Console.WriteLine($"{ones} 1kr");
            Console.WriteLine($"{fives} 5kr");
            Console.WriteLine($"{tens} 10kr");
            Console.WriteLine($"{twenties} 20kr");
            Console.WriteLine($"{fifties} 50kr");
            Console.WriteLine($"{hundreds} 100kr");
            Console.WriteLine();
        }

        public int Balance
        {
            get
            {
                return balance.Sum(m => m.Value);
            }
        }
    }
}