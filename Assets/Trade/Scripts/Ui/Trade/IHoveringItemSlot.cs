using Trade.Scripts.Logic;

namespace Trade.Scripts.Ui.Trade
{
    public interface IHoveringItemSlot
    {
        bool HasItem { get; }
        Item Item { get; }
        void SetItem(Item item);
        void Hide();
    }
}