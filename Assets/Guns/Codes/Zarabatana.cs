using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zarabatana : GunsControler
{
    // Start is called before the first frame update
    void Start()
    {
        
        checkAttack = true;
        coldown = 1;
    }

    // Update is called once per frame
    void Update()
    {
        AttackZarabatana();
        Aim();
        
    }
    public void CheckAttack()
    {
        checkAttack = true;
    }
}
