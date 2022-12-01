namespace EmilWallin_Inlämning_1.Products.EnergyDrinks
{
    internal class EnergyDrink : Product
    {
        public EnergyDrink()
        {
            this.ProductCategory = ProductCategories.EnergyDrinks;
        }

        public override void Use()
        {
            Console.WriteLine($"You drank one {Name}.");
        }
    }
}