using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeixeAttack : MonoBehaviour
{
    public Transform m_PositionPlayer;
    float speed = 8;
    float timeDestroy;
    float destroyAttack = 1f;


    void Start()
    {
        m_PositionPlayer = GameObject.Find("Player").transform;
        Aim();
        
    }
    

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Vector3.right * Time.deltaTime * speed);

        timeDestroy += 1 * Time.deltaTime;
        if (timeDestroy >= destroyAttack)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.CompareTag("Player"))
            {
                PlayerControler player = collision.GetComponent<PlayerControler>();
                if (player != null)
                {
                    player.DamagePlayer(1);
                }
            }
            Destroy(gameObject);

        }
        if (collision.gameObject.tag == "Colisao") Destroy(gameObject);
    }

    void Aim()
    {
        Vector3 dir = m_PositionPlayer.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
