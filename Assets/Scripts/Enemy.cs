using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFx;
    [SerializeField] Transform parent;
    [SerializeField] int EnemyPoints = 12;
    [SerializeField] int Hits = 5;

    ScoreBoard scoreBoard;

    void Start() 
    {
        AddBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    void AddBoxCollider()
    {
        var collider = gameObject.AddComponent<BoxCollider>();
        collider.isTrigger = false;
    }

    void OnParticleCollision(GameObject other) 
    {
        scoreBoard.ScoreHit(EnemyPoints);
        Hits--;
        if (Hits < 1)
        {
            KillEnemy();
        }
    }

    void KillEnemy()
    {
        GameObject fx = Instantiate(deathFx, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
