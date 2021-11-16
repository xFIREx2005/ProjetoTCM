using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;



 

    private float timer;
    public float des;



    void Start()
    {
 
    }
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);

        timer += 1 * Time.deltaTime;
        if (timer >= des)
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
