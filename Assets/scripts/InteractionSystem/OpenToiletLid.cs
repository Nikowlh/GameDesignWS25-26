using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OpenToiletLid : MonoBehaviour, ImInteractible
{
    [SerializeField] private string prompt;
    [SerializeField] private GameObject ToiletLid;
    public float openAngle = -90f;
    public bool isOpen = false;
    public float openSpeed = 2f;

    public string InteractionPrompt => prompt;


    public bool Interactor(Interactor interactor)
    {
        isOpen = !isOpen;
       if (isOpen)
        {
            Quaternion targetRotation = Quaternion.Euler(0f, 0f, openAngle);
           
        }
        else
        {
            Quaternion targetRotation = Quaternion.Euler(0f, 0f, 0f);
           
        }


        return true;
    }
}
