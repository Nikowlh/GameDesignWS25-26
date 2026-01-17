using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;



public class BedInteraction : MonoBehaviour, ImInteractible
{
    [SerializeField] private string prompt;

    [SerializeField] private FBPlayer player;

    [SerializeField]Canvas bedMenu;
  
    public string InteractionPrompt => prompt;


    public bool Interactor(Interactor interactor)
    {
       bedMenu.gameObject.SetActive(true);
        player.FreezePlayer(true);
        Cursor.lockState = CursorLockMode.Confined;
        Debug.Log("Bed interaction activated.");
        return true;
    }
}
