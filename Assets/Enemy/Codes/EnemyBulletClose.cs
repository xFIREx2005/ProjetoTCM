using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemyAttack : MonoBehaviour
{    float timeDestroy;
    public float destroyAttack;

    void Start()
    {
        
    }
    void Update()
    {
        
        

        timeDestroy += 1 * Time.deltaTime;
        if (timeDestroy >= destroyAttack)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.CompareTag("Player"))
            {
                PlayerControler player = collision.GetComponent<PlayerControler>();
                if (player != null)
                {
                    player.DamagePlayer(1);
                }
            }
            Destroy(gameObject);

        }
    }
}
