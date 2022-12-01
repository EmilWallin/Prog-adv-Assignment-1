using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmilWallin_Inlämning_1.Views
{
    internal class ViewUtils
    {
        public static string GetCenteredText(int totalLength, string text, string symbol)
        {
            int textLength = text.Count();

            int starAmount = totalLength - textLength - 2;

            if (starAmount % 2 == 0)
            {
                return $"{GetSeparatorString(starAmount / 2, symbol)} {text} {GetSeparatorString(starAmount / 2, symbol)}";
            }
            else
            {
                return $"{GetSeparatorString(starAmount / 2 + starAmount % 2, symbol)} {text} {GetSeparatorString(starAmount / 2, symbol)}";
            }
        }

        public static string GetSeparatorString(int amount, string symbol)
        {
            StringBuilder output = new();

            for (int i = 0; i < amount; i++) output.Append(symbol);

            return output.ToString();
        }
    }
}