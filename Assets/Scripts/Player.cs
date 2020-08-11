﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("м/с")][SerializeField] float Speed = 4f;
    

    [SerializeField] float XClamp = 30f;
    [SerializeField] float YClamp = 10f;
    [SerializeField] float xRotFactor = -1.8f;
    [SerializeField] float yRotFactor = 1.5f;
    [SerializeField] float zRotFactor = -1.5f;
    [SerializeField] float xMoveRot = -10f;
    [SerializeField] float yMoveRot = 10f;
    [SerializeField] float zMoveRot = 10f;

    float xMove, yMove;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        MoveShip();
        RotateShip();
    }
    void MoveShip()
    {
        xMove = CrossPlatformInputManager.GetAxis("Horizontal");
        yMove = CrossPlatformInputManager.GetAxis("Vertical");
        float xOffset = xMove * Speed * Time.deltaTime;
        float yOffset = yMove * Speed * Time.deltaTime;
        float newXPos = transform.localPosition.x + xOffset;
        float clampXPos = Mathf.Clamp(newXPos, -XClamp, XClamp);

        float newYPos = transform.localPosition.y + yOffset;
        float clampYPos = Mathf.Clamp(newYPos, -YClamp, YClamp);

        transform.localPosition = new Vector3(clampXPos, clampYPos, transform.localPosition.z);

    }
    void RotateShip()
    {
        float xRot = transform.localPosition.y * xRotFactor + yMove * xMoveRot;
        float yRot = transform.localPosition.x * yRotFactor + xMove * yMoveRot;
        float zRot = xMove * zMoveRot;
        transform.localRotation = Quaternion.Euler(xRot,yRot,zRot);
    }
}
