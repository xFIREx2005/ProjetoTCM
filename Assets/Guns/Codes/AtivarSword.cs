using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivarSword : MonoBehaviour
{
    public Transform posPlayer;
    void Start()
    {
        if (PlayerControler.activeSword == 1) Destroy(gameObject);
        posPlayer = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float _distPlayer = Vector2.Distance(transform.position, posPlayer.position);
        if(_distPlayer <= 1 && Input.GetKeyDown(KeyCode.Q))
        {
            PlayerStatic.Instance.GravarSword(1);
            PlayerControler.activeSword = 1;
            Destroy(gameObject);
        }
    }
}
