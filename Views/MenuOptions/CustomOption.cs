using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmilWallin_Inlämning_1.Views.MenuOptions
{
    internal class CustomOption : MenuOption
    {
        private string optionText { get; set; }

        public CustomOption(string optionText, Action action)
        {
            this.optionText = optionText;
            this.action = action;
        }

        public override string GetMenuOptionString(bool selected = false)
        {
            StringBuilder output = new();

            output.Append(optionText);
            output.Insert(0, "==>");

            return output.ToString();
        }
    }
}