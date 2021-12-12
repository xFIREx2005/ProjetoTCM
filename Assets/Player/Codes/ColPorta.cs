using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColPorta : MonoBehaviour
{
    public string nameScene;
    public Transform player;
    public float playerX;
    public float playerY;

    private void Start()
    {
        player = GameObject.Find("Player").transform;
        player.position = new Vector3(PlayerStatic.Instance.ConsutarPostionX(), PlayerStatic.Instance.ConsutarPostionY(), 0);

    }
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerStatic.Instance.GravarPositionX(playerX);
            PlayerStatic.Instance.GravarPositionY(playerY);
            SceneManager.LoadScene(nameScene);
        }
    }
}
