using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZarabatanaAttack : MonoBehaviour
{
    Guns guns = new Guns(0.8f, 0, 0);
    public GameObject bullet;
    Transform spawnZarabatana;
    float timer;

    void Start()
    {
        spawnZarabatana = GameObject.Find("SpawnZarabatana").transform;
    }

    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        timer += 1 * Time.deltaTime;

        if (timer >= guns.coldown)
        {
            if (Input.GetMouseButton(0))
            {
                Instantiate(bullet, spawnZarabatana.position, transform.rotation);
                timer = 0f;
            }
        }
    }
}
