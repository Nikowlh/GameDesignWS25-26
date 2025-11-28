using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

public class DoorInteraction : MonoBehaviour, ImInteractible
{
    [SerializeField] private DoorScript.Door door;
    [SerializeField] private string prompt;
    public string InteractionPrompt => prompt;
    public bool Interactor(Interactor interactor)
    {
        Debug.Log("Opening door");
        door.OpenDoor();
        return true;

    }


}
