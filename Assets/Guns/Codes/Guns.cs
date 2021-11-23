using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guns
{
    public float coldown { get; set; }
    public float speed { get; set; }
    public float destroyAttack { get; set; }

    public Guns()
    {
    }

    public Guns(float coldown, float speed, float destroyAttack)
    {
        this.coldown = coldown;
        this.speed = speed;
        this.destroyAttack = destroyAttack;
    }

  
}
