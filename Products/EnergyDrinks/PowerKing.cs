using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmilWallin_Inlämning_1.Products.EnergyDrinks
{
    internal class Powerking : EnergyDrink
    {
        public Powerking()
        {
            this.Name = "Powerking";
            this.Description = "An energy drink.";
            this.Price = 19;
        }
    }
}