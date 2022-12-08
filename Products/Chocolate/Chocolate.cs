namespace EmilWallin_Inlämning_1.Products.Chocolate
{
    internal class Chocolate : Product
    {
        public Chocolate()
        {
            Price = 12;
            ProductCategory = ProductCategories.Chocolate;
        }

        public override void Use()
        {
            Console.WriteLine($"You ate a {Name}.");
        }
    }
}