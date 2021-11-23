using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{
    public static int inst = 0;
    public float posX { get; set; }
    public float posY { get; set; }
    public float speedP { get; set; }
    public float speedF { get; set; }
    public float disPatrol { get; set; }
    public float disFollow { get; set; }
    public int life { get; set; }
    public bool damage { get; set; }
    public float colAttack { get; set; }
    public Enemy()
    {
        
    }
    public Enemy(float posX, float posY, float speedP, float speedF,  float disPatrol, float disFollow, int life, bool damage, float colAttack)
    {
        
        this.posX = posX;
        this.posY = posY;
        this.speedP = speedP;
        this.speedF = speedF;
        this.disPatrol = disPatrol;
        this.disFollow = disFollow;
        this.life = life;
        this.damage = damage;
        this.colAttack = colAttack;
    }
    public static void QtdInstancias()
    {
        inst += 1;
        Debug.Log("Nro de intâncias  = " + inst.ToString());
    }
}
