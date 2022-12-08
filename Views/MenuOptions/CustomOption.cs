using System.Text;

namespace EmilWallin_Inlämning_1.Views.MenuOptions
{
    // Custom menu option for a custom screen message and a custom action to be performed upon selection
    internal class CustomOption : MenuOption
    {
        private string OptionText { get; set; }

        public CustomOption(string optionText, Action action)
        {
            OptionText = optionText;
            Action = action;
        }

        public override string GetMenuOptionString(bool selected = false)
        {
            StringBuilder output = new();

            output.Append(OptionText);
            if (selected) output = base.AddSelected(output);

            return output.ToString();
        }
    }
}