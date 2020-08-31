using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [Tooltip("В секундах")][SerializeField] float LoadLevelDelay;
    [Tooltip("Префаб эффекта взрыва")] [SerializeField] GameObject explosionFX;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        print("Hit Trigger");
        StartDeath();
        explosionFX.SetActive(true);
        Invoke("RestartLevel", LoadLevelDelay);
    }
    void StartDeath()
    {
        SendMessage("OnPlayerDeath");
    }
    void RestartLevel()
    {
        SceneManager.LoadScene(1);
    }
}
