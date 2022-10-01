using System.Collections.Generic;

namespace Trade.Scripts.Ui.Core
{
    public class UiWindow
    {
        private readonly HashSet<UiView> _views = new HashSet<UiView>();

        public UiWindow Add(UiView view)
        {
            _views.Add(view);
            return this;
        }

        public void Show()
        {
            foreach (var view in _views)
            {
                view.gameObject.SetActive(true);
                view.transform.SetAsLastSibling();
            }
        }

        public void Hide()
        {
            foreach (var view in _views)
            {
                view.gameObject.SetActive(false);
            }
        }
    }
}