using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public float speed { get; set; }
    public float jump { get; set; }
    public float rotacao { get; set; }
    public float escala { get; set; }

    public Player()
    {
    }
    public Player(float speed, float jump, float rotacao, float escala)
    {
        this.speed = speed;
        this.jump = jump;
        this.rotacao = rotacao;
        this.escala = escala;
    }
}
