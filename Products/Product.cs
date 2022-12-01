namespace EmilWallin_Inlämning_1.Products
{
    internal abstract class Product : IProduct
    {
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public int Price { get; protected set; }
        public ProductCategories ProductCategory { get; protected set; }

        public virtual void Buy()
        {
            Console.WriteLine($"You bought one {Name}.");
        }

        public virtual void PrintDescription()
        {
            Console.WriteLine($"{Name}:\n{Description}");
        }

        public virtual void Use()
        {
            Console.WriteLine($"{Name} has been used.");
        }
    }
}