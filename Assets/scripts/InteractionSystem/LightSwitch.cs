using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LightSwitch : MonoBehaviour, ImInteractible
{
    [SerializeField] private string prompt;
    [Header("LightSource")]
    [SerializeField] private GameObject lighSource;

    public string InteractionPrompt => prompt;


    public bool Interactor(Interactor interactor)
    {
        Debug.Log("LightSwitch interacted with.");
        lighSource.SetActive(!lighSource.activeSelf);
        return true;
    }
}
