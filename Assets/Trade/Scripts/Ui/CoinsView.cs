using TMPro;
using Trade.Scripts.Logic;
using Trade.Scripts.Ui.Core;
using UnityEngine;

namespace Trade.Scripts.Ui
{
    public class CoinsView : UiView
    {
        [SerializeField] private TextMeshProUGUI _amount;

        private Wallet _wallet;
        
        public void Init(Wallet wallet)
        {
            _wallet = wallet;
            _wallet.CoinsCountChanged += SetCoins;
            SetCoins();
        }

        private void OnDestroy()
        {
            _wallet.CoinsCountChanged -= SetCoins;
        }

        private void SetCoins()
        {
            _amount.text = $"{_wallet.Coins}";
        }
    }
}