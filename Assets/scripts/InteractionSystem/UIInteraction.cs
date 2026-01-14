using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class UIInteraction : MonoBehaviour
{
    [SerializeField]DoorInteraction DoorInteraction;

    [Header("UI")]
    public Canvas promptCanvas;
    public TMP_Text promptText;

    [Header("Interaction Settings")]
    public float detectionRadius = 1.5f;
    public LayerMask interactorMask;

    private ImInteractible interactible;
    private bool isInRange = false;

    public static object PromptCanvas { get; internal set; }

    private void Start()
    {
        // Sicherstellen, dass Canvas initial deaktiviert ist (falls gesetzt)
        if (promptCanvas != null)
            promptCanvas.enabled = false;
        else
            Debug.LogWarning($"[{nameof(UIInteraction)}] 'promptCanvas' ist nicht gesetzt auf GameObject '{gameObject.name}'.");

        // Versuchen, das Interactible am selben Objekt oder im Parent zu finden
        interactible = GetComponent<ImInteractible>();
        if (interactible == null)
        {
            interactible = GetComponentInParent<ImInteractible>();
            if (interactible == null)
                Debug.LogWarning($"[{nameof(UIInteraction)}] Kein ImInteractible gefunden auf oder über '{gameObject.name}'. NullReference ist möglich.");
        }
    }

    private void Update()
    {
        // Prüfen, ob ein Interactor in der Nähe ist
        isInRange = Physics.CheckSphere(transform.position, detectionRadius, interactorMask);

        if (isInRange)
        {
            // Prompt anzeigen (nur wenn Canvas gesetzt)
            if (promptCanvas != null)
                promptCanvas.enabled = true;

            // Prompt-Text setzen, wenn sowohl Text als auch Interactible existieren
            if (promptText != null && interactible != null)
                promptText.text = interactible.InteractionPrompt;

            // Sicherstellen, dass Keyboard.current existiert bevor die Taste geprüft wird
            if (Keyboard.current != null && Keyboard.current.eKey.wasPressedThisFrame)
            {
                // disable canvas after interaction

                promptCanvas.enabled = false;
                // Safely call the interactor (verhindert NullReference)
                if (interactible != null)
                {
                    interactible.Interactor(null);
                }
                else
                {
                    Debug.LogWarning($"[{nameof(UIInteraction)}] Interaktion ausgelöst, aber 'interactible' ist null auf '{gameObject.name}'.");
                }

                if (promptCanvas != null)
                    promptCanvas.enabled = false;
            }
        }
        
        
        else
        {
            // Spieler ist weg → UI ausblenden (nur wenn Canvas gesetzt)
            if (promptCanvas != null)
                promptCanvas.enabled = false;
        }
        if (DoorInteraction.draußen == true)
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