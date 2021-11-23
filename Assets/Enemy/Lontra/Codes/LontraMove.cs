using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LontraMove : MonoBehaviour
{
    Enemy enemy = new Enemy(0, 0, 0, 0, 5f, 5, 0, false, 0);
    NavMeshAgent agent;
    public GameObject enemyMinimap;
    public SpriteRenderer sprEnemy;
    public Transform  m_PositionAttack;
    private Transform m_PositionPlayer;
    private Animator myAnim;

    float timer;
    public bool patrol, followPlayer;
    public float timeStop;


    void Start()
    {
        myAnim = GetComponent<Animator>();
        sprEnemy = GetComponent<SpriteRenderer>();
        m_PositionPlayer = GameObject.Find("Player").transform;

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;       
    }


    void Update()
    {
        
        CheckMove();
        CheckSpr();
    }

    void CheckSpr()
    {
        
    }

    void CheckMove()
    {
        
        float _distPlayer = Vector2.Distance(transform.position, m_PositionPlayer.position);

        agent.SetDestination(m_PositionPlayer.transform.position);
        agent.stoppingDistance = 0f;
        agent.speed = 0f;


        timer += 1 * Time.deltaTime;

        if (_distPlayer <= enemy.disFollow)
        {
            if (timer >= 1.5f)
            {
                MovePlayer();
                enemyMinimap.SetActive(true);
            }
        }
        
    }
    void Timer()
    {
        timer = 0;
        myAnim.SetBool("IsMoving", false);

    }

    void MovePlayer()
    {
        myAnim.SetBool("IsMoving", true);
        myAnim.SetFloat("MoveX", (m_PositionPlayer.transform.position.x - transform.position.x));
        myAnim.SetFloat("MoveY", (m_PositionPlayer.transform.position.y - transform.position.y));
    }
}
