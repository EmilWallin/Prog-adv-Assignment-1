using EmilWallin_Inlämning_1.Products;
using EmilWallin_Inlämning_1.Views.Utils;
using System.Text;

namespace EmilWallin_Inlämning_1.Views
{
    internal abstract class MenuOption
    {
        protected Action action { get; set; }

        public virtual string GetMenuOptionString(bool selected = false)
        {
            return "Empty option";
        }

        public virtual void Execute()
        {
            action?.Invoke();
        }

        public virtual StringBuilder AddSelected(StringBuilder option)
        {
            return option.Insert(0, "==> ");
        }
    }
}