using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    Player player = new Player(0, 3, false, false, 0, false, 0.2f);

    private SpriteRenderer sprPlayer;
    private GameObject objLife;
    public Sprite sprlife1, sprlife2, sprlife3;

    float timer;

    void Start()
    {
        sprPlayer = GetComponent<SpriteRenderer>();
        objLife = GameObject.Find("LifePlayer");
    }

    // Update is called once per frame
    void Update()
    {
        CheckLife();
        LoseLife();
    }

    public void CheckLife()
    {
        if (player.life >= 3) objLife.GetComponent<SpriteRenderer>().sprite = sprlife3;
        if (player.life == 2) objLife.GetComponent<SpriteRenderer>().sprite = sprlife2;
        if (player.life <= 1) objLife.GetComponent<SpriteRenderer>().sprite = sprlife1;
    }

    public void LoseLife()
    {
        if (player.damage == true) timer += 1 * Time.deltaTime;

        if (timer >= player.timeDamage)
        {
            sprPlayer.color = Color.white;
            player.damage = false;
            timer = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyAttack"))
        {
            player.life -= 1;
            sprPlayer.color = new Color32(240, 128, 128, 200);
            player.damage = true;
        }
    }
}
