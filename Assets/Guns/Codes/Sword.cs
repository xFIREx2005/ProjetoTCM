using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : GunsControler
{
    // Start is called before the first frame update
    void Start()
    {
        
        checkAttack = true;
        coldown = 0.3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerControler.isPaused)
        {
            AttackSword();
            Aim();
        }
    }
    public void CheckAttack()
    {
        checkAttack = true;
    }

    protected void AttackSword()
    {
        if (checkAttack == true)
            if (Input.GetMouseButton(0))
            {
                audioAttack.Play();
                animSword.SetBool("Attack", true);
                checkAttack = false;
                attack = true;
            }

        if (attack == true)
        {
            Instantiate(bullet, spawnSword.position, transform.rotation);
            attack = false;
        }
    }

    IEnumerator TimerSword()
    {
        animSword.SetBool("Attack", false);
        yield return new WaitForSeconds(coldown);
        checkAttack = true;
    }

}
