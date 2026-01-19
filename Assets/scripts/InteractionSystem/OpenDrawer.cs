using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OpenDrawer : MonoBehaviour, ImInteractible
{
    [SerializeField] private string prompt;
    [SerializeField] private GameObject drawer;

    public bool drawerIsOpen = false;



    public string InteractionPrompt => prompt;


    public bool Interactor(Interactor interactor)
    {
        Debug.Log("Interacted with drawer");
        if (drawerIsOpen == false)
        {
            Debug.Log("Opening drawer");
            OpenTheDrawer();
            drawerIsOpen = true;
        }
        else
        {
            CloseTheDrawer();
            drawerIsOpen = false;
        }

        return true;
    }
    private void OpenTheDrawer()
    {
        transform.Translate(0f,0f,-0.5f);
    }
    private void CloseTheDrawer()
    {
        transform.Translate(0f, 0f,0.5f);
    }
}
