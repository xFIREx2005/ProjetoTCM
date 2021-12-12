using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackFuracao : MonoBehaviour
{
    float timer;
    public GameObject Curupira;
    public Animator animCurupira;
    void Start()
    {
        Curupira = GameObject.Find("Curupira");
        animCurupira = Curupira.GetComponent<Animator>();
    }

    
    void Update()
    {
        transform.position = Curupira.transform.position;

        timer += Time.deltaTime;
        if(timer >= 2f)
        {
            animCurupira.SetBool("Furacao", false);
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
                    animCurupira.SetBool("Furacao", false);
                    player.DamagePlayer(1);
                }
            }
            Destroy(gameObject);
        }
    }
}
