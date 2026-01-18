using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;



public class BedInteraction : MonoBehaviour, ImInteractible
{
    [SerializeField] private string prompt;

    [SerializeField] private FBPlayer player;

    [SerializeField] Canvas pressE;

    [SerializeField]Canvas bedMenu;
  
    [SerializeField] UIInteraction uiInteraction;
    public string InteractionPrompt => prompt;


    public bool Interactor(Interactor interactor)
    {
        uiInteraction.otherUiActive = true;
        bedMenu.gameObject.SetActive(true);
        pressE.enabled = false;
        player.FreezePlayer(true);
        Cursor.lockState = CursorLockMode.Confined;
        Debug.Log("Bed interaction activated.");
        return true;
    }
}
