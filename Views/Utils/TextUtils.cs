using System.Text;

namespace EmilWallin_Inlämning_1.Views.Utils
{
    internal class TextUtils
    {
        // Gets a string of totalLength length, with the text centered with symbols around
        public static string GetCenteredText(int totalLength, string text, char symbol)
        {
            int textLength = text.Length;

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

        // Gets a string of amount length of symbol, to simplify
        public static string GetSeparatorString(int amount, char symbol)
        {
            StringBuilder output = new();

            output.Append(symbol, amount);

            return output.ToString();
        }
    }
}