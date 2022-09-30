using UnityEngine;

namespace Trade.Scripts.Ui.Core
{
    [DisallowMultipleComponent]
    public class UiWindow : MonoBehaviour
    {
        public void PlaceAsFirst()
        {
            transform.SetAsLastSibling();
        }
    }
}