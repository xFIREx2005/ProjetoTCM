using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControler : MonoBehaviour
{

    public static float activeSword, activeZarabatana;
    public static bool isPaused;
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
        activeSword = PlayerStatic.Instance.ConsutarSword();
        activeZarabatana = PlayerStatic.Instance.ConsutarZarabatana();
        rb = GetComponent<Rigidbody2D>();
        sprPlayer = GetComponent<SpriteRenderer>();
        objLife = GameObject.Find("LifePlayer");
        isPaused = false;
        Time.timeScale = 1;
    }
    void Update()
    {    
            ChooseGun();  

        
    }

   

    public void DamagePlayer(int damageBullet)
    {
        life -= damageBullet;
        CameraShake.Instance.ShakeCamera(1.2f, 0.3f);
        StartCoroutine(Damage());
        CheckLife();
        if (life <= 0)
        {
            Application.LoadLevel(Application.loadedLevel);
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

        if (activeSword != 1) sword.SetActive(false);
        if (activeZarabatana != 1) zarabatana.SetActive(false);


    }

    
}


