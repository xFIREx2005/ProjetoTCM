using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    Enemy enemy;
    float timeDamage = 0.2f;
    float timer;
    public int life;
    SpriteRenderer sprEnemy;
    bool damage;

    void Start()
    {
        enemy = new Enemy(0,0,0,0,0,0,life,damage,0);
        sprEnemy = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (life <= 0) Destroy(gameObject);

        if (damage == true) timer += 1 * Time.deltaTime;

        if (timer >= timeDamage)
        {
            sprEnemy.color = Color.white;
            enemy.damage = false;
            timer = 0;

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("AttackPlayer"))
        {
            life -= 1;
            sprEnemy.color = Color.gray;
            damage = true;
        }
    }
}
