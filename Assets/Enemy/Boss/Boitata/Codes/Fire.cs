using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public Animator animFire;
    public float velAnimFire;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        animFire = GetComponent<Animator>();

        velAnimFire = Random.Range(0.5f, 2);
        animFire.speed = velAnimFire;
        

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 3)
        {
            transform.localScale -= new Vector3(0.05f, 0.05f, 0);
        }
        if(transform.localScale.x <= 0)
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
        if (collision.gameObject.tag == "AttackPlayer") Destroy(gameObject);
    }
}
