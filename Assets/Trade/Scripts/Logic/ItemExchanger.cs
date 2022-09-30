namespace Trade.Scripts.Logic
{
    public class ItemExchanger
    {
        public void Transfer(ItemContainer from, ItemContainer to, int fromIndex, int toIndex)
        {
            var item = from.RemoveAt(fromIndex);
            to.Add(item);
        }
    }
}