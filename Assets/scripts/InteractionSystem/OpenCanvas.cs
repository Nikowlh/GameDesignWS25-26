using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OpenCanvas : MonoBehaviour, ImInteractible
{
    [SerializeField] private GameObject canvasToOpen;
    [SerializeField] private GameObject npcToOpen;
    [SerializeField] private string prompt;
    [SerializeField] private FBPlayer player;
    public string InteractionPrompt => prompt;
    public bool Interactor(Interactor interactor)
    
       
        {
            Debug.Log("Opening canvas");
            canvasToOpen.SetActive(true);
            npcToOpen.SetActive(true);
            player.FreezePlayer(true);
            return true;
        }

    

}
