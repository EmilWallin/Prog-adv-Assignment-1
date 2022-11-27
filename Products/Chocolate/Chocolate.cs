using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmilWallin_Inlämning_1.Products.Chocolate
{
    internal class Chocolate : Product
    {
        public Chocolate()
        {
            this.Price = 12;
        }

        public override void Use()
        {
            Console.WriteLine($"You ate a {Name}.");
        }
    }
}