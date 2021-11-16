using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    NavMeshAgent agent;

    public GameObject enemyMinimap;
    public Transform m_Position, m_PositionPlayer, m_PositionAttack;
    public float m_TempoEspera, m_DistanceMove, velPatrol, velFollow, disFollow;
    float x_Min, x_Max, y_Min, y_Max;
    float m_Tempo;
    public bool patrol, followPlayer; 

    public SpriteRenderer sprEnemy;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        x_Min = transform.position.x - m_DistanceMove;
        x_Max = transform.position.x + m_DistanceMove;
        y_Min = transform.position.y - m_DistanceMove;
        y_Max = transform.position.y + m_DistanceMove;

        m_Position.position = new Vector2(Random.Range(x_Min, x_Max), Random.Range(y_Min, y_Max));
        m_Tempo = m_TempoEspera;
    }

    
    void Update()
    {
        x_Min = transform.position.x - m_DistanceMove;
        x_Max = transform.position.x + m_DistanceMove;
        y_Min = transform.position.y - m_DistanceMove;
        y_Max = transform.position.y + m_DistanceMove;

        CheckMove();
        CheckSpr();
    }

    void CheckSpr()
    {
       
        if (sprEnemy.flipX == true)
        {
            Vector2 _dirSpawn = new Vector2((transform.position.x + 0.5f), transform.position.y);
            m_PositionAttack.position = _dirSpawn;
        }
        else
        {
            Vector2 _dirSpawn = new Vector2((transform.position.x - 0.5f), transform.position.y);
            m_PositionAttack.position = _dirSpawn;
        }
    }

    void CheckMove()
    {
        float _dist = Vector2.Distance(transform.position, m_Position.position);
        float _distPlayer = Vector2.Distance(transform.position, m_PositionPlayer.position);

        if (followPlayer == true)
        {
            if (_distPlayer <= disFollow)
            {
                MovePlayer();
                m_Position.position = transform.position;
                enemyMinimap.SetActive(true);

            }
            else if (patrol == true)
            { 
                MovePatrol();
                enemyMinimap.SetActive(false);
            }
        }
        else if (patrol == true) MovePatrol();

        if (_dist <= 2f)
            if (m_Tempo <= 0)
            {
                m_Position.position = new Vector2(Random.Range(x_Min, x_Max), Random.Range(y_Min, y_Max));
                m_Tempo = m_TempoEspera;
            }
            else
            {
                m_Tempo -= Time.deltaTime;
            }
    }
    
    void MovePlayer()
    {
        sprEnemy.flipX = (m_PositionPlayer.position.x > transform.position.x);
        agent.SetDestination(m_PositionPlayer.transform.position);
        agent.stoppingDistance = 1.4f;
        agent.speed = velFollow;
    }

    void MovePatrol()
    {
        sprEnemy.flipX = (m_Position.position.x > transform.position.x);
        agent.SetDestination(m_Position.transform.position);
        agent.stoppingDistance = 0.1f;
        agent.speed = velPatrol;
    }
}
