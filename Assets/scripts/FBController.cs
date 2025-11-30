using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;


[RequireComponent(typeof(CharacterController))]
public class FBController : MonoBehaviour
{
    [Header("Movement Parameters")]
    public float MoveSpeed = 3.5f;
    public float Acceleration = 15f;

    public Vector3 CurrentVelocity { get; private set; }
    public float CurrentSpeed { get; private set; }

    [Header("Looking Parameters")]
    public Vector2 LookSensitivity = new Vector2(0.1f, 0.1f);

    public float PitchLimit = 85f;

    [Header("Freeze Player")]
    public bool IsFrozen { get; private set; } = false;

    [SerializeField] float currentPitch = 0f;

    public float CurrentPitch
    {
        get => currentPitch;
        set
        {
            currentPitch = Mathf.Clamp(value, -PitchLimit, PitchLimit);
        }
    }

    [Header("Input")]
    public Vector2 MoveInput;
    public Vector2 LookInput;

    [Header("Components")]
    [SerializeField] CinemachineCamera fpCamera;
    [SerializeField] CharacterController charakterController;
    #region freeze Methods

    public void SetFrozen(bool state)
    {
        IsFrozen = state;
        Debug.Log("Player frozen state set to: " + state);
        if (state)
        {
            CurrentVelocity = Vector3.zero;
            CurrentSpeed = 0f;
            MoveInput = Vector2.zero;
            LookInput = Vector2.zero;
        }
    }




    #endregion
    #region Unity Methods

    private void OnValidate()
    {
        if (charakterController == null)
        {
            charakterController = GetComponent<CharacterController>();

        }
    }

    void Update()
    {
        if (IsFrozen) return;
        MoveUpdate();
        LookUpdate();
    }
    #endregion

    #region Controller Methods
    void MoveUpdate()
    {
        Vector3 motion = transform.forward * MoveInput.y + transform.right * MoveInput.x;
        motion.y = 0f;
        motion.Normalize();

        if (motion.sqrMagnitude >= 0.01f)
        {
            CurrentVelocity = Vector3.MoveTowards(CurrentVelocity, motion * MoveSpeed, Acceleration * Time.deltaTime);            //Überarbeiten
        }
        else
        {
            CurrentVelocity = Vector3.MoveTowards(CurrentVelocity, Vector3.zero, Acceleration * Time.deltaTime);
        }

        float verticalVelocity = Physics.gravity.y * 20f * Time.deltaTime;

        Vector3 fullVelocity = new Vector3(CurrentVelocity.x, verticalVelocity, CurrentVelocity.z);

        charakterController.Move(fullVelocity * Time.deltaTime);

        //update current speed
        CurrentSpeed = CurrentVelocity.magnitude;
    }

    void LookUpdate()
    {
        Vector2 input = new Vector2(LookInput.x * LookSensitivity.x, LookInput.y * LookSensitivity.y);

        // looking uon and down
        CurrentPitch -= input.y;
        fpCamera.transform.localRotation = Quaternion.Euler(CurrentPitch, 0f, 0f);

        // looking left and right
        transform.Rotate(Vector3.up * input.x);
    }
    #endregion


}