using System;
using System.Collections;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine;
using JetBrains.Annotations;
using Ezereal;

public class PhoneLogic : MonoBehaviour
{
    [SerializeField] private FBPlayer player;
    [SerializeField] private GameObject tablePhone;      
    [SerializeField] private GameObject cameraPhone;

    [Header("Phone Data")]
    [SerializeField] private PhoneDatabase database;

    [Header("Number Buttons (assign 0–9)")]
    [SerializeField] private GameObject[] numberButtons; // 10 GameObjects (0-9)

    [Header("Action Buttons")]
    [SerializeField] private GameObject clearButton;
    [SerializeField] private GameObject callButton;
    [SerializeField] private GameObject exitButton;

    [Header("Screen")]
    [SerializeField] private TMP_Text screenText;
   
    public InputActionReference callPhoneAction;

    private string enteredNumber = "";
    public bool FullNumberEntered;

    private void Update()
    {
        if (enteredNumber.Length >= 7)
        {
            FullNumberEntered = true;    
        }
        else         
        {
            FullNumberEntered = false;
        }
    }

    private void OnEnable()
    {
    callPhoneAction.action.performed += ButtonKlick;
    callPhoneAction.action.Enable();

    }
    private void OnDisable()
    { 
    callPhoneAction.action.performed -= ButtonKlick;
    callPhoneAction.action.Disable();
    }

    public void ButtonKlick(InputAction.CallbackContext context)
    {
        
        Debug.Log("Mouse button pressed.");

        //detection raycast if phone button was pressed and detect it in the array
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit buttonhit = new RaycastHit();
        if (Physics.Raycast(ray, out buttonhit))
        {
            for (int i = 0; i < numberButtons.Length; i++)
            {
                if (buttonhit.transform.gameObject == numberButtons[i])
                {
                    if (numberButtons[i].GetComponent<ButtonPusher>() != null)
                    {
                        numberButtons[i].GetComponent<ButtonPusher>().PushButton();
                    }

                    if (!FullNumberEntered)
                    { 
                        if (enteredNumber.Length == 3)
                        {
                            enteredNumber += "-";
                        }
                        enteredNumber += i.ToString();
                    screenText.text = enteredNumber;
                       
                        Debug.Log("Button " + i + " pressed. Current number: " + enteredNumber);
                    }
                    return;
                }
            }
            if (buttonhit.transform.gameObject == clearButton)
            {
                enteredNumber = "";
                screenText.text = enteredNumber;
                Debug.Log("Clear button pressed. Current number cleared.");
                return;
            }
            if (buttonhit.transform.gameObject == callButton)
            {
                Debug.Log("Call button pressed. Attempting to call " + enteredNumber);
               // MakeCall(enteredNumber);
                return;
            }
            if (buttonhit.transform.gameObject == exitButton)
            {
                Debug.Log("Exit button pressed. Hanging up.");
                HangUp();
                return;
            }
         
        }
        else
        {

            Debug.Log("No button was pressed.");
        }


    }
    public void HangUp()
    {
                tablePhone.SetActive(true);
        cameraPhone.SetActive(false);
        player.FreezePlayer(false);
        enteredNumber = "";
        screenText.text = enteredNumber;
    }

    //esc key to exit phone
    private void UpdatePhoneExit()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            HangUp();
        }
    }

}
