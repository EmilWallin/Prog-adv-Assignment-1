using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmilWallin_Inlämning_1.Products.EnergyDrinks
{
    internal class Monster : EnergyDrink
    {
        public Monster()
        {
            this.Name = "Monster Energy";
            this.Description = "Original Monster Energy flavor.";
            this.Price = 31;
        }
    }
}