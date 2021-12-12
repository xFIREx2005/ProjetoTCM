using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControler : MonoBehaviour
{
    protected Vector3 scale;


    public Transform spawnBullet, colGrenade, explosionGrenade;
    protected int damage;
    protected float speed, coldown, timer;

    

    void Start()
    {
        
    }

    protected void ZarabatanaBullet()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
        transform.localScale -= new Vector3(0.005f, 0.005f, 0);
    }

    protected void SwordBullet()
    {
        transform.position = spawnBullet.position;
        transform.rotation = spawnBullet.rotation;
    }

    protected void GranadaBullet()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
        timer += Time.deltaTime;
        if (timer >= 0.6f)
        {
            Instantiate(explosionGrenade, transform.position, transform.rotation);
            Instantiate(colGranada, transform.position, transform.rotation);
          
            Destroy(gameObject);
        }
    }

    protected void GranadaColision()
    {
        
        if (transform.localScale.x <= 3f)
        {
            transform.localScale += scale;
        }
        else
        {
            scale = new Vector3(-0.1f, -0.1f, 0);
            transform.localScale += scale;
        }
        if (transform.localScale.x <= 0)
        {
            Destroy(gameObject);
        }
    }

    public IEnumerator TimerDestroy()
    {
        yield return new WaitForSeconds(coldown);
        Destroy(gameObject);
    }


}
