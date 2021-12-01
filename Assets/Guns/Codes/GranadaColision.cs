using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranadaColision : BulletControler
{

    // Start is called before the first frame update
    void Start()
    {
        scale = new Vector3(0.05f, 0.05f, 0);
        damage = 5;
    }

    // Update is called once per frame
    void Update()
    {
        GranadaColision();
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
