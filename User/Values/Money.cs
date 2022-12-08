namespace EmilWallin_Inlämning_1.User.Values
{
    // base class for all values of money
    internal abstract class Money
    {
        public int Value { get; set; }

        public Money Get()
        {
            return (Money)MemberwiseClone();
        }
    }
}