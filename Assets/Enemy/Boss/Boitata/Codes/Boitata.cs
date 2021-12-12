using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boitata : EnemyControler
{
    public GameObject fire,colBote,objLife;
    public Animator animBoi;
    public Sprite sprLife5, sprLife4, sprLife3, sprLife2, sprLife1;
    public float posXFire, posYFire, numFire;
    public float timer,timerR, attack;
    public bool fireBol, boteBol;
    public Vector2 posFire;
    public Vector2 posBote;
  

    void Start()
    {
        
        life = 36;
        posBote = new Vector2(7.5f, 0.75f);
        animBoi = GetComponent<Animator>();
        timerR = Random.Range(2, 4);
    }

    // Update is called once per frame
    void Update()
    {
        
        timer += Time.deltaTime;
        
        attack = Random.Range(1, 3);

        if (timer >= timerR)
        {
            

            if (attack == 1)
            {
                animBoi.SetBool("AreaFogo", true);
                timerR = Random.Range(3f, 4);
                timer = 0;
            }
            else if (attack == 2)
            {
                animBoi.SetBool("Bote", true);
                timerR = Random.Range(1.5f, 3);
                timer = 0;
            }
        }
    }

    void AttackBote()
    {
        Instantiate(colBote, posBote, transform.rotation);
    }

    void AttackFire()
    {
        numFire = Random.Range(40, 60);

        for (int i = 0; i < numFire; i++)
        {
            posXFire = Random.Range(-5.8f, 7.3f);
            posYFire = Random.Range(5f, -5.3f);
            posFire = new Vector2(posXFire, posYFire);
            Instantiate(fire, posFire, transform.rotation);
        }
    }
    public void animStop()
    {
        animBoi.speed = 0;
    }
    public void animIdle()
    {
        animBoi.SetBool("AreaFogo", false);
        animBoi.SetBool("Bote", false);
    }
    void CheckLife()
    {
        if (life > 30) objLife.GetComponent<SpriteRenderer>().sprite = sprLife5;
        if (life > 24 && life <= 30) objLife.GetComponent<SpriteRenderer>().sprite = sprLife4;
        if (life > 18 && life <= 24) objLife.GetComponent<SpriteRenderer>().sprite = sprLife3;
        if (life > 12 && life <= 18) objLife.GetComponent<SpriteRenderer>().sprite = sprLife2;
        if (life <= 6 && life <= 12) objLife.GetComponent<SpriteRenderer>().sprite = sprLife1;
    }



}
