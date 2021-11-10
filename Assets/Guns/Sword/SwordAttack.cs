using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    SpriteRenderer sprite;

    public GameObject bullet;
    public Transform spawnBullet;

    float coldown = 0f;
    public float shoot;
    public int gun;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Aim();
        Shoot();
    }
    void Aim()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);

        Vector2 offset = new Vector2(mousePos.x - screenPoint.x, mousePos.y - screenPoint.y);

        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);

        sprite.flipY = (mousePos.x < screenPoint.x);
    }

    void Shoot()
    {
        coldown += 1 * Time.deltaTime;

        if (coldown >= shoot)
        {
            if (Input.GetMouseButton(0))
            {
                Instantiate(bullet, spawnBullet.position, transform.rotation);
                coldown = 0f;
            }
        }
    }
}
