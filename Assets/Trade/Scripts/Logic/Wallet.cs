using System;

namespace Trade.Scripts.Logic
{
    public class Wallet
    {
        private int _coins;

        public int Coins => _coins;
        public event Action CoinsCountChanged;

        public void Add(int toAdd)
        {
            _coins += toAdd;
            CoinsCountChanged?.Invoke();
        }

        public bool TrySubtract(int toSubtract)
        {
            if (_coins > toSubtract)
            {
                _coins -= toSubtract;
                CoinsCountChanged?.Invoke();
                return true;
            }
            return false;
        }
    }
}