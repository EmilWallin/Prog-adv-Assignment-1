using EmilWallin_Inlämning_1.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmilWallin_Inlämning_1.Navigation.Execution
{
    internal abstract class InputExecution
    {
        public abstract int Execute(string key, List<MenuOption> menuOptions, int selectedIndex);
    }
}