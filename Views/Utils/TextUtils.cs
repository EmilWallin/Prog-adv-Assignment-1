using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmilWallin_Inlämning_1.Views.Utils
{
    internal class TextUtils
    {
        // Gets a string of totalLength length, with the text centered with symbols around
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

        // Gets a string of amount length of symbol
        public static string GetSeparatorString(int amount, string symbol)
        {
            StringBuilder output = new();

            for (int i = 0; i < amount; i++) output.Append(symbol);

            return output.ToString();
        }

        public static string GetEmptyItemLine(int amount, string symbol)
        {
            StringBuilder output = new();
            output.Append(symbol);
            for (int i = 0; i < amount - 2; i++) output.Append(" ");
            output.Append(symbol);
            return output.ToString();
        }

        public static string GetEmptySpace(int amount)
        {
            StringBuilder output = new();
            for (int i = 0; i < amount; i++) output.Append(" ");
            return output.ToString();
        }
    }
}