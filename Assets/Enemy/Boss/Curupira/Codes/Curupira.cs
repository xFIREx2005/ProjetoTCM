using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curupira : EnemyControler
{
    Animator animCurupira;
    public GameObject attackLanca, attackFuracao, enemy1, enemy2, enemy3, enemy4, objLife;
    public Sprite sprLife5, sprLife4, sprLife3, sprLife2, sprLife1;
    public float timer, timerR, attack;
    int enemy;

    void Start()
    {
        life = 20;
        animCurupira = GetComponent<Animator>();
        timerR = Random.Range(2, 4);
        attack = 1;
    }

    // Update is called once per frame
    void Update()
    {
        CheckLife();
        timer += Time.deltaTime;
        //attack = Random.Range(1, 3);

        if (timer >= timerR)
        {
            
            if (attack == 1)
            {
                speedF = 6;
                speedP = 2;
                Lanca(); 
            }
            else if (attack == 2)
            {
                speedF = 8;
                speedP = 2;
                Furacao();    
            }
            else if (attack == 3)
            {
                SpawnEnemy(); 
            }
        }
        else
        {
            animCurupira.SetBool("IsMoving", false);
        }
        

    }

    public void Lanca()
    {
        
        float _distPlayer = Vector2.Distance(transform.position, posPlayer.position);
        if (_distPlayer <= 2f)
        {
            timer = 0;
            animCurupira.SetBool("Lanca", true);
        }
        else
        {
            PosMove();
            CheckMoveClose();
        }
        
    }
    public void LancaAttack()
    {
        Instantiate(attackLanca, transform.position, transform.rotation);
        timerR = Random.Range(1, 3);
        attack = Random.Range(1, 4);
    }

    public void LancaFinish()
    {
        animCurupira.SetBool("Lanca", false);
        

    }
    public void Furacao()
    {
        PosMove();
        CheckMoveClose();
        float _distPlayer = Vector2.Distance(transform.position, posPlayer.position);
        if (_distPlayer <= 2f)
        {
            animCurupira.SetBool("Furacao", true);
        }

    }
    public void FuracaoFinish()
    {
        timerR = Random.Range(2, 4);
        attack = Random.Range(1, 4);
        animCurupira.SetBool("Furacao", false);
        timer = 0;
    }
    public void FuracaoAttack()
    {
        Instantiate(attackFuracao, transform.position, transform.rotation);
    }

    public void SpawnEnemy()
    {
        for(int i = 0; i < 4; i++)
        {
            enemy = Random.Range(1, 5);
            if(enemy == 1)
            {
                Instantiate(enemy1, transform.position, transform.rotation);
            }
            if (enemy == 2)
            {
                Instantiate(enemy2, transform.position, transform.rotation);timer = 0;
            }
            if (enemy == 3)
            {
            Instantiate(enemy3, transform.position, transform.rotation);
            }
            if (enemy == 4)
            {
                Instantiate(enemy4, transform.position, transform.rotation);
            }
        }
        timerR = Random.Range(2, 5);
        attack = Random.Range(1, 4);
        timer = 0;
    }
    
    void CheckLife()
    {
        if (life > 16) objLife.GetComponent<SpriteRenderer>().sprite = sprLife5;
        if (life > 12 && life <= 16) objLife.GetComponent<SpriteRenderer>().sprite = sprLife4;
        if (life > 8 && life <= 12) objLife.GetComponent<SpriteRenderer>().sprite = sprLife3;
        if (life > 4 && life <= 8) objLife.GetComponent<SpriteRenderer>().sprite = sprLife2;
        if (life >= 0 && life <= 4) objLife.GetComponent<SpriteRenderer>().sprite = sprLife1;
    }
}
