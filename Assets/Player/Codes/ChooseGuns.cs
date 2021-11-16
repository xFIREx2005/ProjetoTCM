using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseGuns : MonoBehaviour
{
    int gun;
    public GameObject Sword, Zarabatana;

    void Start()
    {
        gun = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (gun == 1)
        {
            Sword.SetActive(true);
            Zarabatana.SetActive(false);
        }
        else if (gun == 2)
        {
            Zarabatana.SetActive(true);
            Sword.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && gun == 1)
        {
            gun = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && gun == 2)
        {
            gun = 1;
        }
    }
}
