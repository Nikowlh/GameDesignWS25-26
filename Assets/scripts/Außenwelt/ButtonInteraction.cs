using UnityEngine;
using UnityEngine.UI;

public class ButtonInteraction : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    [Header ("Dialogue (optional)")]
    
    [SerializeField] private string dialogueKnotName;
    
    [SerializeField] private DoorInteraction doorInteraction;
    

    [SerializeField] Canvas bar;
    [SerializeField] Canvas park;
    [SerializeField] Canvas alley;
    [SerializeField] Canvas baerberShop;
    [SerializeField] Canvas parkbank;

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
        alley.gameObject.SetActive(true);
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
    public void AlleyBetreten()
    {
        alley.gameObject.SetActive(true);
    }
    public void AlleyVerlassen()
    {
        alley.gameObject.SetActive(false);
        baerberShop.gameObject.SetActive(false);
        bar.gameObject.SetActive(false);
    }
    public void BaerberShopBetreten()
    {
        baerberShop.gameObject.SetActive(true);
    }
    public void BaerberShopVerlassen()
    {
        alley.gameObject.SetActive(true);
        baerberShop.gameObject.SetActive(false);
    }
    public void ParkbankBetreten()
    {
        parkbank.gameObject.SetActive(true);
    }
    public void ParkbankVerlassen()
    {
        park.gameObject.SetActive(true);
        parkbank.gameObject.SetActive(false);
    }

    public void NPCDialogue()
    {
        if (string.IsNullOrEmpty(dialogueKnotName))
        {
            Debug.LogWarning("Dialogue knot name is empty on " + gameObject.name);
            return;
        }

        GameEventsManager.instance.dialogueEvents.EnterDialogue(dialogueKnotName);
    }
}
