using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunsControler : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnSword, spawnZarabatana;
    public Animator animSword;
    public SpriteRenderer sprGun;
    public bool attack, checkAttack, checkGranada;
    protected float coldown;
    

    void Start()
    {
        
        checkAttack = true;
        sprGun = GetComponent<SpriteRenderer>();
    }


    protected void AttackSword()
    {
        if (checkAttack == true)
            if (Input.GetMouseButton(0))
            {
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

    protected void AttackZarabatana()
    {
        if (checkAttack == true)
            if (Input.GetMouseButton(0))
            {
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

    protected void Aim()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        Vector2 offset = new Vector2(mousePos.x - screenPoint.x, mousePos.y - screenPoint.y);
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        sprGun.flipY = (mousePos.x < screenPoint.x);
    }

    protected void CreateGranada()
    {
        if(checkGranada == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Instantiate(bullet, transform.position, transform.rotation);
                StartCoroutine(TimerGranada());
                checkGranada = false;
            }
        }
    }
    IEnumerator TimerGranada()
    {
        yield return new WaitForSeconds(coldown);
        checkGranada = true;
    }


}
