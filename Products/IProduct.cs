namespace EmilWallin_Inlämning_1.Products
{
    internal interface IProduct<T>
    {
        public T Buy();

        public void Use();
    }
}