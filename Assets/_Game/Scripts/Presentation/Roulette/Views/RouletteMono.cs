using _Game.Scripts.Infrastructure.Config;
using _Game.Scripts.Presentation.Roulette.Spawners;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.Scripts.Presentation.Roulette.Views
{
    // This class manages the roulette view, including binding data, setting images, and initializing item spawner.
    public class RouletteMono : MonoBehaviour
    {
        // Holds the roulette data scriptable object that contains configuration for this roulette.
        private RouletteTypeSO _readedRouletteData;

        // Image component displaying the roulette wheel.
        [SerializeField]private Image _rouletteImage;
        // Image component displaying the roulette pointer.
        [SerializeField]private Image _roulettePointerImage;

        // Binds the provided roulette data to this view.
        public void Bind(RouletteTypeSO rouletteTypeSo)
        {
            _readedRouletteData = rouletteTypeSo;
        }

        // Sets the roulette and pointer images based on the bound roulette data.
        private void SetRouletteImage()
        {
            _rouletteImage.sprite = _readedRouletteData.TypeData.RouletteIcon;
            _roulettePointerImage.sprite = _readedRouletteData.TypeData.PointerIcon;
        }

        // Initializes the roulette item spawner by clearing existing items and spawning new ones according to the bound data.
        public void InitializeSpawner()
        {
            var spawner = GetComponent<RouletteItemSpawner>();
            spawner.Clear();
            spawner.SpawnItems(_readedRouletteData);
            SetRouletteImage();
        }
    }
}
