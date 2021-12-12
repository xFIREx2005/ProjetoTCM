using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zarabatana : GunsControler
{
    // Start is called before the first frame update
    void Start()
    {
        
        checkAttack = true;
        coldown = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerControler.isPaused)
        {
            AttackZarabatana();
            Aim();
        }
        
    }
    public void CheckAttack()
    {
        checkAttack = true;
    }



    protected void AttackZarabatana()
    {
        if (checkAttack == true)
            if (Input.GetMouseButton(0))
            {
                audioAttack.Play();
                Instantiate(bullet, spawnZarabatana.position, transform.rotation);
                StartCoroutine(TimerZarabatana());
                checkAttack = false;
            }
    }

    public IEnumerator TimerZarabatana()
    {
        animSword.SetBool("Attack", false);
        yield return new WaitForSeconds(coldown);
        checkAttack = true;
    }
}
