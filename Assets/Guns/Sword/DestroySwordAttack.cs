using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySwordAttack : MonoBehaviour
{
    Guns guns = new Guns(0, 0.2f);
    Transform spawnBullet;
    float timeDestroy;

    void Start()
    {
        spawnBullet = GameObject.Find("SpawnSword").transform;
    }

    void Update()
    {

        transform.position = spawnBullet.position;
        transform.rotation = spawnBullet.rotation;

        timeDestroy += 1 * Time.deltaTime;
        if (timeDestroy >= guns.destroyAttack)
        {
            Destroy(gameObject);
        }

    }

}
