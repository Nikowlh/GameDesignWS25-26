using UnityEngine;
using UnityEngine.UI;

public class ButtonInteraction : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private DoorInteraction doorInteraction;


    public void OnBack()
    {
        doorInteraction.CloseDoor();
        Debug.Log("Drinnen?");
        return;
    }
}
