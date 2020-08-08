using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("м/с")][SerializeField] float Speed = 4f;
    

    [SerializeField] float XClamp = 20f;
    [SerializeField] float YClamp = 8.5f;

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
        float xMove = CrossPlatformInputManager.GetAxis("Horizontal");
        float yMove = CrossPlatformInputManager.GetAxis("Vertical");
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
        transform.localRotation = Quaternion.Euler(-30,30,0);
    }
}
