using UnityEngine;
using UnityEngine.UI;
using System;

namespace Asteroids.UI
{
    public class PauseMenu : BaseUI
    {
        private Button _closeButton;
        private Action Close;
        public void Start()
        {
            _closeButton = transform.GetChild(0).GetComponent<Button>();
            _closeButton.onClick.AddListener(CloseMenu);
        }
        public void SetAction(Action closeMenu)
        {
            Close = closeMenu;
        }
        public void CloseMenu()
        {
            Close();
        }
    }
}