using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarraBoss : MonoBehaviour
{
    public GameObject boss, teleporte;

    // Start is called before the first frame update
    void Start()
    {
        teleporte.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(!boss)
        {
            teleporte.SetActive(true);
            Destroy(gameObject);
        }
    }
}
