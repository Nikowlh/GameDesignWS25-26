using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class UIInteraction : MonoBehaviour
{
    [Header("UI")]
    public Canvas promptCanvas;
    public TMP_Text promptText;

    [Header("Interaction Settings")]
    public float detectionRadius = 1.5f;
    public LayerMask interactorMask;

    private ImInteractible interactible;
    private bool isInRange = false;

    private void Start()
    {
        promptCanvas.enabled = false;

        // Das Interactible (z. B. DoorInteraction) am selben Objekt holen
        interactible = GetComponent<ImInteractible>();
    }

    private void Update()
    {
        // Prüfen, ob ein Interactor in der Nähe ist
        isInRange = Physics.CheckSphere(transform.position, detectionRadius, interactorMask);

        if (isInRange)
        {
            // Prompt anzeigen
            promptCanvas.enabled = true;

            if (promptText != null && interactible != null)
                promptText.text = interactible.InteractionPrompt;

            // Wenn E gedrückt → Interaktion ausführen + UI ausblenden
            if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                interactible.Interactor(null);
                promptCanvas.enabled = false;
            }
        }
        else
        {
            // Spieler ist weg → UI ausblenden
            promptCanvas.enabled = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}