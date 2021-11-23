using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZarabatanaBullet : MonoBehaviour
{
    Guns guns = new Guns(0, 20, 0.4f);
    private float timer;

    void Start()
    {
 
    }
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * guns.speed);

        timer += 1 * Time.deltaTime;
        if (timer >= guns.destroyAttack)
        {
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Colisao" || collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
