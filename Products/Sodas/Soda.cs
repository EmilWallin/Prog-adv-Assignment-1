namespace EmilWallin_Inlämning_1.Products.Sodas
{
    internal class Soda : Product
    {
        public Soda()
        {
            Price = 20;
            ProductCategory = ProductCategories.Sodas;
        }

        public override void Use()
        {
            Console.WriteLine($"You drank a {Name}.");
        }
    }
}