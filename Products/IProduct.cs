using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmilWallin_Inlämning_1.Products
{
    internal interface IProduct
    {
        public void PrintDescription();

        public void Buy();

        public void Use();
    }
}