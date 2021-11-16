using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnAttack;
    public float coldown;

    float shoot;

    void Start()
    {

    }

    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        shoot += 1 * Time.deltaTime;

        if (shoot >= coldown)
        {
            if (Input.GetMouseButton(0))
            {
                Instantiate(bullet, spawnAttack.position, transform.rotation);
                shoot = 0f;
            }
        }
    }
}
