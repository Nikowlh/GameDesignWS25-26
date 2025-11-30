using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

public class DoubleDoorInteraction : MonoBehaviour, ImInteractible
{
    [SerializeField] private DoorScript.Door door;
    [SerializeField] private DoorScript.Door secondDoor;
    [SerializeField] private string prompt;
    public string InteractionPrompt => prompt;
    public bool Interactor(Interactor interactor)
    {
        //open both doors
        door.OpenDoor();
        secondDoor.OpenDoor();

        return true;

    }


}