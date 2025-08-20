using UnityEngine;

namespace _Game.Scripts.Infrastructure.Config
{
    /// <summary>
    /// Configuration data for different roulette zone levels.
    /// This ScriptableObject stores the levels for Silver and Gold roulette zones.
    /// </summary>
    [CreateAssetMenu(menuName = "Roulette/Zone Level Config")]
    public class ZoneLevelConfigSO : ScriptableObject
    {
        /// <summary>
        /// The level at which the Silver Roulette becomes available.
        /// </summary>
        [Header("Silver Roulette Level")] 
        public int SilverRouletteLevel;

        /// <summary>
        /// The level at which the Gold Roulette becomes available.
        /// </summary>
        [Header("Gold Roulette Level")] 
        public int GoldRouletteLevel;

    }
}