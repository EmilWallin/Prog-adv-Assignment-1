using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmilWallin_Inlämning_1.Products
{
    internal abstract class Product : IProduct
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public virtual void Buy()
        {
            Console.WriteLine($"You bought one {Name}.");
        }

        public virtual void PrintDescription()
        {
            Console.WriteLine($"{Name}:\n{Description}");
        }

        public virtual void Use()
        {
            Console.WriteLine($"{Name} has been used.");
        }
    }
}