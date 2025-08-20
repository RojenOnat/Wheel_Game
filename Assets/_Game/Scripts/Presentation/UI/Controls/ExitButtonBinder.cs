using _Game.Scripts.Application.Events;
using _Game.Scripts.Infrastructure.Messaging;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.Scripts.Presentation.UI.Controls
{
    /// <summary>
    /// This class binds the exit button to restart the game.
    /// </summary>
    public class ExitButtonBinder : MonoBehaviour
    {
        /// <summary>
        /// Stores the reference to the Button component.
        /// </summary>
        private Button _exitButton;

        /// <summary>
        /// Called in the editor to ensure the button is set up properly.
        /// </summary>
        public void OnValidate()
        {
            ButtonInitialize();
        }

        /// <summary>
        /// Initializes the button when the object awakens.
        /// </summary>
        private void Awake()
        {
            ButtonInitialize();
        }

        /// <summary>
        /// Assigns the button reference if missing and attaches the restart game event listener.
        /// </summary>
        private void ButtonInitialize()
        {
            if (_exitButton == null) _exitButton = GetComponent<Button>();
      
            _exitButton.onClick.RemoveAllListeners();
            _exitButton.onClick.AddListener(() =>
            {
                GlobalBus.Instance.Publish(new RestartGameEvent());
            });
        }
    }
}
