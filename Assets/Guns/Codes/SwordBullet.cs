using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBullet : BulletControler
{
    
    void Start()
    {
        damage = 2;
        coldown = 0.4f;
        spawnBullet = GameObject.Find("SpawnSword").transform;
        StartCoroutine(TimerDestroy());
    }

    void Update()
    {
        SwordBullet();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (collision.CompareTag("Enemy"))
            {
                EnemyControler enemy = collision.GetComponent<EnemyControler>();
                if (enemy != null)
                {
                    enemy.DamageEnemy(damage);
                }
            }

        }
    }

}
