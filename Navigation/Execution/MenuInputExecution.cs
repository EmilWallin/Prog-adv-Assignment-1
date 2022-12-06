using EmilWallin_Inlämning_1.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EmilWallin_Inlämning_1.Navigation.InputEnums;

namespace EmilWallin_Inlämning_1.Navigation.Execution
{
    internal class MenuInputExecution : InputExecution
    {
        public override int Execute(string key, List<MenuOption> menuOptions, int selectedIndex)
        {
            MenuInputs input = (MenuInputs)Enum.Parse(typeof(MenuInputs), key);

            switch (input)
            {
                case MenuInputs.UpArrow:
                    break;

                case MenuInputs.DownArrow:
                    break;

                case MenuInputs.Enter:
                    break;

                default:
                    break;
            }

            return selectedIndex;
        }
    }
}