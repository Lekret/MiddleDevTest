namespace Trade.Scripts.Logic.Items.TransferStrategies
{
    public class PlayerBuyStrategy : IItemTransferStrategy
    {
        private readonly IWallet _playerWallet;

        public PlayerBuyStrategy(IWallet playerWallet)
        {
            _playerWallet = playerWallet;
        }

        public bool CanTransfer(Item item)
        {
            return _playerWallet.Coins >= item.Cost;
        }

        public void BeforeTransfer(ref Item item)
        {
            _playerWallet.Subtract(item.Cost);
            item.Cost = item.Data.BaseCost;
        }
    }
}