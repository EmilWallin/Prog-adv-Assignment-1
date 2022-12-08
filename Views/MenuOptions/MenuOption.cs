using EmilWallin_Inlämning_1.Products;
using EmilWallin_Inlämning_1.Views.Utils;
using System.Text;

namespace EmilWallin_Inlämning_1.Views
{
    // Base class for menuoption. Stores an Action which will be invoked once the menuoption is selected
    internal abstract class MenuOption
    {
        protected Action Action { get; set; }

        public virtual string GetMenuOptionString(bool selected = false)
        {
            return "Empty option";
        }

        public virtual void Execute()
        {
            Action?.Invoke();
        }

        protected virtual StringBuilder AddSelected(StringBuilder option)
        {
            return option.Insert(0, "==> ");
        }
    }
}