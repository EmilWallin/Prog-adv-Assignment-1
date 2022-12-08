using EmilWallin_Inlämning_1.Navigation.Utils;
using EmilWallin_Inlämning_1.Views;

namespace EmilWallin_Inlämning_1.Navigation
{
    // Class to handle input from user
    internal abstract class InputHandler<T>
    {
        // Input method, valid keys will be part of T (enum)
        public virtual int HandleInput(List<MenuOption> menuOptions, int selectedIndex)
        {
            if (!typeof(T).IsEnum) throw new ArgumentException("T must be an enum.");

            string key;
            string[] validInputs = Enum.GetNames(typeof(T));

            while (true)
            {
                key = Console.ReadKey().Key.ToString();
                ConsoleUtils.ClearCurrentLine();

                if (validInputs.Contains(key))
                {
                    return ExecuteInput(key, menuOptions, selectedIndex);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    Thread.Sleep(1000);
                    return selectedIndex;
                }
            }
        }

        protected abstract int ExecuteInput(string key, List<MenuOption> menuOptions, int selectedIndex);
    }
}