using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
   
    protected Rigidbody2D rb;
    protected Vector2 moveDirection;
    protected SpriteRenderer sprPlayer;
    public GameObject objLife, smokeRun, smokeSpawn;
    public Sprite sprlife1, sprlife2, sprlife3;
    public int gun;
    public GameObject sword, zarabatana;
    protected int life;
    protected float speed;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprPlayer = GetComponent<SpriteRenderer>();
        objLife = GameObject.Find("LifePlayer");
    }
    void Update()
    {
        
    }

   

    public void DamagePlayer(int damageBullet)
    {
        life -= damageBullet;
        StartCoroutine(Damage());
        CheckLife();
        if (life <= 0)
        {  
        }

    }

    IEnumerator Damage()
    {
        sprPlayer.color = Color.grey;
        yield return new WaitForSeconds(0.1f);
        sprPlayer.color = Color.white;
    }

    protected void CheckLife()
    {
        if (life >= 3) objLife.GetComponent<SpriteRenderer>().sprite = sprlife3;
        if (life == 2) objLife.GetComponent<SpriteRenderer>().sprite = sprlife2;
        if (life <= 1) objLife.GetComponent<SpriteRenderer>().sprite = sprlife1;
    }

    public void ChooseGun()
    {
        if (gun == 1)
        {
            sword.SetActive(true);
            zarabatana.SetActive(false);
        }
        else if (gun == 2)
        {
            zarabatana.SetActive(true);
            sword.SetActive(false);
        }

        if (Input.GetMouseButtonDown(1) && gun == 1)
        {
            Zarabatana armas = zarabatana.GetComponent<Zarabatana>();
            armas.checkAttack = true;
            gun = 2;
        }
        else if (Input.GetMouseButtonDown(1) && gun == 2)
        {
            Sword armas = sword.GetComponent<Sword>();
            armas.checkAttack = true;
            gun = 1;
        }

    }
}
