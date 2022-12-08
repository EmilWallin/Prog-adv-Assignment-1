using EmilWallin_Inlämning_1.Views;
using static EmilWallin_Inlämning_1.Navigation.InputEnums;

namespace EmilWallin_Inlämning_1.Navigation
{
    // Input handler for menus (views)
    internal class MenuInputHandler : InputHandler<MenuInputs>
    {
        public override int HandleInput(List<MenuOption> menuOptions, int selectedIndex)
        {
            Console.WriteLine("Navigate the menu with [ArrowUp] and [ArrowDown].");
            Console.WriteLine("Press [Enter] to interact.");
            Console.WriteLine("To return/exit press [Backspace].");

            return base.HandleInput(menuOptions, selectedIndex);
        }

        protected override int ExecuteInput(string key, List<MenuOption> menuOptions, int selectedIndex)
        {
            MenuInputs input = (MenuInputs)Enum.Parse(typeof(MenuInputs), key);
            switch (input)
            {
                case MenuInputs.UpArrow:
                    return selectedIndex == 0 ? 0 : selectedIndex - 1;

                case MenuInputs.DownArrow:
                    return selectedIndex == menuOptions.Count - 1 ? selectedIndex : selectedIndex + 1;

                case MenuInputs.Enter:
                    menuOptions[selectedIndex].Execute();
                    break;

                case MenuInputs.Backspace:
                    return -1;

                default:
                    break;
            }

            return selectedIndex;
        }
    }
}