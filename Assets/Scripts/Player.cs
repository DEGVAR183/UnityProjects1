using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("м/с")][SerializeField] float xSpeed = 20f;
    [SerializeField] float XClamp = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xMove = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xMove * xSpeed * Time.deltaTime;
        float newXPos = transform.localPosition.x + xOffset;
        float clampXPos = Mathf.Clamp(newXPos, -XClamp, XClamp);

        transform.localPosition = new Vector3(clampXPos, transform.localPosition.y,transform.localPosition.z);


    }
}
