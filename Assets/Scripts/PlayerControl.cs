using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerControl : MonoBehaviour

{
    [Header("General")]
    [Tooltip("м/с")] [SerializeField] float Speed = 4f;

    [SerializeField] float XClamp = 40f;
    [SerializeField] float YClamp = 15f;
    [SerializeField] GameObject[] guns;

    [Header("RotFactor")]
    [SerializeField] float xRotFactor = -1.34f;
    [SerializeField] float yRotFactor = 1.25f;
    [SerializeField] float zRotFactor = -0.5f;
    [Header("RotationOnMove")]
    [SerializeField] float xMoveRot = -20f;
    [SerializeField] float yMoveRot = 20f;
    [SerializeField] float zMoveRot = -20f;

    bool isControlEnabled = true;
    float xMove, yMove;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (isControlEnabled)
        {
            MoveShip();
            RotateShip();

        }
    }

    void OnPlayerDeath()
    {
        print("Control OFF");
        isControlEnabled = false;
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
        transform.localRotation = Quaternion.Euler(xRot, yRot, zRot);
    }
    void FireGuns()
    {
        if (CrossPlatformInputManager.GetButton("Fire1"))

        {
            ActiveGuns();
        }
        else
        {
            DeactiveGuns();
        }

    }
    void ActiveGuns()
    {
        foreach (GameObject gun in guns)
        {
            gun.GetComponent<ParticleSystem>().enableEmission = true;
        }
    }
    void DeactiveGuns()
    {
        foreach (GameObject gun in guns)
        {
            gun.GetComponent<ParticleSystem>().enableEmission = false;
        }

    }
}
