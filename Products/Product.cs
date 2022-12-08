namespace EmilWallin_Inlämning_1.Products
{
    internal abstract class Product : IProduct<Product>
    {
        public static Product[] Products { get; set; }

        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public int Price { get; protected set; }
        public ProductCategories ProductCategory { get; protected set; }

        public virtual Product Buy()
        {
            Console.WriteLine($"You bought one {Name}.");
            return (Product)MemberwiseClone();
        }

        public virtual void Use()
        {
            Console.WriteLine($"{Name} has been used.");
        }
    }
}