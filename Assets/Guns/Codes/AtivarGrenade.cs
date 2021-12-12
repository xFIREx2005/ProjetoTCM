using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivarGrenade : MonoBehaviour
{
    public Transform posPlayer;
    void Start()
    {
        posPlayer = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float _distPlayer = Vector2.Distance(transform.position, posPlayer.position);
        if (_distPlayer <= 1 && Input.GetKeyDown(KeyCode.Q))
        {
            PlayerStatic.Instance.GravarGrenade(1);
            GunsControler.activeGrenade = 1;
            Destroy(gameObject);
        }
    }
}
