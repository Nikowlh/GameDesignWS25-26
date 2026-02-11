using UnityEngine;
using System;
using Unity.Cinemachine;

public class StartManager : MonoBehaviour
{
    // Startscreen components
    public GameObject startMenu;
    public Canvas startCanvas;
    public FBPlayer player;

    [SerializeField] private CinemachineCamera auﬂenCam;
    [SerializeField] private CinemachineCamera innenCam;

    public void Start()
    {
        // Ensure the start menu is active and the player is inactive at the beginning
        startMenu.SetActive(true);
        player.gameObject.SetActive(false);
        player.FreezePlayer(true);
        Cursor.lockState = CursorLockMode.Confined;

        //auﬂenCam.Priority = 0;
        //innenCam.Priority = 10;


    }
    public void StartGame()
    {
        // Deactivate the start menu and activate the player
        startMenu.SetActive(false);
        player.gameObject.SetActive(true);
        player.FreezePlayer(false);
        Cursor.lockState = CursorLockMode.None;
        //wenn Cursor verschwindet wider erscheinen lassen
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

    }


}
