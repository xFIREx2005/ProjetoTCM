using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : GunsControler
{
    // Start is called before the first frame update
    void Start()
    {
        
        checkAttack = true;
        coldown = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        AttackSword();
        Aim();
    }
    public void CheckAttack()
    {
        checkAttack = true;
    }
    
}
