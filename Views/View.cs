using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmilWallin_Inlämning_1.Views
{
    internal abstract class View : IView
    {
        public virtual void Show()
        {
            throw new NotImplementedException();
        }
    }
}