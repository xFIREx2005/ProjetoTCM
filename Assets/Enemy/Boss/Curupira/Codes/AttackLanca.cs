using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackLanca : MonoBehaviour
{
    float timer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 0.2f)
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
