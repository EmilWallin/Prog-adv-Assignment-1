namespace EmilWallin_Inlämning_1.Products.Chocolate
{
    internal class Chocolate : Product
    {
        public Chocolate()
        {
            this.Price = 12;
            this.ProductCategory = ProductCategories.Chocolate;
        }

        public override void Use()
        {
            Console.WriteLine($"You ate a {Name}.");
        }
    }
}