using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granada : GunsControler
{
    public GameObject granada;


    // Start is called before the first frame update
    void Start()
    {
        checkGranada = true;
        coldown = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerControler.isPaused)
        {
            Aim();
            if (checkGranada == true)
            {
                CreateGranada();
            }
        }
    }

    protected void CreateGranada()
    {

        if (activeGrenade == 1)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                audioAttack.Play();
                Instantiate(bullet, transform.position, transform.rotation);
                StartCoroutine(TimerGranada());
                checkGranada = false;
            }
        }
    }

    IEnumerator TimerGranada()
    {
        yield return new WaitForSeconds(3);
        checkGranada = true;
    }

}
