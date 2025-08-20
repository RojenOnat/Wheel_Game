using _Game.Scripts.Application.Events;
using _Game.Scripts.Infrastructure.Messaging;
using UnityEngine;

namespace _Game.Scripts.Presentation.UI.Popups
{
    // Presenter class responsible for managing the bomb popup UI panel visibility based on events.
    public class BombPopupUIPresenter : MonoBehaviour
    {
        // Reference to the root GameObject of the bomb panel UI, set via the Inspector.
        [SerializeField] private GameObject bombPanelRoot;

        // Subscribes to the OpenBombPanelEvent when the object awakens.
        private void Awake()
        {
            GlobalBus.Instance.Subscribe<OpenBombPanelEvent>(OnOpenBombPanel);
        }

        // Unsubscribes from the OpenBombPanelEvent when the object is destroyed to prevent memory leaks.
        private void OnDestroy()
        {
            GlobalBus.Instance.Unsubscribe<OpenBombPanelEvent>(OnOpenBombPanel);
        }

        // Event handler that sets the bomb panel's active state based on the event data.
        private void OnOpenBombPanel(OpenBombPanelEvent e)
        {
            bombPanelRoot.SetActive(e.IsOpen);
        }
    }
}
