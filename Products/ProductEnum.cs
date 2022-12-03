namespace EmilWallin_Inlämning_1.Products
{
    public enum ProductCategories
    {
        Chocolate,
        EnergyDrinks,
        Sodas
    }

    public static class CategoryName
    {
        public static string Get(ProductCategories category)
        {
            switch (category)
            {
                case ProductCategories.Chocolate:
                    return "Chocolate";

                case ProductCategories.EnergyDrinks:
                    return "Energy Drinks";

                case ProductCategories.Sodas:
                    return "Sodas";

                default:
                    return "";
            }
        }
    }
}