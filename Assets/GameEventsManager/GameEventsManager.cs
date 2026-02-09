using System;
using UnityEngine;

public class GameEventsManager : MonoBehaviour
{
    public static GameEventsManager instance {get; private set; }

    public DialogueEvents dialogueEvents;
    public GameState gameState;

    private void Awake()
    {
        if (instance != null &&  instance != this)
        {
            Debug.LogError("Mehr als eine Instanz von GameEventsManager gefunden! Lösche das DSlikat.");
        }
        instance = this;

        // Initialisiere die Event-Klassen
        dialogueEvents = new DialogueEvents();
        gameState = new GameState();

        Debug.Log("GameEventsManager initialisiert.");
    }
    
}
