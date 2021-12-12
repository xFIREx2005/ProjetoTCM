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
    public AudioSource audioAttack;
    public static float activeGrenade;

    void Start()
    {

        activeGrenade = PlayerStatic.Instance.ConsutarGrenade();
        checkAttack = true;
        sprGun = GetComponent<SpriteRenderer>();
    }


    protected void Aim()
    {
        if (!PlayerControler.isPaused)
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);
            Vector2 offset = new Vector2(mousePos.x - screenPoint.x, mousePos.y - screenPoint.y);
            float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
            sprGun.flipY = (mousePos.x < screenPoint.x);
        }
    }
}
