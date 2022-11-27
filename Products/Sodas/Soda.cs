using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmilWallin_Inlämning_1.Products.Sodas
{
    internal class Soda : Product
    {
        public Soda()
        {
            this.Price = 20;
        }

        public override void Use()
        {
            Console.WriteLine($"You drank a {Name}.");
        }
    }
}