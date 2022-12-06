using EmilWallin_Inlämning_1.Navigation.Utils;
using EmilWallin_Inlämning_1.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmilWallin_Inlämning_1.Navigation
{
    // Class to handle input from user
    internal abstract class InputHandler<T>
    {
        // Input method, valid keys will be part of T (enum)
        public int HandleInput(List<MenuOption> menuOptions, int selectedIndex)
        {
            if (!typeof(T).IsEnum) throw new ArgumentException("T must be an enum.");

            string key;
            string[] validInputs = Enum.GetNames(typeof(T));

            string allInputsString = validInputs.Aggregate("", (acc, s) => acc += $"{s}, ").TrimEnd(',', ' ');

            while (true)
            {
                Console.WriteLine("Navigate the menu by inputing any of the valid inputs:");
                Console.WriteLine(allInputsString);
                key = Console.ReadKey().Key.ToString();
                ConsoleUtils.ClearCurrentLine();

                if (validInputs.Contains(key))
                {
                    return ExecuteInput(key, menuOptions, selectedIndex);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    return selectedIndex;
                }
            }
        }

        protected virtual int ExecuteInput(string key, List<MenuOption> menuOptions, int selectedIndex)
        {
            throw new NotImplementedException();
        }
    }
}