using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZarabatanaBullet : BulletControler
{
    void Start()
    {
        speed = 20;
        damage = 1;
        coldown = 0.3f;
        StartCoroutine(TimerDestroy());
    }

    void Update()
    {
        ZarabatanaBullet();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if(collision.CompareTag("Enemy"))
            {
                EnemyControler enemy = collision.GetComponent<EnemyControler>();
                if(enemy != null)
                {
                    enemy.DamageEnemy(damage);
                }
            }
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Colisao") Destroy(gameObject); 
    }
}
