using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatic : MonoBehaviour
{
    private float playerX = 0.5f;
    private float playerY = 2.5f;
    private int activeSword = 0;
    private int activeZarabatana = 0;
    private int activeGrenade = 0;

    private static PlayerStatic instance = null;
    public static PlayerStatic Instance { get { return instance; } }

    private void Start()
    {
        if (instance) Destroy(gameObject);
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }



    public void GravarPositionX(float position)
    {
        this.playerX = position;
    }
    public void GravarPositionY(float position)
    {
        this.playerY = position;
    }

    public float ConsutarPostionX()
    {
        return this.playerX;
    }
    public float ConsutarPostionY()
    {
        return this.playerY;
    }

    public void GravarSword(int active)
    {
        this.activeSword = active;
    }

    public void GravarZarabatana(int active)
    {
        this.activeZarabatana = active;
    }

    public void GravarGrenade(int active)
    {
        this.activeGrenade = active;
    }

    public float ConsutarSword()
    {
        return this.activeSword;
    }
    public float ConsutarZarabatana()
    {
        return this.activeSword;
    }
    public float ConsutarGrenade()
    {
        return this.activeSword;
    }
}
