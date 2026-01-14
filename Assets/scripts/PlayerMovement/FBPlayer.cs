using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(FBController))]
public class FBPlayer : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]FBController FBController;
    #region Freeze Methods
    public void FreezePlayer(bool state)
    {
        FBController.SetFrozen(state);

        if (state)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
    #endregion region

    #region Input Handling
    private void OnMove(InputValue value)
    {
        FBController.MoveInput = value.Get<Vector2>();
    }
    
     void OnLook(InputValue value)
        {
        FBController.LookInput = value.Get<Vector2>();
    }

    #endregion

    #region Unity Methods

    void OnValidate()
    {
        if (FBController == null) FBController = GetComponent<FBController>();
    }
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    #endregion

  
}
