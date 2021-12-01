using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granada : GunsControler
{
    public GameObject granada;


    // Start is called before the first frame update
    void Start()
    {
        checkGranada = true;
        coldown = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        Aim();
        CreateGranada();
    }


}
