using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    public SpriteRenderer sprPlayer;
    public GameObject objLife;
    public Sprite sprlife1, sprlife2, sprlife3;

    int damage;
    float timeDamage;

    Player player = new Player(0, 3);
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.life <= 0) SceneManager.LoadScene("Boss1");

        if (player.life == 3) objLife.GetComponent<SpriteRenderer>().sprite = sprlife3;
        if (player.life == 2) objLife.GetComponent<SpriteRenderer>().sprite = sprlife2;
        if (player.life == 1) objLife.GetComponent<SpriteRenderer>().sprite = sprlife1;


        if (damage == 1) timeDamage += 1 * Time.deltaTime;

        if (timeDamage >= 0.2f) 
        { 
            sprPlayer.color = Color.white;
            damage = 0;
            timeDamage = 0;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyAttack"))
        {
            player.life -= 1;
            sprPlayer.color = new Color32(240, 128, 128, 200);
            damage = 1;
        }
    }
}
