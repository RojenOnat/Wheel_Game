using _Game.Scripts.Application.Events;
using _Game.Scripts.Infrastructure.Messaging;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.Scripts.Presentation.UI.Controls
{
   // This class binds the Give Up button to trigger a restart event.
   public class GiveUpButtonBinder : MonoBehaviour
   {
      private Button _giveUpButton;

      // Called in the editor to ensure the button is initialized properly.
      public void OnValidate()
      {
         ButtonInitialize();
      }

      // Initializes the button when the object is created at runtime.
      private void Awake()
      {
         ButtonInitialize();
      }

      private void ButtonInitialize()
      {
         // If the button reference is null, get the Button component attached to this GameObject.
         if (_giveUpButton == null) _giveUpButton = GetComponent<Button>();
      
         // Remove all previous listeners to avoid duplicate event subscriptions.
         _giveUpButton.onClick.RemoveAllListeners();

         // Add a new listener that publishes a RestartGameEvent when the button is clicked.
         _giveUpButton.onClick.AddListener(() =>
         {
            GlobalBus.Instance.Publish(new RestartGameEvent());
         });
      }
   }
}
