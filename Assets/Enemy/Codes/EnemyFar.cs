using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFar : EnemyControler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckMoveFar();

        
    }

    protected void CheckMoveFar()
    {

        float _distPlayer = Vector2.Distance(transform.position, posPlayer.position);

        timerMF += 1 * Time.deltaTime;

        if (_distPlayer <= disFollow)
        {
            if (timerMF >= 1.5f)
            {
                MovePlayerFar();
                ShootFar();
                enemyMinimap.SetActive(true);
            }
        }

    }

    void MovePlayerFar()
    {
        animEnemy.SetBool("IsMoving", true);
        animEnemy.SetFloat("MoveX", (posPlayer.transform.position.x - transform.position.x));
        animEnemy.SetFloat("MoveY", (posPlayer.transform.position.y - transform.position.y));

    }

    void Timer()
    {
        animEnemy.SetBool("IsMoving", false);
    }

    void ShootFar()
    {
        Instantiate(colAttack, posSpAttack.position, transform.rotation);
        timerMF = 0;
    }
}
