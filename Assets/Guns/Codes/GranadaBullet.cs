using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranadaBullet : BulletControler
{
      
    void Start()
    {
        speed = 10;
    }

    // Update is called once per frame
    void Update()
    {
        GranadaBullet();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
timer = 10;
        }
        if (collision.CompareTag("Colisao"))
        {
            timer = 10;

        

        }
    }
}
