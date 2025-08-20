using _Game.Scripts.Application.Events;
using _Game.Scripts.Infrastructure.Messaging;
using UnityEngine;

namespace _Game.Scripts.Presentation.Roulette.Views
{
    /// <summary>
    /// Handles the physics-based spinning behavior of a roulette wheel.
    /// Applies torque to spin the wheel, gradually stops it, and determines the winning slot.
    /// </summary>
    public class RoulettePhysicsSpinner : MonoBehaviour
    {
        [SerializeField]private float _rotatePower; // Base power applied to spin the wheel
        [SerializeField]private float _stopPower;   // Power applied to slow down the wheel

        [SerializeField]private Rigidbody2D rbody;  // Rigidbody2D component for physics simulation
        [SerializeField] private RectTransform _rotadedRoot; // UI element representing the rotating wheel
        int inRotate; // Flag to indicate if the wheel is currently rotating (1) or stopped (0)
        float t;      // Timer to delay reward calculation after wheel stops


        private void Update()
        {
            // Gradually reduce angular velocity to simulate friction and stop the wheel
            if (rbody.angularVelocity > 0)
            {
                rbody.angularVelocity -= _stopPower * Time.deltaTime;

                rbody.angularVelocity = Mathf.Clamp(rbody.angularVelocity, 0, 1440);
            }

            // Once the wheel has stopped spinning, wait a short delay then calculate the reward
            if (rbody.angularVelocity == 0 && inRotate == 1)
            {
                t += 1 * Time.deltaTime;
                if (t >= 0.5f)
                {
                    GetReward();

                    inRotate = 0;
                    t = 0;
                }
            }
        
        }


        /// <summary>
        /// Initiates the spinning of the roulette wheel with randomized torque and angular drag.
        /// </summary>
        public void Rotete()
        {
            if (inRotate == 0)
            {
                rbody.angularDrag = Random.Range(0.05f, 0.1f);
                float randomPower = Random.Range(-150f, 200f);
                rbody.AddTorque(_rotatePower+randomPower);
                inRotate = 1;
            }
        }



        /// <summary>
        /// Calculates which slot the wheel stopped on and snaps the wheel to that slot angle.
        /// Then triggers the win event with the corresponding slot index.
        /// </summary>
        public void GetReward()
        {
            int slotCount = 8; // Number of slots on the roulette wheel
            float step = 360f / slotCount;

            float rot = _rotadedRoot.eulerAngles.z;
            float normalizedRot = (rot % 360 + 360) % 360; // Normalize rotation to 0–360 degrees

            // Find the closest slot index based on the current rotation
            int slotIndex = Mathf.RoundToInt(normalizedRot / step) % slotCount;

            // Calculate the exact angle of the winning slot and snap the wheel to it
            float snappedAngle = slotIndex * step;
            _rotadedRoot.eulerAngles = new Vector3(0, 0, snappedAngle);

            Win(slotIndex + 1);

        }


        /// <summary>
        /// Publishes an event indicating the roulette spin has stopped and provides the winning slot index.
        /// </summary>
        /// <param name="Score">The winning slot number (1-based index).</param>
        public void Win(int Score)
        {
            var currentSpinValue = new RouletteSpinStoppedEvent(Score-1);
            GlobalBus.Instance.Publish(currentSpinValue);
        }


    }
}