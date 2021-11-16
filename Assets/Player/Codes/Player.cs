using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public float speed { get; set; }
    public int life { get; set; }

    public Player()
    {
    }
    public Player(float speed, int life)
    {
        this.speed = speed;
        this.life = life;

    }
}
