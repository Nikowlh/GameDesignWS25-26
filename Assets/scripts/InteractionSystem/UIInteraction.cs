using UnityEngine;

public class UIInteraction : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Canvas promptCanvas;

    [Header("Interaction Settings")]
    [SerializeField] private float detectionRadius = 1.5f;
    [SerializeField] private LayerMask interactorMask;

    public bool otherUiActive = false;

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

        // check if otherUiActive is false before enabling the promptCanvas
        if (otherUiActive)
        {
            promptCanvas.enabled = false;
            return;
        }


        if (isInRange)
        {
            if (!otherUiActive)
            {// Canvas nach 0.7 sekunden anschauen auch erst anzeigen und nur wenn bool otherUiActive false ist
                
                promptCanvas.enabled = true;
            }
        }
        else
        {
            promptCanvas.enabled = false;

        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
