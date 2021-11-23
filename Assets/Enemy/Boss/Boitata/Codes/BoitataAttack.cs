using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoitataAttack : MonoBehaviour
{
    public GameObject fire;

    public float posX, posY, numFire, dis;
    float timer;
    public bool fireBol, boteBol;
    public Vector2 posFire;

    void Start()
    {
        

        for (int i = 0; i < numFire; i++)
        {
            posX = Random.Range(-8.5f, 8.5f);
            posY = Random.Range(3.5f, -2.7f);
            posFire = new Vector2(posX, posY);
            Instantiate(fire, posFire, transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (fireBol == true)
        {
            timer += Time.deltaTime;
            if (timer >= 10)
            {
                AttackFire();
                timer = 0;
            }
        }

        if (boteBol == true)
        {
            timer += Time.deltaTime;
            if (timer >= 10)
            {
                AttackBote();
                timer = 0;
            }
        }
    }

    void AttackBote()
    {
        numFire = Random.Range(30, 50);

        for (int i = 0; i < numFire; i++)
        {
            posX = Random.Range(-8.5f, 8.5f);
            posY = Random.Range(3.5f, -2.7f);
            posFire = new Vector2(posX, posY);
            Instantiate(fire, posFire, transform.rotation);
        }
    }

    void AttackFire()
    {
        numFire = Random.Range(30, 50);

        for (int i = 0; i < numFire; i++)
        {
            posX = Random.Range(-8.5f, 8.5f);
            posY = Random.Range(3.5f, -2.7f);
            posFire = new Vector2(posX, posY);
            Instantiate(fire, posFire, transform.rotation);
        }
    }
}
