using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PromtUI : MonoBehaviour
{
 private Camera mainCamera;
    private void Start()
    {
        mainCamera = Camera.main;
    }
    private void LateUpdate()
    {
     var rotation = mainCamera.transform.rotation;
        transform.LookAt(transform.position + rotation * Vector3.forward,
            rotation * Vector3.up);
    }
}

