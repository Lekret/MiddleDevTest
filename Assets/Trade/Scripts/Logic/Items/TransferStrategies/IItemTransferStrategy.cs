namespace Trade.Scripts.Logic.Items.TransferStrategies
{
    public interface IItemTransferStrategy
    {
        bool CanTransfer(Item item);
        void BeforeTransfer(ref Item item);
    }
}