using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColBote : MonoBehaviour
{
    public GameObject boitata;
    public Animator animBoi;
    float timer;

    void Start()
    {
        boitata = GameObject.Find("Boitatao");
        animBoi = boitata.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 0.5f)
        {
            animBoi.speed = 1;
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

        }
    }
}
