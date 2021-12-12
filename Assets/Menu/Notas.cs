using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notas : MonoBehaviour
{
    public Transform posPlayer;
    public GameObject notas;
    public bool nota;

    void Start()
    {
        posPlayer = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float _distPlayer = Vector2.Distance(transform.position, posPlayer.position);

        if (_distPlayer <= 1 && Input.GetKeyDown(KeyCode.Q) && nota == false)
        {
            nota = true;
        }
        else if (Input.GetKeyDown(KeyCode.Q) && nota == true)
        {
            nota = false;
        }

        if (nota == true)
        {
            notas.SetActive(true);
        }
        else notas.SetActive(false);

        if (_distPlayer >= 1)
        {
            nota = false;
        }
    }
}
