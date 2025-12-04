using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.MainMenu
{
    public class MainMenuPanelView : MonoBehaviour
    {
        public event Action PlayButtonClicked;

        [SerializeField] private Button playButton;

        public void Init()
        {
            playButton.onClick.AddListener(HandlePlayButtonClicked);
        }

        private void HandlePlayButtonClicked()
        {
            PlayButtonClicked?.Invoke();
        }
    }
}