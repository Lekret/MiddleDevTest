using System;
using UnityEngine;

namespace Trade.Scripts.Logic
{
    public class Wallet : IWallet
    {
        private int _coins;

        public Wallet(int coins)
        {
            _coins = coins;
        }

        public int Coins => _coins;
        public event Action CoinsCountChanged;

        public void Add(int toAdd)
        {
            _coins += toAdd;
            CoinsCountChanged?.Invoke();
        }

        public void Subtract(int toSubtract)
        {
            if (_coins >= toSubtract)
            {
                _coins -= toSubtract;
                CoinsCountChanged?.Invoke();
            }
            else
            {
                Debug.LogError($"Invalid wallet subtract: _coins({_coins}), toSubtract({toSubtract})");
            }
        }
    }
}