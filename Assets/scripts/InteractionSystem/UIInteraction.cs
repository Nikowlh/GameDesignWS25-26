using UnityEngine;

public class UIInteraction : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Canvas promptCanvas;

    [Header("Interaction Settings")]
    [SerializeField] private float detectionRadius = 1.5f;
    [SerializeField] private LayerMask interactorMask;

    private void Start()
    {
        if (promptCanvas != null)
            promptCanvas.enabled = false;
    }

    private void Update()
    {
        if (promptCanvas == null)
            return;

        // Prüfen, ob ein Interactible in Reichweite ist
        bool isInRange = Physics.CheckSphere(transform.position, detectionRadius, interactorMask);

        // Canvas nur an, wenn etwas in Reichweite ist
        promptCanvas.enabled = isInRange;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
