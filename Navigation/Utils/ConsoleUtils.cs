namespace EmilWallin_Inlämning_1.Navigation.Utils
{
    internal static class ConsoleUtils
    {
        public static void ClearCurrentLine()
        {
            Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
        }
    }
}