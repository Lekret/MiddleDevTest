using System;

namespace Trade.Scripts.Logic
{
    public interface IWallet
    {
        int Coins { get; }
        event Action CoinsCountChanged;
        void Add(int toAdd);
        void Subtract(int toSubtract);
    }
}