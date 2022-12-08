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
            return category switch
            {
                ProductCategories.Chocolate => "Chocolate",
                ProductCategories.EnergyDrinks => "Energy Drinks",
                ProductCategories.Sodas => "Sodas",
                _ => "",
            };
        }
    }
}