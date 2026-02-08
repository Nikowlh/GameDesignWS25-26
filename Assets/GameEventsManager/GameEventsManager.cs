using System;
using UnityEngine;

public class GameEventsManager : MonoBehaviour
{
    public static GameEventsManager instance {get; private set; }

    public DialogueEvents dialogueEvents;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Mehr als eine Instanz von GameEventsManager gefunden! Lösche das DSlikat.");
        }
        instance = this;

        // Initialisiere die Event-Klassen
        dialogueEvents = new DialogueEvents();

        Debug.Log("GameEventsManager initialisiert.");
    }
}
