﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float mouseSensivity;
    private Transform parent;



    void Start()
    {
        parent = transform.parent;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    private void Rotate(){
        float mouseX = Input.GetAxis("Mouse X") * mouseSensivity * Time.deltaTime;
        parent.Rotate(Vector3.up, mouseX);
    }
}
