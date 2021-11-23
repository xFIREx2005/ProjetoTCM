using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    Enemy enemy;
    public GameObject colAttack;
    public Transform spawnAttack, m_PositionPlayer;
    float time;
    public float coldown;

    void Start()
    {
        enemy = new Enemy(0, 0, 0, 0, 0, 0, 0, false, coldown);
        m_PositionPlayer = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Check();
    }
    void Check()
    {
        time += 1 * Time.deltaTime;
        float _distPlayer = Vector2.Distance(transform.position, m_PositionPlayer.position);

        if (_distPlayer <= 1.7f) Shoot();
    }

    void Shoot()
    {

        if (time >= enemy.colAttack)
        {
            Instantiate(colAttack, spawnAttack.position, transform.rotation);
            time = 0f;
        }
    }
}
