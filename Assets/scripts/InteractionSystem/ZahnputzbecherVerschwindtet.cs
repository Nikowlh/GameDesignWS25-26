using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Zahnputzbecher : MonoBehaviour, ImInteractible
{
    [SerializeField] private string prompt;
    [SerializeField] private GameObject X;

    public string InteractionPrompt => prompt;


    public bool Interactor(Interactor interactor)
    {
       

        return true;
    }
}
