using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public float speed { get; set; }
    public int life { get; set; }
    public bool dash {get; set;}
    public bool attack { get; set; }
    public int chooseGun { get; set; }
    public bool damage { get; set; }
    public float timeDamage { get; set; }

    public Player()
    {
    }
    public Player(float speed, int life, bool dash, bool attack, int chooseGun, bool damage, float timeDamage)
    {
        this.speed = speed;
        this.life = life;
        this.dash = dash;
        this.attack = attack;
        this.chooseGun= chooseGun;
        this.damage = damage;
        this.timeDamage = timeDamage;

    }
}
