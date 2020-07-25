using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class splashScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        Invoke("FirstLevelLoad", 2f);
    }

    // Update is called once per frame
    void FirstLevelLoad()
    {
        SceneManager.LoadScene(1);
    }
}
