using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFx;
    [SerializeField] Transform parent;

    void Start() 
    {
        var collider = gameObject.AddComponent<BoxCollider>();
        collider.isTrigger = false;
    }

    void OnParticleCollision(GameObject other) 
    {
        GameObject fx = Instantiate(deathFx, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
