using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    Guns guns = new Guns(0.5f, 0, 0);
    public GameObject bullet;
    public Transform spawnSword;
    public Animator animSword;
    float timer, timerAttack;
    float timerAnim;
    bool attack, checkAttack;

    void Start()
    {
        spawnSword = GameObject.Find("SpawnSword").transform;
        animSword = GetComponent<Animator>();
        animSword.SetBool("Attack", false);
    }

    void Update()
    {
        timerAttack += 1 * Time.deltaTime;
        if (timerAttack >= 1) checkAttack = true;
        else checkAttack = false;
        

        if (attack == true)
        {
            timerAnim += 1 * Time.deltaTime;
            if (timerAnim <= 0.4f)
            {
                animSword.SetBool("Attack", true);
            }
            else { 
                animSword.SetBool("Attack", false);
                attack = false;
            }
        }

        if(checkAttack == true)
        if (Input.GetMouseButton(0))
        {
            animSword.SetBool("Attack", true);
            checkAttack = false;
                timerAttack = 0;
        }
    }

    void Shoot()
    {               
                animSword.SetBool("Attack", true);
                Instantiate(bullet, spawnSword.position, transform.rotation);
                timer = 0f;
                timerAnim = 0f;
                attack = true;         
    }
}
