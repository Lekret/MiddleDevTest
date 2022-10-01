namespace Trade.Scripts.Logic.Items.TransferStrategies
{
    public class TraderBuyStrategy : IItemTransferStrategy
    {
        private readonly IWallet _wallet;
        private readonly float _costMultiplierAfterSell;

        public TraderBuyStrategy(IWallet wallet, float costMultiplierAfterSell)
        {
            _wallet = wallet;
            _costMultiplierAfterSell = costMultiplierAfterSell;
        }

        public bool CanTransfer(Item item)
        {
            return true;
        }

        public void BeforeTransfer(ref Item item)
        {
            _wallet.Add(item.Cost);
            item.Cost = Item.ApplyCostMultiplier(item.Data.BaseCost, _costMultiplierAfterSell);
        }
    }
}