using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;
using System;

namespace Asteroids.UI
{
    public class UISystem
    {
        private GameUI _gameUI;
        private PauseMenu _pauseMenu;
        private readonly Stack<StateUI> _stateUi = new Stack<StateUI>();
        private BaseUI _currentWindow;
        private Action action;
        public UISystem(Canvas gameUI, Canvas pauseMenu)
        {
            _gameUI = gameUI.GetComponent<GameUI>();
            _gameUI.SetActive(false);
            action = Unpause;
            _pauseMenu = pauseMenu.GetComponent<PauseMenu>();
            _pauseMenu.SetAction(action);
            _pauseMenu.SetActive(false);

            ShowUI(StateUI.GameUI);
        }

        public void EnemyDeath(string type, int points)
        {
            _gameUI.EnemyDeath(type, points);
        }
        
        private void ShowUI(StateUI stateUI, bool isSave = true)
        {
            if (_currentWindow != null)
            {
                _currentWindow.SetActive(false);
            }

            switch (stateUI)
            {
                case StateUI.GameUI:
                    _currentWindow = _gameUI;
                    break;

                case StateUI.PauseMenu:
                    _currentWindow = _pauseMenu;
                    break;

                default:
                    break;
            }

            _currentWindow.SetActive(true);
            if (isSave)
            {
                _stateUi.Push(stateUI);
            }
        }
        public void Pause()
        {
            Time.timeScale = 0;
            ShowUI(StateUI.PauseMenu);
        }
        private void Unpause()
        {
            ShowUI(_stateUi.Pop(), false);
            Time.timeScale = 1;
        }
    }
}