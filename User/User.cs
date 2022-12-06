using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmilWallin_Inlämning_1.User
{
    // Static user as this program is only made to support one user
    internal static class User
    {
        public static Backpack Backpack { get; set; } = new();
        public static Wallet Wallet { get; set; } = new();
    }
}