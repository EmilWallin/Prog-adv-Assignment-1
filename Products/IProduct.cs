namespace EmilWallin_Inlämning_1.Products
{
    internal interface IProduct<T>
    {
        public void PrintDescription();

        public T Buy();

        public void Use();
    }
}