using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AddNonTriggerCollider();
    }

    // Update is called once per frame
    void AddNonTriggerCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }
    void OnParticleCollision(GameObject other)
    {
        Destroy(gameObject);
        
    }
}
