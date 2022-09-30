namespace Trade.Scripts.Logic
{
    public class Player
    {
        public Wallet Wallet { get; } = new Wallet();
        public ItemContainer Items { get; } = new ItemContainer(10);
    }
}