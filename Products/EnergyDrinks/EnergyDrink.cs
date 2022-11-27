using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmilWallin_Inlämning_1.Products.EnergyDrinks
{
    internal class EnergyDrink : Product
    {
        public override void Use()
        {
            Console.WriteLine($"You drank one {Name}.");
        }
    }
}