using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Phone : MonoBehaviour, ImInteractible
{
    [SerializeField] private string prompt;


    [Header("Phone Objects")]
    [SerializeField] private GameObject tablePhone;      // das Telefon auf dem Tisch
    [SerializeField] private GameObject cameraPhone;     // das 3D Telefon vor der Kamera
    [SerializeField] private FBPlayer player;

    public string InteractionPrompt => prompt;

   

    public bool Interactor(Interactor interactor)
    {
        Debug.Log("Phone interaction triggered.");

        //deactivate table phone and activate camera phone
        tablePhone.SetActive(false);
        cameraPhone.SetActive(true);
        Console.WriteLine("Phone picked up.");

        player.FreezePlayer(true);
        return true;
    }
    
}
