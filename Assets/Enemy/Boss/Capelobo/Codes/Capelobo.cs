using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capelobo : EnemyControler
{
    public GameObject pedra, colBote, objLife;
    public Animator animCape;
    public Sprite sprLife5, sprLife4, sprLife3, sprLife2, sprLife1;
    public float posXPedra, posYPedra, numFire;
    public float timer, timerR, attack;
    public Vector2 posPedra;

    void Start()
    {
        life = 50;
        animCape = GetComponent<Animator>();
    }

    


    // Update is called once per frame
    void Update()
    {
        CheckLife();
        timer += Time.deltaTime;

        attack = Random.Range(1, 3);

        if (timer >= timerR)
        {


            if (attack == 1)
            {
                animCape.SetBool("AreaPedra", true);
                
            }
            else if (attack == 2)
            {
                animCape.SetBool("Bote", true);
                timerR = Random.Range(1.5f, 3);
                timer = 0;
            }
        }
    }

    void AttackBote()
    {
        Instantiate(colBote, transform.position, transform.rotation);
    }

    void AttackPedra()
    {
        StartCoroutine(SpawnPedra());
    }

    IEnumerator SpawnPedra()
    {
        yield return new WaitForSeconds(0.8f);
        numFire = Random.Range(30, 50);

        for (int i = 0; i < numFire; i++)
        {
            posXPedra = Random.Range(-3.1f, 4.3f);
            posYPedra = Random.Range(4.5f, -2f);
            posPedra = new Vector2(posXPedra, posYPedra);
            Instantiate(pedra, posPedra, transform.rotation);
            timerR = Random.Range(3f, 4);
            timer = 0;
        }
    }
    public void animStop()
    {
        animCape.speed = 0;
    }
    public void animIdle()
    {
        animCape.SetBool("AreaPedra", false);
        animCape.SetBool("Bote", false);
    }

    void CheckLife()
    {
        if (life > 40) objLife.GetComponent<SpriteRenderer>().sprite = sprLife5;
        if (life > 30 && life <= 40) objLife.GetComponent<SpriteRenderer>().sprite = sprLife4;
        if (life > 20 && life <= 30) objLife.GetComponent<SpriteRenderer>().sprite = sprLife3;
        if (life > 10 && life <= 20) objLife.GetComponent<SpriteRenderer>().sprite = sprLife2;
        if (life >= 0 && life <= 10) objLife.GetComponent<SpriteRenderer>().sprite = sprLife1;
    }


}
