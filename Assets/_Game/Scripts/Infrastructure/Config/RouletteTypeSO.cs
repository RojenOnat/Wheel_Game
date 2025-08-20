using System.Collections.Generic;
using UnityEngine;

namespace _Game.Scripts.Infrastructure.Config
{
   [System.Serializable]
   public class RouletteTypeData
   {
      public int Id;             // Identifier for the roulette type (e.g., bronze, silver, gold)
      public string DisplayName;    // Display name shown in the Inspector
      public Sprite RouletteIcon;           // Icon representing the roulette wheel
      public Sprite PointerIcon;           // Icon representing the pointer for the wheel
   }
   [CreateAssetMenu(menuName = "Roulette/Roulette Type")]
   public class RouletteTypeSO : ScriptableObject
   {
      public RouletteTypeData TypeData;
      public List<WheelItemDatabaseSO> RouletteItemList;
   }
}