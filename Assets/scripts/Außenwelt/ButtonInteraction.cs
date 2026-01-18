using UnityEngine;
using UnityEngine.UI;

public class ButtonInteraction : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    [Header ("Dialogue (optional)")]
    
    [SerializeField] private string dialogueKnotName;
    
    [SerializeField] private DoorInteraction doorInteraction;
    


    public void OnBack()
    {
        doorInteraction.CloseDoor();
        Debug.Log("Drinnen?");
        return;
    }

    public void NPCDialogue()
    {
        GameEventsManager.instance.dialogueEvents.EnterDialogue("knotName");
        if (!dialogueKnotName.Equals("knotName"))
        {
            GameEventsManager.instance.dialogueEvents.EnterDialogue("knotName");
            Debug.Log("NPC Dialogue gestartet");           
        }
        return;
     }
}
