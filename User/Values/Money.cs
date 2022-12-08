namespace EmilWallin_Inlämning_1.User.Values
{
    internal abstract class Money
    {
        public int Value { get; set; }

        public Money Get()
        {
            return (Money)this.MemberwiseClone();
        }
    }
}