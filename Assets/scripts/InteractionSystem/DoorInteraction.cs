using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class DoorInteraction : MonoBehaviour, ImInteractible
{
    [SerializeField] private FBPlayer player;

    [SerializeField] private DoorScript.Door door;
    [SerializeField] private string prompt;

    [SerializeField] private CinemachineCamera innenCam;
    [SerializeField] private CinemachineCamera auﬂenCam;

    [SerializeField] UIInteraction uiInteraction;
    


    public Canvas auﬂenWelt;

    public bool drauﬂen = false;

    public string InteractionPrompt => prompt;
    public bool Interactor(Interactor interactor)
    {
        door.OpenDoor();

        drauﬂen = !drauﬂen;
       
            if (drauﬂen)
        {
            player.FreezePlayer(true);
            auﬂenWelt.enabled = true;
            Cursor.lockState = CursorLockMode.None;
            
            Debug.Log("Drauﬂen");
            uiInteraction.otherUiActive = true;



                auﬂenCam.Priority = 10;
            innenCam.Priority = 0;
        }
        else
        {
            player.FreezePlayer(false);
            auﬂenWelt.enabled = false;
            Cursor.lockState = CursorLockMode.Locked;
            uiInteraction.otherUiActive = false;

            auﬂenCam.Priority = 0;
            innenCam.Priority = 10;
        }
        

        return true;

    }

    public void RotatePlayer()
    {
        Vector3 currentRotation = player.transform.eulerAngles;
        currentRotation.y += 180f;
        player.transform.eulerAngles = currentRotation;
    }

    public void CloseDoor()
    {
        drauﬂen = !drauﬂen;
        player.FreezePlayer(false);
       Debug.Log("Drinnen?");
        Cursor.lockState = CursorLockMode.Locked;
        door.open = false;
        door.asource.clip = door.closeDoor;
        RotatePlayer();
        uiInteraction.otherUiActive = false;

        auﬂenCam.Priority = 0;
        innenCam.Priority = 10;
    }
}
