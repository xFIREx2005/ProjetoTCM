using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject colAttack;
    public Transform spawnAttack, m_PositionPlayer;
    public float coldown;

  



    float time;

    void Start()
    {
        
    }

    void Update()
    {
        

            time += 1 * Time.deltaTime;
        float _distPlayer = Vector2.Distance(transform.position, m_PositionPlayer.position);

        if (_distPlayer <= 1f) Shoot();
    }

    void Shoot()
    {

        if (time >= coldown)
        {
                Instantiate(colAttack, spawnAttack.position, transform.rotation);
                time = 0f;
        }
    }
}
