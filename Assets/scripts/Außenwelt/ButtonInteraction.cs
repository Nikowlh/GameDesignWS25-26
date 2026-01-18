using UnityEngine;
using UnityEngine.UI;

public class ButtonInteraction : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    [Header ("Dialogue (optional)")]
    
    [SerializeField] private string dialogueKnotName;
    
    [SerializeField] private DoorInteraction doorInteraction;
    

    [SerializeField]Canvas bar;
    [SerializeField]Canvas park;


    public void OnBack()
    {
        doorInteraction.CloseDoor();
        Debug.Log("Drinnen?");
        return;
    }
    //Open Bar Canvas / Close Bar Canvas
    public void BarBetreten()
    {        
        bar.gameObject.SetActive(true);
    }
    public void BarVerlassen()
    {
        bar.gameObject.SetActive(false);
    }

    public void ParkBetreten()
    {
        park.gameObject.SetActive(true);
    }
    public void ParkVerlassen()
    {
        park.gameObject.SetActive(false);
    }
    public void NPC1()
    {
        Debug.Log("NPC1 interaction activated.");
    }
}
