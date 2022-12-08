using EmilWallin_Inlämning_1.Products;
using EmilWallin_Inlämning_1.User.Values;

namespace EmilWallin_Inlämning_1.User
{
    //Class holding information regarding the wallet for the user
    internal class Wallet
    {
        public List<Money> Money { get; }

        // Money put into the machine but not yet "used"
        public List<Money> InputMoney { get; }

        public Wallet()
        {
            Money = new();
            InputMoney = new();

            //Add 10 of each 1, 5, and 10
            for (int i = 0; i < 10; i++)
            {
                Money.Add(new OneMoney());
                Money.Add(new FiveMoney());
                Money.Add(new TenMoney());
            }
        }

        public bool Input(Money money)
        {
            if (!Money.Any(m => m.Value == money.Value)) return false;

            Money.Remove(Money.First(m => m.Value == money.Value));
            InputMoney.Add(money);

            return true;
        }

        public void CompletePurchase(Product product)
        {
            if (InputBalance < product.Price) return;
            Console.Clear();
            Console.WriteLine("Purchase completed!");
            Console.WriteLine();
            Money.AddRange(WalletUtil.GetChange(InputBalance - product.Price));
            User.Backpack.AddItem(product.Buy());
            InputMoney.Clear();

            Console.WriteLine($"Total money left: {Balance}kr.");
            Console.WriteLine();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        public void CancelPurchase()
        {
            Console.WriteLine("Cancelling the purchase.");

            Money.AddRange(InputMoney);
            InputMoney.Clear();
        }

        public void PrintBalance()
        {
            int total = Money.Sum(m => m.Value);
            int ones = Money.Count(b => b.Value == 1);
            int fives = Money.Count(b => b.Value == 5);
            int tens = Money.Count(b => b.Value == 10);
            int twenties = Money.Count(b => b.Value == 20);
            int fifties = Money.Count(b => b.Value == 50);
            int hundreds = Money.Count(b => b.Value == 100);

            Console.Clear();
            Console.WriteLine($"Your wallet contains a total of {total}kr.");
            Console.WriteLine("It consists of:");
            Console.WriteLine($"{ones}x 1kr");
            Console.WriteLine($"{fives}x 5kr");
            Console.WriteLine($"{tens}x 10kr");
            Console.WriteLine($"{twenties}x 20kr");
            Console.WriteLine($"{fifties}x 50kr");
            Console.WriteLine($"{hundreds}x 100kr");
            Console.WriteLine();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        public int Balance
        {
            get
            {
                return Money.Sum(m => m.Value);
            }
        }

        public int InputBalance
        {
            get
            {
                return InputMoney.Sum(m => m.Value);
            }
        }
    }
}