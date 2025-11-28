using UnityEngine;

namespace Ezereal
{
    public class ButtonPusher : MonoBehaviour
    {
        [Header("Settings")]

        // Check out the "Help" folder for values of different phones
        // Tips are useful for object scale 1,1,1 (Vector3.one)
        // You can use context method call for debugging (In Inspector press 3-dot button then click "Push a Button" when the game is launched).

        [SerializeField] Directions direction = Directions.backward;

        [SerializeField] float pushDistance = 0.0045f; // How far away button pushes
        [SerializeField] float pushSpeed = 0.0075f;     // Speed of the push
        [SerializeField] float returnSpeed = 0.015f;   // Speed of the return to original position

        [SerializeField] float stopThreshold = 0.0005f;

        [Header("Debug")]
        [SerializeField] Vector3 initialPosition; // The starting local position of the button
        [SerializeField] Vector3 targetPosition;  // The target position when the button is pushed
        public bool isPushing = false;  // Whether the button is currently being pushed
        [SerializeField] bool isReturning = false; // Whether the button is returning to its initial position

        private void Start()
        {
            initialPosition = transform.localPosition; // Store the initial local position

            switch (direction)
            {
                case Directions.left:
                    targetPosition = initialPosition + -transform.right * pushDistance;
                    break;
                case Directions.right:
                    targetPosition = initialPosition + transform.right * pushDistance;
                    break;
                case Directions.up:
                    targetPosition = initialPosition + transform.up * pushDistance;
                    break;
                case Directions.down:
                    targetPosition = initialPosition + -transform.up * pushDistance;
                    break;
                case Directions.forward:
                    targetPosition = initialPosition + transform.forward * pushDistance;
                    break;
                case Directions.backward:
                    targetPosition = initialPosition + -transform.forward * pushDistance;
                    break;
            }           
        }

        private void Update()
        {
            // Move the button down linearly
            if (isPushing)
            {
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPosition, pushSpeed * Time.deltaTime);
                if (Vector3.Distance(transform.localPosition, targetPosition) < stopThreshold)
                {
                    transform.localPosition = targetPosition; // Snap to the target position
                    isPushing = false; // Stop pushing
                    isReturning = true; // Start returning
                }
            }

            // Move the button up linearly
            if (isReturning)
            {
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, initialPosition, returnSpeed * Time.deltaTime);
                if (Vector3.Distance(transform.localPosition, initialPosition) < stopThreshold)
                {
                    transform.localPosition = initialPosition; // Snap to the initial position
                    isReturning = false; // Stop returning
                }
            }
        }

        // Public method to initiate the button push
        public void PushButton()
        {
            Debug.Log("Button push initiated.");
            if (!isPushing && !isReturning)
            {
                isPushing = true; // Start the pushing process
            }
        }

        // For Debug

        [ContextMenu("Push a Button")]
        void PushAButton()
        {
            PushButton();
        }
    }
}
