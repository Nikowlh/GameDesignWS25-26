using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerCam : MonoBehaviour
{
    public float sesX;
    public float sesY;

    public Transform orientierung;

    float xRotation;
    float yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    //get mouse input
    private void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * sesX * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * sesY * Time.deltaTime;

        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //rotate cam and orientation

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientierung.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
