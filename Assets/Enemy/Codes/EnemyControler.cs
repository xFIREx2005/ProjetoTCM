using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControler : MonoBehaviour
{
    protected float posX, posY, xMax, xMin, yMax, yMin, timerM, timerA, timerMF;
    public float speedP, speedF, disPatrol, disFollow, stopDis, coldown, timeStop;
    public int life;
    public bool patrol, followPlayer;

    protected Transform posPlayer;
    public Transform posPatrulha, posSpAttack;
    public GameObject enemyMinimap, colAttack;
    protected SpriteRenderer sprEnemy;
    protected Animator animEnemy;
    NavMeshAgent agent;
    public AudioSource audioDamage;


    void Awake()
    {
        posPlayer = GameObject.Find("Player").transform;
        sprEnemy = GetComponent<SpriteRenderer>();
        animEnemy = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {
        
    }

    public void DamageEnemy(int damageBullet)
    {
        audioDamage.Play();
        life -= damageBullet;
        StartCoroutine(Damage());
        if (life <= 0)
        {
            Destroy(gameObject);
        }

    }

    IEnumerator Damage()
    {
        sprEnemy.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprEnemy.color = Color.white;
    }

    protected void CheckMoveClose()
    {
        float _dist = Vector2.Distance(transform.position, posPatrulha.position);
        float _distPlayer = Vector2.Distance(transform.position, posPlayer.position);

        if (followPlayer == true)
        {
            if (_distPlayer <= disFollow)
            {
                MovePlayerClose();
                posPatrulha.position = transform.position;
                enemyMinimap.SetActive(true);
                if (_distPlayer <= 1.2)
                {
                    agent.speed = 0f;
                }
            }
            else if (patrol == true)
            {
                MovePatrol();
                enemyMinimap.SetActive(false);
                if (_dist <= 0.1f)
                {
                    agent.speed = 0f;
                }
            }
        }
        else if (patrol == true) MovePatrol();

        if (_dist <= 2f)
            if (timerM <= 0)
            {
                posPatrulha.position = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
                timerM = timeStop;
            }
            else
            {
                timerM -= Time.deltaTime;
            }

        if (agent.speed <= 0)
        {
            animEnemy.SetBool("IsMoving", false);
        }
    }

    void MovePlayerClose()
    {
        agent.SetDestination(posPlayer.transform.position);
        agent.stoppingDistance = stopDis;
        agent.speed = speedF;

        animEnemy.SetBool("IsMoving", true);
        animEnemy.SetFloat("MoveX", (posPlayer.transform.position.x - transform.position.x));
        animEnemy.SetFloat("MoveY", (posPlayer.transform.position.y - transform.position.y));
    }

    void MovePatrol()
    {
        agent.SetDestination(posPatrulha.transform.position);
        agent.stoppingDistance = 0.1f;
        agent.speed = speedP;

        animEnemy.SetBool("IsMoving", true);
        animEnemy.SetFloat("MoveX", (posPatrulha.transform.position.x - transform.position.x));
        animEnemy.SetFloat("MoveY", (posPatrulha.transform.position.y - transform.position.y));
    }

    public void PosMove()
    {
        posX = transform.position.x;
        posY = transform.position.y;

        xMin = posX - disPatrol;
        xMax = posX + disPatrol;
        yMin = posY - disPatrol;
        yMax = posY + disPatrol;
    }

    

    

}
