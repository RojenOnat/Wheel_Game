using UnityEngine;

namespace _Game.Scripts.Infrastructure.Config
{
    // Holds individual wheel item data such as view, ID, name, and reward.
    [System.Serializable]
    public class WheelItemData
    {
        // Sprite representing the visual appearance of the wheel item.
        public Sprite ItemView;
        
        // Unique identifier for the wheel item.
        public string Id;
        
        // Display name of the wheel item.
        public string Name;
        
        // Reward value associated with the wheel item.
        public int Reward;
    }

    // ScriptableObject that stores wheel item configuration.
    [CreateAssetMenu(menuName = "Wheel/WheelDatabase")]
    public class WheelItemDatabaseSO : ScriptableObject
    {
        // Collection of wheel items stored in the database.
        public WheelItemData Items;
    
    

    }
}