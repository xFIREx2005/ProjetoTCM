using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemyAttack : MonoBehaviour
{
    Transform spawnBullet;
    float timeDestroy;
    public float destroyAttack;

    void Start()
    {
        
    }
    void Update()
    {
        if (GameObject.Find("Cobra"))
        {
            spawnBullet = GameObject.Find("EnemyAttackSpawn").transform;
            transform.position = spawnBullet.position;
            transform.rotation = spawnBullet.rotation;
        }
        else Destroy(gameObject);

        timeDestroy += 1 * Time.deltaTime;
        if (timeDestroy >= destroyAttack)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
