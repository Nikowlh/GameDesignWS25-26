using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Kühlschrank : MonoBehaviour, ImInteractible
{
    [SerializeField] private string prompt;
    [SerializeField] private DoorScript.Door door;

    public string InteractionPrompt => prompt;


    public bool Interactor(Interactor interactor)
    {
        door.OpenDoor();

        return true;
    }
}