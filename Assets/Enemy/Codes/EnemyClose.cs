using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClose : EnemyControler
{
    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        PosMove();
        CheckMoveClose();
        CheckAttackClose();
    }
    public void CheckAttackClose()
    {
        timerA += 1 * Time.deltaTime;
        float _distPlayer = Vector2.Distance(transform.position, posPlayer.position);

        if (_distPlayer <= 1.7f) ShootClose();
    }

    void ShootClose()
    {

        if (timerA >= coldown)
        {
            Instantiate(colAttack, posSpAttack.position, transform.rotation);
            timerA = 0f;
        }
    }
}
