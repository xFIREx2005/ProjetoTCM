using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LontraLife : MonoBehaviour
{
    Enemy enemy = new Enemy(0, 0, 0, 0, 0, 0, 2, false, 0);
    float timeDamage = 0.2f;
    float timer;
    SpriteRenderer sprEnemy;

    void Start()
    {
        sprEnemy = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (enemy.life <= 0) Destroy(gameObject);

        if(enemy.damage == true) timer += 1 * Time.deltaTime;

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
            enemy.life -= 1;
            sprEnemy.color = Color.gray;
            enemy.damage = true;
        }
    }
}
