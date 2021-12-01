using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranadaBullet : BulletControler
{
      
    void Start()
    {
        speed = 15;
    }

    // Update is called once per frame
    void Update()
    {
        GranadaBullet();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyAttack")
        {
            speed -= 5;
        }
    }
}
