using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoitataAttack : MonoBehaviour
{
    public GameObject fire,colBote;
    public Animator animBoi;

    public float posX, posY, numFire;
    public float timer,timerR, attack;
    public bool fireBol, boteBol;
    public Vector2 posFire;
    public Vector2 posBote;

    void Start()
    {
        posBote = new Vector2(4.4f, -0.2f);
        animBoi = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        timerR = Random.Range(5, 10);
        attack = Random.Range(0, 3);

        if (timer >= timerR)
        {
            

            if (attack == 1)
            {
                animBoi.SetBool("AreaFogo", true);
                timer = 0;
            }
            else if (attack == 2)
            {
                animBoi.SetBool("Bote", true);
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
        numFire = Random.Range(20, 30);

        for (int i = 0; i < numFire; i++)
        {
            posX = Random.Range(-4f, 2.6f);
            posY = Random.Range(2.6f, -2.8f);
            posFire = new Vector2(posX, posY);
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
}
