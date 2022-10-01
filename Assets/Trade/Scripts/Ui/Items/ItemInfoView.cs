using TMPro;
using Trade.Scripts.Logic;
using Trade.Scripts.Ui.Core;
using UnityEngine;

namespace Trade.Scripts.Ui.Items
{
    public class ItemInfoView : UiView, IItemInfo
    {
        [SerializeField] private GameObject _container;
        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private TextMeshProUGUI _cost;

        private void Awake()
        {
            _container.SetActive(false);
        }

        public void Show(Item item, Vector3 position)
        {
            _container.SetActive(true);
            _name.text = item.Data.Name;
            _cost.text = $"Cost: {item.Cost}";
            transform.position = position;
        }

        public void Disable()
        {
            _container.SetActive(false);
        }
    }
}